using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.Freamwork.Language
{
    /// <summary>
    /// A <see cref="MonoBehaviour"/> which is used to handle language changes.
    /// </summary>
    public class LanguageManager : MonoBehaviour
    {
        public static LanguageManager Instance { get; private set; }

        [SerializeField] private string m_JSONName = "WordDictionary";
        [SerializeField] private List<LanguageId> m_Languages;
        [SerializeField] private List<DictionaryAsset> m_DictionaryAssets;

        /// <summary>
        /// The refrence of <see cref="LanguageDatabase"/>
        /// </summary>
        public LanguageDatabase Database { get; private set; }

        /// <summary>
        /// The language that activated.
        /// </summary>
        public LanguageId ActiveLanguage { get; private set; }

        /// <summary>
        /// An event invoke when the <see cref="ActiveLanguage"/> changed.
        /// </summary>
        public event Action<LanguageId> LanguageChanged;

        /// <summary>
        /// An event which invoke when the <see cref="LanguageManager"/> loaded. 
        /// </summary>
        public event Action<LanguageId> OnLoad;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            var dictionaries = ReadLanguageAsset(m_JSONName);
            Database = new LanguageDatabase(dictionaries);

            ActiveLanguage = m_Languages[0];
        }

        private void Start()
        {
            OnLoad?.Invoke(ActiveLanguage);
        }

        /// <summary>
        /// Change the current language and invoke the LanguageChanged event. 
        /// </summary>
        /// <param name="language"></param>
        public void ChangeLanguage(LanguageId language)
        {
            ActiveLanguage = language;
            LanguageChanged?.Invoke(language);
        }

        public static Dictionary[] ReadLanguageAsset(string jsonName)
        {
            var textAsset = Resources.Load<TextAsset>(jsonName);
            string contents = textAsset.text;
            Dictionary dictionary = JsonUtility.FromJson<Dictionary>(contents);

            var assets = Resources.FindObjectsOfTypeAll<DictionaryAsset>();
            Dictionary[] dictionaries = new Dictionary[assets.Length + 1];
            dictionaries[0] = dictionary;
            for (int i = 0; i < assets.Length; i++)
            {
                dictionaries[i +1] = assets[i].Dictionary;
            }
            return dictionaries;
        }
    }
}