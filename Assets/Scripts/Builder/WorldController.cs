using UnityEngine;
using System.Collections;
using TMPro;

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

    private float _platformLenght = 15;
    private float _difficultRange;
    private float _speedUpValue;
    private float _distance;
    private float _activeTime;

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

    public IEnumerator SpeedChanger(int speed)
    {
        float perTime = 1;
        _activeTime = 2;

        _speedMax += speed;

        while (_activeTime > 0)
        {
            _activeTime -= perTime;
            yield return new WaitForSeconds(1f);

        }

        _speedMax -= speed;

        yield break;
    }

    public void ResetGameSpeed()
    {
        _speedMax = LoadBalance.speed;
    }
}