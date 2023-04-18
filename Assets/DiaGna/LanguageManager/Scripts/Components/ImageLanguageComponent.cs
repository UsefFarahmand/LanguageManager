using UnityEngine;
using UnityEngine.UI;

namespace DiaGna.Freamwork.Language.Components
{
    /// <summary>
    /// A <see cref="LanguageComponent"/> to usage for <see cref="Image"/>.
    /// </summary>
    [RequireComponent(typeof(Image))]
    [AddComponentMenu("Language/Component/ImageComponent")]
    public class ImageLanguageComponent : LanguageComponent
    {
        protected override void SetValue(string value)
        {
            var sprite = ResourcesExtension.Load<Sprite>(value);
            GetComponent<Image>().sprite = sprite;
        }
    }
}