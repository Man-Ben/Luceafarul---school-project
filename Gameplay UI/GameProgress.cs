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
        //IMPORTANT: DO NOT FORGET TO CHANGE THE VALUE OF THE PROGRESS BAR'S FILL AMOUNT IN THE IF!!
        //IT WAS REDUCED FOR TESTING REASONS!!
        int minAmountScore = 100;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(score >= minAmountScore && progressImage.fillAmount == 0.25f)
            if(nextSceneIndex != 3)
                SceneManager.LoadScene(nextSceneIndex + 1);
            else
                SceneManager.LoadScene(0);
    }
}
