using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private CommonScoreContainer _commonScore;
    [SerializeField] private GameObject _restartButton;

    private void Start()
    {
        if (_scoreText != null)
        _scoreText.text = _commonScore.coin.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
