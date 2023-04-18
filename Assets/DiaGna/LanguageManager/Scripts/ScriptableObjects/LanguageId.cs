using UnityEngine;

namespace DiaGna.Freamwork.Language
{
    /// <summary>
    /// Represents a language identifier as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(fileName = "LanguageId", menuName = "DiaGna/Freamwork/Language/LanguageId")]
    public class LanguageId : ScriptableObject
    {
        public string Id => name;
    }
}