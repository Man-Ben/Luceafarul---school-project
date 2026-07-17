using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public int maxHP;
    public int minScore;
    public float progressToAdd;
}

[Serializable]
public class PlayerData
{
    public string difficulty;

    public int reachedScore;
    public float reachedProgress;
    public int currentHP;
    public int currentScene;
}