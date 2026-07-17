using UnityEngine;
using System;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine.SceneManagement;

public class JsonManager : MonoBehaviour
{
    TextAsset configPath;
    public static JsonManager Instance {get; private set;}

    public GameData gameData {get; set;}
    public PlayerData playerData {get; set;}

    public string saveFile;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        playerData = new PlayerData();
    }

    public GameData ReadGameConfig(string fileName)
    {
        configPath = Resources.Load<TextAsset>($"{fileName}");

        gameData = JsonUtility.FromJson<GameData>(configPath.text);

        return gameData;
    }

    public void CreateSaving()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "Saves");
        
        if(!Directory.Exists(saveFilePath))
            Directory.CreateDirectory(saveFilePath);

        string saveName = DateTime.Now.ToString("dd-MM-YYYY");

        saveFile = Path.Combine(saveFilePath, $"{saveName}.json");
    }

    public void DisplayEverySave()
    {
        
    }

    public void ReadPlayerData(string fileName)
    {
        string path = Path.Combine(saveFile, fileName);

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
    }

    public void SavePlayerData()
    {
        playerData.currentScene = SceneManager.GetActiveScene().buildIndex;
        playerData.currentHP = HpManager.Instance.remainingHealth;
        playerData.reachedProgress = GameProgress.Instance.currentProgress;
        playerData.reachedScore = GameProgress.Instance.currentScore;
        
        string json = JsonUtility.ToJson(gameData, true);

        File.WriteAllText(saveFile, json);
    }
}