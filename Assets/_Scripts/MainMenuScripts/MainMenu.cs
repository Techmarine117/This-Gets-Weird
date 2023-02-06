using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

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
    public TMP_Text SensitivityTextValue = null;
    public Slider SensitivitySlider = null;
    public float DefaultSensitivity = 4;

    [Header("Graphics Settings")]
    public Slider BrightnessSlider = null;
    public TMP_Text BrightnessTextValue = null;
    public float DefaultBrightness = 1;
    public TMP_Dropdown QualityDropdown;
    public Toggle FullScreenToggle;
    public Volume brightnessVolume;
    private ColorAdjustments CA;

    private int _QualityLevel;
    private bool IsFullScreen;
    private float BrightnessLevel;

    [Header("Resolution DropDowns")]
    public TMP_Dropdown ResolutionDropdown;
    public Resolution[] Resolutions;
    // public List<Resolution> FilteredResolutions;

    [Header("KeyReBind Settings")]
    [SerializeField]
    private InputActionReference[] inputActionReference;

    [SerializeField]
    private bool ExcludeMouse = true;

    [Range(0, 4)]
    [SerializeField]
    private int SelectedBinding;

    [SerializeField]
    private InputBinding.DisplayStringOptions displayStringOptions;

    public TMP_Text[] ActionText;
    public TMP_Text[] RebindText;
    public Button[] RebindButton;

    [Header("Binding Info")]
    [SerializeField]
    private InputBinding inputBinding;
    [SerializeField]
    private int[] BindingIndex;
    [SerializeField]
    private string[] ActionName;

    private void Awake()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();


        Resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();

        brightnessVolume.profile.TryGet(out CA);

        List<string> Options = new List<string>();

        int CurrentResolutionIndex = 0;


        for (int i = 0; i < Resolutions.Length; i++)
        {
            Debug.Log(Resolutions[i].ToString());
            string Option = Resolutions[i].width + " x " + Resolutions[i].height;
            Options.Add(Option);

            if (Resolutions[i].width == Screen.width && Resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
                Debug.Log("debug2");
            }
        }

        ResolutionDropdown.AddOptions(Options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    private void OnValidate()
    {
        if (inputActionReference == null)
            return;

        GetBindingInfo();
        UpdateBindingUI();
        UpdateBindingUIJump();
    }

    private void OnEnable()
    {
        //possible error
        int i = 0;
        foreach (var button in RebindButton)
        {
            button.onClick.AddListener(() => DoReBind(i));
            i++;
        }
       

        if (inputActionReference[0] != null)
        {
            InputManager.LoadBindingOveride(ActionName[0]);
            GetBindingInfo();
            UpdateBindingUI();
        } 
        if (inputActionReference[1] != null)
        {
            InputManager.LoadBindingOveride(ActionName[1]);
            GetBindingInfo();
            UpdateBindingUIJump();
        }
        if (inputActionReference[2] != null)
        {
            InputManager.LoadBindingOveride(ActionName[2]);
            GetBindingInfo();
            UpdateBindingUIRun();
        }
            
        InputManager.ReBindComplete += UpdateBindingUI;
        InputManager.RebindCanceled += UpdateBindingUI;

        InputManager.ReBindComplete += UpdateBindingUIJump;
        InputManager.RebindCanceled += UpdateBindingUIJump;

        InputManager.ReBindComplete += UpdateBindingUIRun;
        InputManager.RebindCanceled += UpdateBindingUIRun;
    }

    private void OnDisable()
    {
        InputManager.ReBindComplete -= UpdateBindingUI;
        InputManager.RebindCanceled -= UpdateBindingUI;

        InputManager.ReBindComplete -= UpdateBindingUIJump;
        InputManager.RebindCanceled -= UpdateBindingUIJump;

        InputManager.ReBindComplete -= UpdateBindingUIRun;
        InputManager.RebindCanceled -= UpdateBindingUIRun;
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
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            dataManager.LoadGame();
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
        if (MenuType == "Graphics")
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

        if (MenuType == "Audio")
        {
            AudioListener.volume = DefaultVolume;
            VolumeSlider.value = DefaultVolume;
            VolumeTextValue.text = DefaultVolume.ToString("0.0");
            VolumeApply();
        }

        if (MenuType == "GamePlay")
        {
            SensitivityTextValue.text = DefaultSensitivity.ToString("0");
            SensitivitySlider.value = DefaultSensitivity;
            GamePlayApply();

        }

        if (MenuType == "Controls")
        {
            InputManager.ResetBinding(ActionName[0], BindingIndex[0]);
            InputManager.ResetBinding(ActionName[1], BindingIndex[1]);
            InputManager.ResetBinding(ActionName[2], BindingIndex[2]);
            UpdateBindingUI();
            UpdateBindingUIJump();
            UpdateBindingUIRun();

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
        CA.postExposure.value = Brightness;

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

        PlayerPrefs.SetInt("MasterQuality", _QualityLevel);
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

    private void GetBindingInfo()
    {
        if (inputActionReference[0].action != null)
        {
            ActionName[0] = inputActionReference[0].action.name;
        } 
        if (inputActionReference[1].action != null)
        {
            ActionName[1] = inputActionReference[1].action.name;
        } 
        if (inputActionReference[2].action != null)
        {
            ActionName[2] = inputActionReference[2].action.name;
        }


        if (inputActionReference[0].action.bindings.Count > SelectedBinding)
        {
            inputBinding = inputActionReference[0].action.bindings[SelectedBinding];
            //changes here
            BindingIndex[0] = SelectedBinding;
            BindingIndex[1] = 0;
            BindingIndex[2] = 0;
        }
    }

    private void UpdateBindingUI()
    {
        if (ActionText[0] != null)
            ActionText[0].text = ActionName[0];

        if (RebindText != null)
        {
            if (Application.isPlaying)
            {
                RebindText[0].text = InputManager.GetBindingName(ActionName[0], BindingIndex[0]);
            }
        }
        else
        {
            RebindText[0].text = inputActionReference[0].action.GetBindingDisplayString(BindingIndex[0]);
        }
            


    }


    private void UpdateBindingUIJump()
    {
        
            if (ActionText[1] != null)
                ActionText[1].text = ActionName[1];

            if (RebindText[1] != null)
            {
                if (Application.isPlaying)
                {
                    RebindText[1].text = InputManager.GetBindingName(ActionName[1], BindingIndex[1]);
                }
            }
            else
            {
                RebindText[1].text = inputActionReference[1].action.GetBindingDisplayString(BindingIndex[1]);
            }
        
    }


    private void UpdateBindingUIRun()
    {

        if (ActionText[2] != null)
            ActionText[2].text = ActionName[2];

        if (RebindText[2] != null)
        {
            if (Application.isPlaying)
            {
                RebindText[2].text = InputManager.GetBindingName(ActionName[2], BindingIndex[2]);
            }
        }
        else
        {
            RebindText[2].text = inputActionReference[2].action.GetBindingDisplayString(BindingIndex[2]);
        }

    }

    public void DoReBind(int actionreferenceindex)
    {
        InputManager.StartRebind(ActionName[actionreferenceindex], BindingIndex[actionreferenceindex], RebindText[actionreferenceindex], ExcludeMouse);
    }

    public void addBindingValue()
    {
        SelectedBinding++;
        if (SelectedBinding >= 5) 
        {
            SelectedBinding = 1;
        }
        if (inputActionReference == null)
            return;

        GetBindingInfo();
        UpdateBindingUI();
        UpdateBindingUIJump();
    }
    public void removeBindingValue()
    {
        SelectedBinding--;
        if (SelectedBinding <= 0)
        {
            SelectedBinding = 4;
        }
        if (inputActionReference == null)
            return;

        GetBindingInfo();
        UpdateBindingUI();
        UpdateBindingUIJump();
    }

}