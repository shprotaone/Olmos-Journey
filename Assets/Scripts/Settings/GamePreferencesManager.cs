using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreferencesManager : MonoBehaviour
{
    private const string _coinPrefsName = "Coins";
    private const string _soundsPrefsName = "Sounds";
    private const string _musicPrefsName = "Music";
    private const string _guidePrefsName = "GuideOn";
    private const string _currentCostPrefsName = "CurrentCost";
    

    public delegate void ResetSettings();
    public static event ResetSettings OnReset;

    [SerializeField] private CommonSoundController _soundController;
    [SerializeField] private CurrentGameDataContainer _currentGameContainer;
    [SerializeField] private GameSettings _gameSettings;

    private void Awake()
    {
        LoadPrefs();   
        Application.targetFrameRate = 75;
    }

    private void OnApplicationQuit()
    {
        SaveAllPrefs();
    }


    public void LoadPrefs()
    {
        int coin = PlayerPrefs.GetInt(_coinPrefsName, 0);
        string sounds = PlayerPrefs.GetString(_soundsPrefsName, "True");
        string music = PlayerPrefs.GetString(_musicPrefsName, "True");
        string showGuideInStart = PlayerPrefs.GetString(_guidePrefsName, "True");
        int currentCost = PlayerPrefs.GetInt(_currentCostPrefsName, 50);

        bool valueSfx, valueMusic,valueGuideInStart;

        if(_soundController != null)
        {
            valueSfx = Convertation(sounds);
            valueMusic = Convertation(music);
            valueGuideInStart = Convertation(showGuideInStart);

            _gameSettings.sfx = valueSfx;
            _gameSettings.music = valueMusic;

            _soundController.LoadSettings();
            _currentGameContainer.currentCost = currentCost;           
            _currentGameContainer.coin = coin;
            _currentGameContainer.showGuideInStart = valueGuideInStart;
        }
    }

    public void SaveAllPrefs()
    {
        PlayerPrefs.SetInt(_coinPrefsName, _currentGameContainer.coin);
        PlayerPrefs.SetString(_soundsPrefsName, _soundController.SFX.ToString());
        PlayerPrefs.SetString(_musicPrefsName, _soundController.Music.ToString());
        PlayerPrefs.SetString(_guidePrefsName, _currentGameContainer.showGuideInStart.ToString());
        PlayerPrefs.SetInt(_currentCostPrefsName, _currentGameContainer.currentCost);        
        PlayerPrefs.Save();
    }

    public void ResetPlayerPrefs()
    {
        OnReset?.Invoke();

        PlayerPrefs.DeleteAll();
        _gameSettings.sfx = false;
        _gameSettings.music = false;
        _currentGameContainer.coin = 0;
        _currentGameContainer.currentCost = 50;
        _currentGameContainer.buyedToys = 0;
        _currentGameContainer.showGuideInStart = true;
        
        PlayerPrefs.Save();

        SceneManager.LoadScene(0);
    }

    private bool Convertation(string value)
    {
        if (value == "True")
            return true;
        else return false;
    }
}
