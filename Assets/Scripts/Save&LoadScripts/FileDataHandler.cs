using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string DataDirectory = "";
    private string DataFileName = "";

    public FileDataHandler(string DataDirectory , string DataFileName)
    {
        this.DataDirectory = DataDirectory;
        this.DataFileName = DataFileName;
    }

    public GameData Load()
    {
        string FullPath = Path.Combine(DataDirectory, DataFileName);
        GameData LoadedData = null;

        if (File.Exists(FullPath))
        {
            try
            {
                string DataToLoad = "";
                using(FileStream stream = new FileStream(FullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        DataToLoad= reader.ReadToEnd();
                    }
                }

                LoadedData = JsonUtility.FromJson<GameData>(DataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("connot load data to file + filePath:" + "\n" + e);
            }

        }
        return LoadedData;
    }

    public void Save(GameData data)
    {
        string FullPath = Path.Combine(DataDirectory, DataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

            string StoringData = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(StoringData);
                }
            }
        }
        catch(Exception exception)  
        {
            Debug.LogError("connot save data to file + filePath:" + "\n" + exception);
        }
    }

}
