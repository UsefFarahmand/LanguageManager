using UnityEditor;
using UnityEngine;

namespace DiaGna.Freamwork.Language
{
    [CreateAssetMenu(fileName = "DictionaryAsset", menuName = "DiaGna/Freamwork/Language/DictionaryAsset")]
    public class DictionaryAsset : ScriptableObject
    {
        [SerializeField] private Dictionary m_Dictionary;

        public Dictionary Dictionary => m_Dictionary;
    }
}