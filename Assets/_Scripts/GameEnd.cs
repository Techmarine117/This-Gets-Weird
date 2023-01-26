using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour
{
    public DataManager dataManager;
    private string LevelToLoad;

    private void Awake()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadMain()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void LoadLastSave()
    {
        dataManager.LoadGame();
        LevelToLoad = PlayerPrefs.GetString("SavedLevel");
        SceneManager.LoadScene(LevelToLoad);

    }

}
