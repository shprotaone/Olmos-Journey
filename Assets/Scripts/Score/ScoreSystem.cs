using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private const int meterMultiplier = 4;
    private const int coinCost = 1;
    private const int oneMeterCost = 10;

    [SerializeField] private CommonScoreContainer _commonContainer;
    [SerializeField] private BonusDisplay _bonusDisplay;
    [SerializeField] private Sprite _spriteBonus;
    [SerializeField] private TMP_Text _coinDisplay;
    [SerializeField] private TMP_Text _resultCoinDisplay;
    [SerializeField] private TMP_Text _resultDistanceCovered;
    [SerializeField] private TMP_Text _resultScore;

    [SerializeField] private float _bonusActiveTime;

    private int _coinMultiply = 1;
    private int _coinCounter;
    private int _scoreCounter;
    private int _distance;
    private int _giftCount;

    private float _activeTime;
    
    public int CurrentCoin { get { return _coinCounter; } }
    public int CurrentDistance { get { return _distance; } }
    public int CurrentGiftCount { get { return _giftCount; } }
    public int Score { get { return _scoreCounter; } }

    private void Start()
    {
        DeathScript.OnDeath += SaveScore;
    }

    private void Update()
    {
        _coinDisplay.text = _coinCounter.ToString();
    }

    public void CatchUpCoin()
    {
        _coinCounter += coinCost * _coinMultiply;
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
        _commonContainer.coin += _coinCounter;
        PrintResult();
    }

    public void GiftCounter()
    {
        _giftCount++;
    }

    public IEnumerator MultiplyScore()
    {
        _coinMultiply = LoadBalance.scoreMultiplyBonusValue;
        GetComponent<AudioSource>().Play();

        print("CoinActivated");
        _bonusDisplay.BonusOn(_bonusActiveTime,_spriteBonus);

        yield return new WaitForSeconds(_bonusActiveTime);
        print("CoinDesactivated");
        _coinMultiply = 1;

        yield break;
    }

    private void PrintResult()
    {
        _resultCoinDisplay.text = _coinCounter.ToString();
        _resultScore.text = _scoreCounter.ToString();
        _resultDistanceCovered.text = _distance.ToString();
    }
}
