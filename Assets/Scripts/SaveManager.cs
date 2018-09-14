using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    public static SaveState saveState;

    private static string fileName = "_level_data.dat";
    private static SaveMethod saveMethod = SaveMethod.Json_PlayerPrefs;

    enum SaveMethod
    {
        Binary,
        Json,
        Json_PlayerPrefs
    }

    public static void Save()
    {
        SaveState data = saveState;

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

    public static void Load()
    {
        string path = Application.persistentDataPath + "/" + saveMethod.ToString() + fileName;

        if (saveMethod == SaveMethod.Binary && File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveState levelData = (SaveState)bf.Deserialize(file);
            file.Close();
            saveState = levelData;
        }
        else if (saveMethod == SaveMethod.Json && File.Exists(path))
        {
            string serializedData = File.ReadAllText(path);
            saveState = JsonUtility.FromJson<SaveState>(serializedData);
        }
        else if (saveMethod == SaveMethod.Json_PlayerPrefs && PlayerPrefs.HasKey(fileName))
        {
            string serializedData = PlayerPrefs.GetString(fileName);
            saveState = JsonUtility.FromJson<SaveState>(serializedData);
        }
        else
        {
            saveState = new SaveState();
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

