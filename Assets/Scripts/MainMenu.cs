using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    
    public string NewGame;
    private string LevelToLoad;
    public DataManager dataManager;
    public GameObject NoSaveObj = null;

    [Header("Volume Settings")]
    public TMP_Text VolumeTextValue = null;
    public Slider VolumeSlider = null;
    public GameObject ConfirmationPrompt = null;
    public float DefaultVolume = 5.0f;

    [Header("GamePlay Settings")]
    public TMP_Text SensitivityTextValue;
    public Slider SensitivitySlider = null;
    public float DefaultSensitivity = 4;

    [Header("Graphics Settings")]
    public Slider BrightnessSlider = null;
    public TMP_Text BrightnessTextValue = null;
    public float DefaultBrightness = 1;
    public TMP_Dropdown QualityDropdown;
    public Toggle FullScreenToggle;

    private int _QualityLevel;
    private bool IsFullScreen;
    private float BrightnessLevel;

    [Header("Resolution DropDowns")]
    public TMP_Dropdown ResolutionDropdown;
    public Resolution[] Resolutions;
    

    private void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
        Resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();

        List<string> Options = new List<string>();

        int CurrentResolutionIndex = 0;
        

        for(int i = 0; i < Resolutions.Length; i++)
        {
            Debug.Log(Resolutions[i].ToString());
            string Option = Resolutions[i].width + "x" + Resolutions[i].height;
            Options.Add(Option);

            if(Resolutions[i].width == Screen.width && Resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
                Debug.Log("debug2");
            }
        }
    }

    public void quitGame()
    {
        Debug.Log("quiting game");
        Application.Quit();

    }

    public void loadNewGame()
    {
        Debug.Log("level Loading");
        SceneManager.LoadScene(NewGame);
    }

    public void LoadLevel()
    {
        dataManager.LoadGame();
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            LevelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(LevelToLoad);
        }
        else
        {
            NoSaveObj.SetActive(true);
        }
    }

    public void SetVolume(float Volume)
    {
        AudioListener.volume = Volume;

        VolumeTextValue.text = Volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationText());
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Graphics")
        {
            //ToDo rest brightness value

            BrightnessSlider.value = DefaultBrightness;
            BrightnessTextValue.text = DefaultBrightness.ToString("0.0");
            QualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);
            FullScreenToggle.isOn = false;
            Screen.fullScreen = false;
            Resolution CurrentResolution = Screen.currentResolution;
            Screen.SetResolution(CurrentResolution.width, CurrentResolution.height, Screen.fullScreen);
            ResolutionDropdown.value = Resolutions.Length;
            GrpahicsApply();
        }

        if(MenuType == "Audio")
        {
            AudioListener.volume = DefaultVolume;
            VolumeSlider.value = DefaultVolume;
            VolumeTextValue.text = DefaultVolume.ToString("0.0");
            VolumeApply();
        }

        if(MenuType == "GamePlay")
        {
            SensitivityTextValue.text = DefaultSensitivity.ToString("0");
            SensitivitySlider.value = DefaultSensitivity;
            GamePlayApply();

        }
    }

    public void SetSensitivity(float Sensitivity)
    {
        DefaultSensitivity = Mathf.RoundToInt(Sensitivity);

        SensitivityTextValue.text = Sensitivity.ToString("0");
    }

    public void GamePlayApply()
    {
        PlayerPrefs.SetFloat("MasterSensitivity", DefaultSensitivity);
        StartCoroutine(ConfirmationText());
    }

    public void SetBrightness(float Brightness)
    {
        BrightnessLevel = Brightness;
        BrightnessTextValue.text = Brightness.ToString("0.0");
    }

    public void SetFullScreen(bool isFullScreen)
    {
        IsFullScreen = isFullScreen;
    }

    public void SetQuality(int QualityIndex)
    {
        _QualityLevel = QualityIndex;
    }

    public void GrpahicsApply()
    {
        PlayerPrefs.SetFloat("MasterBrightness", BrightnessLevel);

        PlayerPrefs.SetInt("MasterQulity", _QualityLevel);
        QualitySettings.SetQualityLevel(_QualityLevel);

        PlayerPrefs.SetInt("MasterFullScreen", (IsFullScreen ? 1 : 0));
        Screen.fullScreen = IsFullScreen;

        StartCoroutine(ConfirmationText());
    }

    public void SetResolutions(int ResolutionIndex)
    {
        Resolution resolution = Resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public IEnumerator ConfirmationText()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(5);

        ConfirmationPrompt.SetActive(false);
    }

}