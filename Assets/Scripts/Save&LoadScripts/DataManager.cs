using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private GameData gameData;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one data manager in the scene");
        }
        Instance= this;
    }

    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("no data was found. Initializing data to defaults");
            NewGame();
        }
    }

    public void SaveGame()
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
