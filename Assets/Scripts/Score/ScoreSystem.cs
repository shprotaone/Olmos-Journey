using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private const int meterMultiplier = 4;
    private const int coinCost = 1;
    private const int oneMeterCost = 10;
    private const int indexDisplay = 1;

    [SerializeField] private CommonScoreContainer _commonContainer;
    [SerializeField] private BonusDisplay _bonusDisplay;
    [SerializeField] private Sprite _spriteBonus;
    [SerializeField] private TMP_Text _coinDisplay;
    [SerializeField] private TMP_Text _resultCoinDisplay;
    [SerializeField] private TMP_Text _resultDistanceCovered;
    [SerializeField] private TMP_Text _resultScore;

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
        GetComponent<AudioSource>().Play();
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
        PrintResult();

        DeathScript.OnDeath -= SaveScore;
    }

    public void GiftCounter()
    {
        _giftCount++;
    }

    public IEnumerator MultiplyScore()
    {
        _coinMultiply = LoadBalance.scoreMultiplyBonusValue;
        _activeTime += 5;
        float perTime = 1f;
        
        GetComponent<AudioSource>().Play();

        _bonusDisplay.BonusOn(indexDisplay,_activeTime, _spriteBonus);

        while (_activeTime>0)
        {
            _activeTime -= perTime;
            yield return new WaitForSeconds(1f);
        }

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
