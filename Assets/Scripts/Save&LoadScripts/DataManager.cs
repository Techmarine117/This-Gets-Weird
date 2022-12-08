using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string FileName;
    [SerializeField] private bool UseEncryption;

   public static DataManager Instance { get; private set; }
    private GameData gameData;
    private List<IData> DataObjects;
    private FileDataHandler dataHandler;

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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, FileName, UseEncryption);
        this.DataObjects = FindAllDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("no data was found. Initializing data to defaults");
            NewGame();
        }

        foreach(IData data in DataObjects)
        {
            data.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(IData data in DataObjects)
        {
            data.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IData> FindAllDataObjects()
    {
        IEnumerable<IData> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();

        return new List<IData>(dataObjects);
    }
}
