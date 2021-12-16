using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _higscoreTable;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _gameGuide;
    [SerializeField] private GameObject _confirmExit;
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private CommonScoreContainer _gameContainer;

    private int _idMainMenuScene = 0;
    private int _idGameScene = 1;

    public void Resume()
    {
        if (_pauseMenu != null)
            _pauseMenu.SetActive(false);
        _gameContainer.paused = false;
        BackButton();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if (_pauseMenu != null)
            _pauseMenu.SetActive(true);
        _gameContainer.paused = true;
        Time.timeScale = 0f; 
    }

    public void StartGame()
    {
        Resume();
        SceneManager.LoadScene(_idGameScene);
    }

    public void LoadMainMenu()
    {      
        Resume();    
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

        if (_confirmExit != null)
            _confirmExit.SetActive(false);
    }

    public void ConfirmExitWindow()
    {
        _confirmExit.SetActive(true);
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
}
