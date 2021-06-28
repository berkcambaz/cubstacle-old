using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int level;
    public int highscore;
    public int score;
    public int coin;
    public int playerSkin;

    public bool music;
    public bool effects;
    public int quality;

    public List<bool> characters;
    public List<int> upgrades;

    public static SaveData Load()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/user.save";
        SaveData saveData = new SaveData();
        FileStream stream;

        if (File.Exists(path))
        {
            try
            {
                stream = new FileStream(path, FileMode.Open);
                saveData = (SaveData)formatter.Deserialize(stream);
            }
            catch
            {
                stream = new FileStream(path, FileMode.Create);
            }
        }
        else
        {
            stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, saveData);
        }
        stream.Close();

        return saveData;
    }

    public static void Save(SaveData _saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/user.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, _saveData);
        stream.Close();
    }
}