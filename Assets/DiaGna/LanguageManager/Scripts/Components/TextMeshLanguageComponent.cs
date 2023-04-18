using TMPro;
using UnityEngine;

namespace DiaGna.Freamwork.Language.Components
{
    /// <summary>
    /// A <see cref="LanguageComponent"/> to usage for <see cref="TMP_Text"/>.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    [AddComponentMenu("Language/Component/TMP_TextComponent")]
    public class TextMeshLanguageComponent : LanguageComponent
    {
        protected override void SetValue(string value)
        {
            GetComponent<TMP_Text>().SetText(value);
        }
    }
}