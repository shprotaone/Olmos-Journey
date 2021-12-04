using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private const int meterMultiplier = 4;

    [SerializeField] private int _snowflakesCounter;
    [SerializeField] private int _distance;
    [SerializeField] private int _giftCount;
    [SerializeField] private CommonScoreContainer _commonContainer;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _distanceDisplay;

    public int CurrentScore { get { return _snowflakesCounter; } }
    public int CurrentDistance { get { return _distance; } }
    public int CurrentGiftCount { get { return _giftCount; } }

    private void Update()
    {
        _scoreDisplay.text = _snowflakesCounter.ToString();
    }

    public void CatchUpPoint()
    {
        _snowflakesCounter += 1;
    }

    public void AddPoint()
    {
        _snowflakesCounter += 10;
    }

    public void SaveScore()
    {
        _commonContainer.score += _snowflakesCounter;
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
}
