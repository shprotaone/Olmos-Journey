using UnityEngine;

public class GamePreferencesManager : MonoBehaviour
{
    [SerializeField] private SettingsSaver _settings;
    [SerializeField] private CommonScoreContainer _gameContainer;

    private void Start()
    {
        LoadPrefs();
        DeathScript.OnDeath += SavePrefs;
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("Music", _settings.Music);
        PlayerPrefs.SetFloat("SFX", _settings.SFX);
        PlayerPrefs.SetInt("Coins", _gameContainer.coin);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        float music = PlayerPrefs.GetFloat("Music", 0);
        float sfx = PlayerPrefs.GetFloat("SFX", 0);
        int coin = PlayerPrefs.GetInt("Coins", 0);

        if(_settings != null)
        {
            _settings.LoadSettings(music, sfx);
            _gameContainer.coin = coin;
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
