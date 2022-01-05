using UnityEngine;

public class GamePreferencesManager : MonoBehaviour
{
    [SerializeField] private CommonSoundController _settings;
    [SerializeField] private CurrentGameDataContainer _gameContainer;

    private void Start()
    {
        LoadPrefs();   
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins", _gameContainer.coin);
        PlayerPrefs.SetString("Sounds", _settings.SFX.ToString());
        PlayerPrefs.SetString("Music", _settings.Music.ToString());
        PlayerPrefs.SetString("GuideOn", _gameContainer.showGuideInStart.ToString());
        PlayerPrefs.SetInt("CurrentCost", _gameContainer.currentCost);
        PlayerPrefs.SetInt("BuyedToysCounter", _gameContainer.buyedToys);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        int coin = PlayerPrefs.GetInt("Coins", 0);
        int currentCost = PlayerPrefs.GetInt("CurrentCost", 200);
        int buyedToysCounter = PlayerPrefs.GetInt("BuyedToysCounter", 0);
        string sounds = PlayerPrefs.GetString("Sounds", "");
        string music = PlayerPrefs.GetString("Music", "");
        string showGuideInStart = PlayerPrefs.GetString("GuideOn", "");
        bool valueSounds, valueMusic,valueGuideInStart;

        if(_settings != null)
        {
            valueSounds = _settings.Convertation(sounds);
            valueMusic = _settings.Convertation(music);
            valueGuideInStart = _settings.Convertation(showGuideInStart);

            _settings.LoadSettings(valueMusic, valueSounds);
            _gameContainer.currentCost = currentCost;
            _gameContainer.buyedToys = buyedToysCounter;
            _gameContainer.coin = coin;
            _gameContainer.showGuideInStart = valueGuideInStart;
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
