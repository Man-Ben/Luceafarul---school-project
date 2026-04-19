using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;
    
    public enum Progress
    {
        ZeroProgress,
        HaveAllCollectible,
        HaveMinimumScore
    }
    public Progress progress;

    public static GameProgress Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }
}
