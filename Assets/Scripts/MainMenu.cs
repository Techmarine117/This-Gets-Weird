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


    private void Awake()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
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
        if(MenuType == "Audio")
        {
            AudioListener.volume = DefaultVolume;
            VolumeSlider.value = DefaultVolume;
            VolumeTextValue.text = DefaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    public IEnumerator ConfirmationText()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(5);

        ConfirmationPrompt.SetActive(false);
    }
}
