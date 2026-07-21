using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class JsonManager : MonoBehaviour
{
    TextAsset configPath;

    string saveFilePath;

    public string saveFile;
    public List<string> savings;

    public static JsonManager Instance {get; private set;}

    public GameData gameData {get; set;}
    public PlayerData playerData {get; set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        playerData = new PlayerData();

        saveFilePath = Path.Combine(Application.persistentDataPath, "Saves");

        if(!Directory.Exists(saveFilePath))
            Directory.CreateDirectory(saveFilePath);
    }

    public GameData ReadGameConfig(string fileName)
    {
        configPath = Resources.Load<TextAsset>($"{fileName}");

        gameData = JsonUtility.FromJson<GameData>(configPath.text);

        return gameData;
    }

    public void CreateSaving()
    {   
        string saveName = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");

        saveFile = Path.Combine(saveFilePath, $"{saveName}.json");
    }

    public void GetEverySave()
    {
        string[] files = Directory.GetFiles(saveFilePath, "*.json");

        foreach(string file in files)
            savings.Add(Path.GetFileNameWithoutExtension(file));
    }


    public void ReadPlayerData(string fileName)
    {
        string path = Path.Combine(saveFilePath, fileName);

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
    }

    public void SavePlayerData()
    {
        playerData.reachedScene = SceneManager.GetActiveScene().buildIndex;

        if(UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            playerData.currentHP = HpManager.Instance.remainingHealth;
            playerData.reachedScore = GameProgress.Instance.currentScore;
            playerData.reachedProgress = GameProgress.Instance.currentProgress;
        }
        
        string json = JsonUtility.ToJson(playerData, true);

        string path = Path.Combine(saveFilePath, saveFile);

        File.WriteAllText(path, json);
    }

    public void DeleteFile(string fileName)
    {
        string path = Path.Combine(saveFilePath, fileName);
        
        File.Delete(path);
    }
}