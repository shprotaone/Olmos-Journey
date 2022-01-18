using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private const float platformPoints = 15;

    public delegate void DelAndAddPlatform();
    public event DelAndAddPlatform OnPlatformMovement;

    [SerializeField] private float _speedMax;
    [SerializeField] private float _acceleration = 5;    //это нужно будет добавить в баланс
    [SerializeField] private float _currentSpeed = 0;

    [SerializeField] private PlatformBuilder _platformBuilder;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private CurrentGameDataContainer _gameContainer;

    private float _platformLenght = 15; // переделать на точку end? 
    private float _difficultRange;
    private float _speedUpValue;
    private float _distance;
    private float _activeTime;

    private bool _speedDownActivate;
    private bool _speedMaxActivate;


    public float MinZ { get { return -60; } }
    public float CurrentSpeed { get { return _currentSpeed; } }

    private void Start()
    {
        _speedMax = LoadBalance.speed;
        _speedUpValue = LoadBalance.increaseSpeed;
        _difficultRange = LoadBalance.distanceToUpDifficult;
        _gameContainer.gameIsStarted = false;

        StartCoroutine(OnPlatformMovementCorutine());
    }

    private void Update()
    {
        if (_gameContainer.gameIsStarted && !_gameContainer.death)
        {
            SpeedController();
            transform.position -= Vector3.forward * _currentSpeed * Time.deltaTime;
        }

        DificultUp();
        AddPlatformPoint();
        DistanceCalculate();
    }

    private IEnumerator OnPlatformMovementCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (OnPlatformMovement != null)
            {
                OnPlatformMovement();
            }
        }
    }

    public void CreatePlatform()
    {
        _platformBuilder.CreateNextPlatform();
    }

    private void DificultUp()
    {
        if (transform.position.z < _difficultRange)
        {
            _speedMax += _speedUpValue;
            _difficultRange += _difficultRange;
        }
    }

    private void AddPlatformPoint()
    {
        if (transform.position.z < -_platformLenght)
        {
            _platformLenght += platformPoints;      //сомнительная система, но пока так 
            _scoreSystem.AddPointScore();
        }
    }

    private void DistanceCalculate()
    {
        if (_scoreSystem != null)
        {
            _distance = transform.position.z;
            _scoreSystem.AddDistance(-(int)_distance);
        }
        else
        {
            print("Check Distance Calculate");
        }
    }

    private void SpeedController()
    {
        if (_currentSpeed < _speedMax)
        {
            _currentSpeed += Time.deltaTime * _acceleration;
        }
        else
        {
            _currentSpeed -= Time.deltaTime * _acceleration;
        }
    }

    public void SpeedChanger(float speed)
    {
        _speedMax += speed;
    }

    public IEnumerator SpeedUp()        //повторяющтйся код, починить
    {
        float perTime = 1;
        _activeTime = 5;

        if (!_speedMaxActivate)
        {
            SpeedChanger(LoadBalance.speedBonusValue);
            _speedMaxActivate = true;
        }

        print(_speedMax);

        while (_activeTime > 0)
        {
            _activeTime -= perTime;
            yield return new WaitForSeconds(1f);

        }
        _speedMaxActivate = false;

        _speedMax -= LoadBalance.speedBonusValue;

        yield break;
    }

    public IEnumerator SpeedDown()
    {
        float perTime = 1;
        _activeTime = 5;

        if (!_speedDownActivate)
        {
            SpeedChanger(LoadBalance.stopBonusValue);
            _speedDownActivate = true;
        }

        while (_activeTime > 0)
        {
            _activeTime -= perTime;           
            yield return new WaitForSeconds(1f);
            
        }
        _speedDownActivate = false;

        _speedMax -= LoadBalance.stopBonusValue;

        yield break;
    }
}