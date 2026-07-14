using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameProgress : MonoBehaviour
{
    [Header ("Texts")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Space]
    [Header ("Progress Bars")]
    [SerializeField] Image progressImage;

    int score;
    
    public enum Progress
    {
        ZeroProgress,
        HaveAllCollectibles,
        HaveMinimumScore
    }

    [Space]

    [Header("Game Progress")]

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
        CheckProgress();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void UpdateProgressBar()
    {
        progressImage.fillAmount += 0.25f;
    }

    void CheckProgress()
    {
        int minAmountScore = 1000;

        if(score == minAmountScore && progressImage.fillAmount == 1.0f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
