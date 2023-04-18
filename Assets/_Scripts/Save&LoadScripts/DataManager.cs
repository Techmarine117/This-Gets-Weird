using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Events;
using Unity.Mathematics;
using PixelCrushers.DialogueSystem;
using PixelCrushers;

public class DataManager : MonoBehaviour, IData
{
    [Header("File Storage Config")]
    [SerializeField] private string FileName;
    [SerializeField] private bool UseEncryption;

    [SerializeField] private UnityEvent[] onMaskCollected;
    //[SerializeField] private DataManager[] DataManagers;

    public static DataManager Instance { get; private set; }
    private GameData gameData;
    private List<IData> DataObjects;
    private FileDataHandler dataHandler;
    [SerializeField] private DialogueDatabase dialogueDatabase;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one data manager in the scene");
        }
        Instance= this;

        int MasksCollected = onMaskCollected.Length;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, FileName, UseEncryption);
        this.DataObjects = FindAllDataObjects();
        //LoadGame();
        //DataManagers = FindObjectsOfType<DataManager>();
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("no data was found. Initializing data to defaults");
            NewGame();
        }

        foreach (IData data in DataObjects)
        {
            data.LoadData(gameData);
        }
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        FindObjectOfType<SaveSystem>().LoadGameFromSlot(0);
        
        

    }

    public void SaveGame()
    {
        foreach(IData data in DataObjects)
        {
            data.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
        PlayerPrefs.SetString("SavedLevel", SceneManager.GetActiveScene().name);

    }

   // private void OnApplicationQuit()
    //{
        //SaveGame();
   // }

    private List<IData> FindAllDataObjects()
    {
        IEnumerable<IData> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();

        return new List<IData>(dataObjects);
    }

    public void SaveData(ref GameData data)
    {
        //data.Mask1 = dialogueDatabase.GetVariable("Mask1Collected").InitialBoolValue;
        //data.Mask2 = dialogueDatabase.GetVariable("Mask2Collected").InitialBoolValue;
        //data.Mask3 = dialogueDatabase.GetVariable("Mask3Collected").InitialBoolValue;
    }

    public void LoadData(GameData data)
    {
        //this.transform.position = data.AIPosition;
    }
}
