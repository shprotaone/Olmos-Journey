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
    
    private int _coinCounter;
    private int _scoreCounter;
    private int _distance;
    private int _giftCount;

    public int CurrentDistance { get { return _distance; } }
    public int Score { get { return _scoreCounter; } }

    private void Start()
    {
        HealthSystem.OnDeath += SaveScore;
    }

    private void Update()
    {
        _coinDisplay.text = _coinCounter.ToString();
    }

    public void CatchUpCoin()
    {
        _coinCounter += coinCost * _multiplyCoinScript.CoinMultiply;
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
        _commonContainer.coin += _coinCounter;

        HealthSystem.OnDeath -= SaveScore;
    }

    public void GiftCounter()
    {
        _giftCount++;
    }

    private void PrintResult()
    {
        _resultCoinDisplay.text = _coinCounter.ToString();
        _resultScore.text = _scoreCounter.ToString();
        _resultDistanceCovered.text = _distance.ToString();
    }
}
