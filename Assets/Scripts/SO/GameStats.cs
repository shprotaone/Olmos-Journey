using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Enemy", menuName = "CreateGameStats", order = 53)]
public class GameStats : ScriptableObject
{
    public event Action<bool> OnDeath;

    [SerializeField] private float _score = 0;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _coin = 0;
    [SerializeField] private bool _playerIsDeath = false;
    
    private float _inGameTime;
    private bool _gameInPause = false;

    public float InGameTime { get { return _inGameTime; } set { _inGameTime = value; } }
    public bool GameInPause { get { return _gameInPause; } set { _gameInPause = value; } }
    public bool PlayerIsDeath { get { return _playerIsDeath; } }
    public float Score { get { return _score; } }

    public void Restart()
    {       
        _score = 0;
        _playerIsDeath = false;
        _gameInPause = false;
        InGameTime = 0;
    }

    public void AddScore(float score)
    {
        this._score += score;
    }

    public void PlayerDeathInv(bool state)
    {
        if (OnDeath != null)
        {            
            OnDeath.Invoke(state);
            _playerIsDeath = true;
        }
    }
}
