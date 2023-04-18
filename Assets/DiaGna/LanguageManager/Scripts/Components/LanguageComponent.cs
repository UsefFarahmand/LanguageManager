using UnityEngine;

namespace DiaGna.Freamwork.Language.Components
{
    /// <summary>
    /// A <see cref="MonoBehaviour"/> which is used to handle language changes.
    /// </summary>
    // This class is a subclass of MonoBehaviour which is used to handle language changes.
    // It has a private string variable called Key and two private functions, OnEnable and OnDisable, which subscribe and unsubscribe from the language changed event of LanguageManager.
    // The private function LanguageChanged then takes the given languageId and retrieves the value of the key from the database of the LanguageManager, which is then passed as an argument to the abstract function SetValue to be handled by the subclass.
    [DisallowMultipleComponent]
    public abstract class LanguageComponent : MonoBehaviour
    {
        [SerializeField] private string Key;

        private void OnEnable()
        {
            LanguageManager.Instance.LanguageChanged += LanguageChanged;
            LanguageManager.Instance.OnLoad += LanguageChanged;
        }

        private void OnDisable()
        {
            LanguageManager.Instance.LanguageChanged -= LanguageChanged;
            LanguageManager.Instance.OnLoad -= LanguageChanged;
        }

        private void LanguageChanged(LanguageId languageId)
        {
            var word = LanguageManager.Instance.Database.GetWord(Key, languageId);
            SetValue(word);
        }

        /// <summary>
        /// Implement it to use <paramref name="value"/> in anyway.
        /// </summary>
        /// <param name="value"></param>
        protected abstract void SetValue(string value);
    }
}