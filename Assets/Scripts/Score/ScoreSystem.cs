using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private CurrentGameDataContainer _commonContainer;
    [SerializeField] private MultiplyCoinScript _multiplyCoinScript;
    [SerializeField] private TMP_Text _coinDisplay;
    [SerializeField] private TMP_Text _resultCoinDisplay;
    [SerializeField] private TMP_Text _resultDistanceCovered;
    [SerializeField] private TMP_Text _resultScore;

    private const int meterMultiplier = 4;
    private const int coinCost = 1;
    private const int oneMeterCost = 10;
    
    private int _scoreCounter;
    private int _distance;

    public int CurrentDistance { get { return _distance; } }
    public int Score { get { return _scoreCounter; } }

    private void Start()
    {
        _commonContainer.coinCollected = 0;
        _coinDisplay.text = _commonContainer.coinCollected.ToString();
        HealthSystem.OnDeath += SaveScore;
    }

    public void CatchUpCoin()
    {
        _commonContainer.coinCollected += coinCost * _multiplyCoinScript.CoinMultiply;
        _coinDisplay.text = _commonContainer.coinCollected.ToString();
    }

    public void AddPointScore()
    {
        _scoreCounter += oneMeterCost;
    }

    public void AddDistance(int distance)
    {
        _distance = distance / meterMultiplier;
    }

    public void SaveScore()
    {
        PrintResult();
        _commonContainer.coin += _commonContainer.coinCollected;    
    }

    private void PrintResult()
    {
        _resultCoinDisplay.text = _commonContainer.coinCollected.ToString();
        _resultScore.text = _scoreCounter.ToString();
        _resultDistanceCovered.text = _distance.ToString();
    }

    private void OnDisable()
    {
        HealthSystem.OnDeath -= SaveScore;
    }
}
