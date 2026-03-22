#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Reflection;

public static class ExpandSelected
{
    [MenuItem("Tools/Expand Selected %#q")]
    static void ExpandSelectedObject()
    {
        var obj = Selection.activeObject;
        if (obj == null)
        {
            Debug.LogWarning("Hiçbir obje seçili deðil!");
            return;
        }

        SetExpanded(obj, true);
        Debug.Log($"'{obj.name}' Inspector içinde expand edildi.");
    }

    static void SetExpanded(Object target, bool expand)
    {
        // Editor objesini al
        Editor editor = Editor.CreateEditor(target);

        // Inspector geniþletme alanýna eriþim
        var editorType = typeof(Editor);
        var method = editorType.GetMethod("SetExpanded", BindingFlags.NonPublic | BindingFlags.Instance);

        if (method != null)
        {
            method.Invoke(editor, new object[] { expand });
        }

        // Componentlere uygula
        if (target is GameObject go)
        {
            foreach (var comp in go.GetComponents<Component>())
            {
                if (comp != null)
                {
                    Editor compEditor = Editor.CreateEditor(comp);
                    method = editorType.GetMethod("SetExpanded", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (method != null)
                        method.Invoke(compEditor, new object[] { expand });
                }
            }
        }
    }
}
#endif