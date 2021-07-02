using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class User
{
    public static SaveData data = new SaveData();
    public static bool alive = false;

    private static string savePath = Application.persistentDataPath + "/user.json";

    public static void CompleteLevel()
    {
        data.level++;
        UIMain.Instance.UpdateLevel();
    }

    public static void Spawn()
    {
        alive = true;

        Game.Instance.SpawnPlayer();
    }

    public static void Despawn()
    {
        alive = false;

        Game.Instance.DespawnPlayer();
    }

    public static void Load()
    {
        if (File.Exists(savePath))
        {
            StreamReader reader = new StreamReader(savePath, System.Text.Encoding.UTF8);
            SaveData saveData = JsonUtility.FromJson<SaveData>(reader.ReadToEnd());

            data.level = saveData.level;
            data.highscore = saveData.highscore;
            data.score = saveData.score;
            data.coin = saveData.coin;
            data.playerSkin = saveData.playerSkin;

            data.musicSound = saveData.musicSound;
            data.effectsSound = saveData.effectsSound;
            data.quality = saveData.quality;

            for (int i = 0; i < saveData.characters.Length && i < data.characters.Length; i++) 
                data.characters[i] = saveData.characters[i];
            for (int i = 0; i < saveData.upgrades.Length && i < data.upgrades.Length; i++) 
                data.upgrades[i] = saveData.upgrades[i];

            reader.Close();
        }
    }

    public static void Save()
    {
        StreamWriter writer = new StreamWriter(savePath, false, System.Text.Encoding.UTF8);
        writer.Write(JsonUtility.ToJson(data, true));
        writer.Close();
    }
}

[System.Serializable]
public class SaveData
{
    public int level = 1;
    public int highscore = 0;
    public int score = 0;
    public int coin = 25;
    public int playerSkin = 0;

    public bool musicSound = true;
    public bool effectsSound = true;
    public int quality = 0;

    public bool[] characters = new bool[(int)CharacterId.Count];
    public int[] upgrades = new int[(int)UpgradeId.Count];

    public SaveData()
    {
        characters[0] = true;
    }
}