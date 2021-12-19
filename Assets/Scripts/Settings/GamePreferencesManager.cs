using UnityEngine;

public class GamePreferencesManager : MonoBehaviour
{
    [SerializeField] private CommonSoundController _settings;
    [SerializeField] private CommonScoreContainer _gameContainer;

    private void Start()
    {
        DeathScript.OnDeath += SavePrefs;
        LoadPrefs();
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins", _gameContainer.commonCoin);
        PlayerPrefs.SetString("Sounds", _settings.SFX.ToString());
        PlayerPrefs.SetString("Music", _settings.Music.ToString());
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        int coin = PlayerPrefs.GetInt("Coins", 0);
        string sounds = PlayerPrefs.GetString("Sounds", "");
        string music = PlayerPrefs.GetString("Music", "");
        bool valueSounds, valueMusic;

        if(_settings!= null)
        {
            valueSounds = _settings.Convertation(sounds);
            valueMusic = _settings.Convertation(music);

            _settings.LoadSettings(valueMusic, valueSounds);
            _gameContainer.commonCoin = coin;
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
