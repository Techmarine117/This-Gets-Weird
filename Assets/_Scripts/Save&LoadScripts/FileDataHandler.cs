using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string DataDirectory = "";
    private string DataFileName = "";
    private bool UsingEncryption = false;
    private readonly string EncryptCodeWord = "TheWords";

    public FileDataHandler(string DataDirectory , string DataFileName, bool usingEncryption)
    {
        this.DataDirectory = DataDirectory;
        this.DataFileName = DataFileName;
        this.UsingEncryption = usingEncryption;
        
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

                if (UsingEncryption)
                {
                    DataToLoad = EncryptAndDecrypt(DataToLoad);
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

            if(UsingEncryption)
            {
                StoringData = EncryptAndDecrypt(StoringData);
            }

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

    public void DeleteSave()
    {
        string FullPath = Path.Combine(DataDirectory, DataFileName);
        if (File.Exists(FullPath))
        {
            try
            {
                File.Delete(DataDirectory);
                Debug.Log(FullPath);
            }
            catch (Exception e)
            {
                Debug.LogError("connot delete file + filePath:" + "\n" + e);
            }
        }

            
    }

    private string EncryptAndDecrypt(string data)
    {
        string ModifiedData = "";
        for(int i = 0; i < data.Length; i++)
        {
            ModifiedData += (char)(data[i] ^ EncryptCodeWord[i % EncryptCodeWord.Length]);
        }
        return ModifiedData;
    }

}
