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

    public float currentProgress;
    public int currentScore;

    int score = 0;
    int minAmountScore;
    float progressToAdd;
    public static GameProgress Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        minAmountScore = JsonManager.Instance.gameData.minScore;
        progressToAdd = JsonManager.Instance.gameData.progressToAdd;
        
    }

    void Update()
    {
        CheckProgress();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
        
        currentScore = score;
    }

    public void UpdateProgressBar()
    {
        progressImage.fillAmount += progressToAdd;

        currentProgress = progressImage.fillAmount;
    }

    void CheckProgress()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(score >= minAmountScore && progressImage.fillAmount >= 0.05f)
            if(nextSceneIndex != 3)
                SceneManager.LoadScene(nextSceneIndex + 1);
            else
                SceneManager.LoadScene(0);
    }
}
