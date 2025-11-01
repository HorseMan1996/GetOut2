using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private CD_LocalizationData _localizationData;
    private RD_LocalizationData _localizationDataRunTime;


    [SerializeField] private List<LocalizationEntity> _localizationEntities = new List<LocalizationEntity>();

    private void Start()
    {
        _localizationData = Resources.Load<CD_LocalizationData>("CD_LocalizationData");

        _localizationDataRunTime = Resources.Load<RD_LocalizationData>("RD_LocalizationData");

        SetFirstLanguage();

        GetAllLocalizationEntities();

        SetTextLocalizations();
    }

    private void SetTextLocalizations()
    {
        foreach (var entity in _localizationEntities)
        {
            var localizedString = GetLocalizationString(entity.TermKey);
            entity.SetText(localizedString);
        }
    }

    private void GetAllLocalizationEntities()
    {
        _localizationEntities.AddRange(FindObjectsOfType<LocalizationEntity>());
    }

    public string GetLocalizationString(TermKey termKey)
    {


        if (_localizationData.LocalizationDictionary.Dictionary.TryGetValue(termKey, out var localizedValues))
        {
            if (localizedValues.Dictionary.TryGetValue(_localizationDataRunTime.SelectLanguage, out var localizedString))
            {
                return localizedString;
            }
            else
            {
                Debug.LogWarning($"Language {_localizationDataRunTime.SelectLanguage} not found for TermKey {termKey}. Falling back to default language.");
                return localizedString;
            }
        }
        else
        {
            Debug.LogWarning($"TermKey {termKey} not found in localization dictionary.");
            return $"[{termKey}]";
        }

    }

    private void SetFirstLanguage()
    {
        if (PlayerPrefs.HasKey("SelectedLanguage"))
        {
            if (Enum.TryParse(PlayerPrefs.GetString("SelectedLanguage"), out LanguagesEnum lang))
            {
                _localizationDataRunTime.SelectLanguage = lang;
            }
            else
            {
                _localizationDataRunTime.SelectLanguage = LanguagesEnum.English;
                Debug.LogWarning("Enum try parse Fail!");
            }
        }
        else
        {
            if (Enum.TryParse(Application.systemLanguage.ToString(), out LanguagesEnum lang))
            {
                _localizationDataRunTime.SelectLanguage = lang;
            }
            else
            {
                _localizationDataRunTime.SelectLanguage = LanguagesEnum.English;
                Debug.LogWarning("Enum try parse Fail!");
            }
        }
    }
}
