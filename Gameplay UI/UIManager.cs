using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("Menus")]
    [SerializeField] GameObject gameOvermenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject confirmPopUp;

    [Space]

    [Header ("Menu buttons")]
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button pauseButtonMobile;
    [SerializeField] Button yesButton;
    [SerializeField] Button cancelButton;

    public enum GameState
    {
        Neutral,
        Paused,
        GameOver
    }

    [Space]
    
    [Header ("State")]
    public GameState gameState;

    public static UIManager Instance {get; private set;}

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
        {
            pauseButtonMobile.gameObject.SetActive(true);
            pauseButtonMobile.onClick.AddListener(OnPauseButtonClicked);
        }     
    }

    void Update()
    {
        OnEscPressed();
    }

    void AddListenerToUI()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        yesButton.onClick.AddListener(OnYesButtonClicked);
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    public void GameOver()
    {
            gameOvermenu.SetActive(true);
            quitButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            gameState = GameState.GameOver;    
    }

    void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnQuitButtonClicked()
    {
        if(gameState == GameState.Paused)
            pauseMenu.SetActive(false);
        else
            if(gameState == GameState.GameOver)
                gameOvermenu.SetActive(false);
        
        confirmPopUp.SetActive(true);
        quitButton.gameObject.SetActive(false);
    }

    void OnEscPressed()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameState != GameState.GameOver)
        {
            pauseMenu.SetActive(true);
            quitButton.gameObject.SetActive(true);
            gameState = GameState.Paused;
        }
    }

    void OnPauseButtonClicked()
    {
        pauseMenu.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameState = GameState.Paused;

        pauseButtonMobile.gameObject.SetActive(false);
    }

    void OnResumeButtonClicked()
    {
        pauseMenu.SetActive(false);
        quitButton.gameObject.SetActive(false);

        if(!pauseButtonMobile.gameObject.activeInHierarchy)
            pauseButtonMobile.gameObject.SetActive(true);
    
        gameState = GameState.Neutral;
    }

    void OnYesButtonClicked()
    {
        JsonManager.Instance.SavePlayerData();

        SceneManager.LoadScene(0);
    }

    void OnCancelButtonClicked()
    {
        if(gameState == GameState.Paused)
            pauseMenu.SetActive(true);
        else
            if(gameState == GameState.GameOver)
                gameOvermenu.SetActive(true);

        quitButton.gameObject.SetActive(true);
        confirmPopUp.SetActive(false);
    }

}
