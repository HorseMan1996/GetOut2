using Assets.Scripts.Managers.Localization;
using TMPro;
using UnityEngine;

public class LocalizationEntity : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] private TermKey _termKey;
    void OnValidate()
    {
        if (_text == null)
            _text = GetComponent<TMP_Text>() ?? GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string value)
    {
        if (_text != null)
            _text.text = value;
    }
}
