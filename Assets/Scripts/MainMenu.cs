using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string NewGame;
    private string LevelToLoad;
    public DataManager dataManager;
    public GameObject NoSaveObj = null;

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
}
