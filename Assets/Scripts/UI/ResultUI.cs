using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private GameObject _result;
    [SerializeField] private GameObject _currentResult;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private CommonScoreContainer _commonScore;
    [SerializeField] private TMP_Text _distanceField;
    [SerializeField] private TMP_Text _giftCountField;
    [SerializeField] private TMP_Text _totalScoreField;
    [SerializeField] private TMP_Text _commonScoreField;

    public void ResultEnable()
    {
        _result.SetActive(true);
        _currentResult.SetActive(false);
        FillResult();
    }

    private void FillResult()
    {
        _distanceField.text = _scoreSystem.CurrentDistance.ToString() + " m";
        _giftCountField.text = _scoreSystem.CurrentGiftCount.ToString();
        _totalScoreField.text = _scoreSystem.CurrentCoin.ToString();
        _commonScoreField.text = _commonScore.coin.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
