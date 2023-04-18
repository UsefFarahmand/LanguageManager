using DiaGna.Freamwork.Language.Components;
using UnityEditor;

namespace DiaGna.Freamwork.Language.Editors
{
#if UNITY_EDITOR

    [CustomEditor(typeof(ImageLanguageComponent))]
    public class ImageLanguageComponentEditor : LanguageComponentEditor
    {

    }
#endif
}