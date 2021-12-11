using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private CommonScoreContainer _commonContainer;
    [SerializeField] private TMP_Text _coinDisplay;
    [SerializeField] private TMP_Text _distanceDisplay;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _resultCoinDisplay;

    private const int meterMultiplier = 4;

    private int _snowflakesCounter;
    private int _scoreCounter;
    private int _distance;
    private int _giftCount;
    private int _scoreMultiply = 1;

    public int CurrentCoin { get { return _snowflakesCounter; } }
    public int CurrentDistance { get { return _distance; } }
    public int CurrentGiftCount { get { return _giftCount; } }
    public int Score { get { return _scoreCounter; } }

    private void Update()
    {
        _coinDisplay.text = _snowflakesCounter.ToString();
        _scoreDisplay.text = Score.ToString();
    }

    public void CatchUpPoint()
    {
        _snowflakesCounter += 1;
    }

    public void AddPoint()
    {
        _scoreCounter += 10 * _scoreMultiply;
        _resultCoinDisplay.text = _snowflakesCounter.ToString();
    }

    public void SaveScore()
    {
        _commonContainer.coin += _snowflakesCounter;
        _commonContainer.score += _scoreCounter;
    }

    public void AddDistance(int distance)
    {
        _distance = distance / meterMultiplier;
        _distanceDisplay.text = _distance + " m";
    }

    public void GiftCounter()
    {
        _giftCount++;
    }

    public IEnumerator MultiplyScore()
    {
        _scoreMultiply = LoadBalance.scoreMultiplyBonusValue;
        yield return new WaitForSeconds(5f);
        _scoreMultiply = 1;

        yield break;
    }
}
