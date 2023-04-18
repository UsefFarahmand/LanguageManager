using DiaGna.Freamwork.Language.Components;
using UnityEditor;

namespace DiaGna.Freamwork.Language.Editors
{
#if UNITY_EDITOR

    [CustomEditor(typeof(TextMeshLanguageComponent))]
    public class TextMeshLanguageComponentEditor : LanguageComponentEditor
    {

    }
#endif
}