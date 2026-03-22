using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown fpsDropdown;

    [Header("Toggles")]
    public Toggle fullscreenToggle;

    Resolution[] resolutions;

    void Start()
    {
        // Çözünürlükleri yükle
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        var options = new System.Collections.Generic.List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Fullscreen
        fullscreenToggle.isOn = Screen.fullScreen;

        // Quality
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));
        qualityDropdown.value = QualitySettings.GetQualityLevel();

        // FPS seçenekleri
        fpsDropdown.ClearOptions();
        fpsDropdown.AddOptions(new System.Collections.Generic.List<string>()
        { "30", "60", "120", "144", "240", "Unlimited" });

        fpsDropdown.value = 1; // Varsayılan 60 FPS
    }

    public void ApplySettings()
    {
        SetResolution(resolutionDropdown.value);
        SetFullscreen(fullscreenToggle.isOn);
        SetQuality(qualityDropdown.value);
        SetFPS(fpsDropdown.value);
    }

    // 🔧 Çözünürlüğü değiştir
    private void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    // 🔧 Tam ekran
    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // 🔧 Grafik kalitesi
    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    // 🔧 FPS limiti
    private void SetFPS(int index)
    {
        string selected = fpsDropdown.options[index].text;

        if (selected == "Unlimited")
            Application.targetFrameRate = -1;
        else
            Application.targetFrameRate = int.Parse(selected);
    }
}
