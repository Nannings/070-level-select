using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    private string fileName = "_level_data.dat";

    private SaveMethod saveMethod = SaveMethod.Json_PlayerPrefs;

    enum SaveMethod
    {
        Binary,
        Json,
        Json_PlayerPrefs
    }

    public void Save(SaveState data)
    {
        string path = Application.persistentDataPath + "/" + saveMethod.ToString() + fileName;

        if (saveMethod == SaveMethod.Binary)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            bf.Serialize(file, data);
            file.Close();
        }
        else if(saveMethod == SaveMethod.Json)
        {
            string serializedData = JsonUtility.ToJson(data, true);
            Debug.Log(data +" ------- "+ serializedData);
            File.WriteAllText(path, serializedData);
        }
        else if (saveMethod == SaveMethod.Json_PlayerPrefs)
        {
            string serializedData = JsonUtility.ToJson(data, false);
            PlayerPrefs.SetString(fileName, serializedData);
        }
    }

    public SaveState Load()
    {
        string path = Application.persistentDataPath + "/" + saveMethod.ToString() + fileName;

        if (saveMethod == SaveMethod.Binary)
        {
            bool fileExist = File.Exists(path);
            if (!fileExist) return null;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveState levelData = (SaveState)bf.Deserialize(file);
            file.Close();
            return levelData;
        }
        else if (saveMethod == SaveMethod.Json)
        {
            bool fileExist = File.Exists(path);
            if (!fileExist) return null;

            string serializedData = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveState>(serializedData);
        }
        else if (saveMethod == SaveMethod.Json_PlayerPrefs)
        {
            if (!PlayerPrefs.HasKey(fileName))
            {
                Debug.Log(12);
                return null;
            }
            string serializedData = PlayerPrefs.GetString(fileName);
            return JsonUtility.FromJson<SaveState>(serializedData);
        }
        else
        {
            return null;
        }
    }

    public void DeleteFile()
    {
        string path = Application.persistentDataPath + "/" + saveMethod.ToString() + fileName;

        bool fileExist = File.Exists(path);
        if (fileExist)
        {
            File.Delete(path);
            Debug.Log("file deleted");
        }
        else
        {
            Debug.Log("no file found");
        }
    }
}

