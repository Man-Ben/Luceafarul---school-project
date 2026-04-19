using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOvermenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject confirmPopUp;

    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button pauseButtonMobile;
    [SerializeField] Button yesButton;
    [SerializeField] Button cancelButton;

    public enum GameState
    {
        Resumed,
        Paused,
        GameOver
    }

    public GameState gameState;

    public static UIManager Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AddListenerToUI();

        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.isEditor)
            pauseButtonMobile.gameObject.SetActive(true);
    }

    void Update()
    {
        GameOver();
        OnEscPressed();
    }

    void AddListenerToUI()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        pauseButtonMobile.onClick.AddListener(OnPauseButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
    }

    void GameOver()
    {
        if(PlayerController.Instance.playerState == PlayerController.PlayerState.Death)
        {
            gameOvermenu.SetActive(true);
            quitButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            gameState = GameState.GameOver;
        }
            
    }

    void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnQuitButtonClicked()
    {
        confirmPopUp.SetActive(true);
    }

    void OnEscPressed()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameState != GameState.GameOver)
        {
            pauseMenu.SetActive(true);
            quitButton.gameObject.SetActive(true);
            pauseButtonMobile.gameObject.SetActive(false);
            gameState = GameState.Paused;
        }
    }

    void OnPauseButtonClicked()
    {
        pauseMenu.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameState = GameState.Paused;
    }

    void OnResumeButtonClicked()
    {
        pauseMenu.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseButtonMobile.gameObject.SetActive(true);
        gameState = GameState.Resumed;
    }

    void OnYesButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    void OnCancelButtonClicked()
    {
        confirmPopUp.SetActive(false);
    }

}
