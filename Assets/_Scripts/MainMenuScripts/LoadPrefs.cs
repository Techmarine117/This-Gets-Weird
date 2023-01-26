using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadPrefs : MonoBehaviour
{
    [Header("General Settings")]
    public bool CanUse = false;
    public MainMenu mainMenu;

    [Header("Volume Settings")]
    public TMP_Text VolumeTextValue = null;
    public Slider VolumeSlider = null;

    [Header("Brightness Settings")]
    public Slider BrightnessSlider = null;
    public TMP_Text BrightnessTextValue = null;

    [Header("Quality Level Settings")]
    public TMP_Dropdown QualityDropdown;

    [Header("Fullscreen Settings")]
    public Toggle FullScreenToggle;

    [Header("Sensitivty Settings")]
    public TMP_Text SensitivityTextValue = null;
    public Slider SensitivitySlider = null;

    private void Awake()
    {
        if (CanUse)
        {
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                float LocalVolume = PlayerPrefs.GetFloat("MasterVolume");

                VolumeTextValue.text = LocalVolume.ToString("0.0");
                VolumeSlider.value = LocalVolume;
                AudioListener.volume = LocalVolume;
            }
            else
            {
                mainMenu.ResetButton("Audio");
            }

            if (PlayerPrefs.HasKey("MasterQuality"))
            {
                int LocalQuality = PlayerPrefs.GetInt("MasterQuality");
                QualityDropdown.value = LocalQuality;
                QualitySettings.SetQualityLevel(LocalQuality);
            }
            else
            {
                mainMenu.ResetButton("Quality");
            }

            if (PlayerPrefs.HasKey("MasterFullScreen"))
            {
                int LocalFullScreen = PlayerPrefs.GetInt("MasterFullScreen");

                if (LocalFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    FullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    FullScreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("MasterBrightness"))
            {
                float LocalBrightness = PlayerPrefs.GetFloat("MasterBrightness");
                BrightnessTextValue.text = LocalBrightness.ToString("0.0");
                BrightnessSlider.value = LocalBrightness;
            }

            if (PlayerPrefs.HasKey("MasterSensitivity"))
            {
                float LocalSensitivity = PlayerPrefs.GetFloat("MasterSensitivity");
                SensitivityTextValue.text = LocalSensitivity.ToString("0");
                SensitivitySlider.value = LocalSensitivity;
                mainMenu.DefaultSensitivity = Mathf.RoundToInt(LocalSensitivity);

            }
        }
    }


}