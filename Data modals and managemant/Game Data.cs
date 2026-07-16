using System;
using UnityEngine;

[Serializable]
public class GameData
{
    
}

[Serializable]
public class PlayerData
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
    }

    public Difficulty difficulty;
}