using UnityEngine;
using TMPro;

public class RecordConfirmer : MonoBehaviour
{
    [SerializeField] private HighscoreTable _highscoreTable;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GamePreferencesManager _gameRef;

    private string _dataScore;

    public void SaveScore()
    {
        string currentData;

        currentData = System.DateTime.Today.ToString("d");

        _dataScore = currentData;
        _highscoreTable.AddHighscoreEntry(_scoreSystem.Score, _scoreSystem.CurrentDistance, _dataScore);       
        _highscoreTable.gameObject.SetActive(true);

        GlobalSave();
    }

    private void GlobalSave()
    {
        _gameRef.SavePrefs();
    }
}
