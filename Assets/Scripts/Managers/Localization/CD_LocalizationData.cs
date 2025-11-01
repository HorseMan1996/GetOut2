using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "CD_LocalizationData", menuName = "ScriptableObjects/CD_LocalizationData", order = 1)]
public class CD_LocalizationData : ScriptableObject
{
    public SerializableDictionary<TermKey, SerializableDictionary<LanguagesEnum,string>> LocalizationDictionary;

#if UNITY_EDITOR

    [SerializeField] private LanguagesEnum _languagesEnum;
    [SerializeField] private TermKey _termKey;
    [SerializeField] private SerializableDictionary<LanguagesEnum, string> _values;
    [SerializeField] private string _value;

    [ContextMenu("AddNewEntry")]
    public void AddNewEntry()
    {
        if (LocalizationDictionary.Dictionary.ContainsKey(_termKey))
        {
            if (LocalizationDictionary.Dictionary[_termKey].Dictionary.ContainsKey(_languagesEnum))
            {
                Debug.LogWarning("This TermKey already contains this LanguageEnum entry.");
                return;
            }
            else
            {
                Debug.Log("Added new LanguageEnum entry to existing TermKey.");
                LocalizationDictionary.Dictionary[_termKey].Dictionary.Add(_languagesEnum, _value);
            }
        }
        else
        {
            Debug.Log("Added new TermKey with LanguageEnum entry.");
            _values.Dictionary.Add(_languagesEnum, _value);
            var newValues = new SerializableDictionary<LanguagesEnum, string>();
            newValues.Dictionary.Add(_languagesEnum, _value);
            LocalizationDictionary.Dictionary.Add(_termKey, newValues);
        }

        _values.Dictionary.Clear();
    }

#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(CD_LocalizationData))]
public class MyDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CD_LocalizationData data = (CD_LocalizationData)target;
        if (GUILayout.Button("AddNewEntry"))
        {
            data.AddNewEntry();
        }
    }
}
#endif