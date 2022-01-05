using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _higscoreTable;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _gameGuide;
    [SerializeField] private GameObject _shopTree;
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private GameObject _creditWindow;
    [SerializeField] private CurrentGameDataContainer _gameContainer;

    private int _idMainMenuScene = 0;
    private int _idGameScene = 1;

    private void Start()
    {
        if (_gameContainer.showGuideInStart && SceneManager.GetActiveScene().buildIndex != _idMainMenuScene)
            _gameGuide.SetActive(true);


    }

    public void Resume()
    {
        if (_pauseMenu != null)
            _pauseMenu.SetActive(false);       
        BackButton();
        TimeScaleController(true);
        Invoke("GamePauseStatus", 0.2f);
    }

    private void TimeScaleController(bool isActive)
    {
        if (isActive)
        {
            Time.timeScale = 1;
        }
        else
            Time.timeScale = 0;
    }

    public void Pause()
    {
        if (_pauseMenu != null)
            _pauseMenu.SetActive(true);
        _gameContainer.gameInPaused = true;
        TimeScaleController(false);
    }

    public void StartGame()
    {       
        TimeScaleController(true);
        SceneManager.LoadScene(_idGameScene);
    }

    public void LoadMainMenu()
    {
        TimeScaleController(true);
        SceneManager.LoadScene(_idMainMenuScene);       
    }

    public void Settings()
    {
        _settings.SetActive(true);
    }

    public void HighScore()
    {
        _higscoreTable.SetActive(true);
    }

    public void GameGuide()
    {
        _gameGuide.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        if (_higscoreTable != null)
            _higscoreTable.SetActive(false);

        if (_settings != null)
            _settings.SetActive(false);

        if (_gameGuide != null)
            _gameGuide.SetActive(false);

        if (_shopTree != null)
            _shopTree.SetActive(false);

        if (_creditWindow != null)
            _creditWindow.SetActive(false);
    }

    public void ConfirmExitWindow()
    {
        _shopTree.SetActive(true);
    }

    public void Guide()
    {
        _gameGuide.SetActive(true);        
    }

    public void DeathWindow()
    {
        _deathWindow.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void GamePauseStatus()
    {
        _gameContainer.gameInPaused = false;
    }
}
