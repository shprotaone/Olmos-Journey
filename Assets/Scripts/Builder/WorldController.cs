using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private const float platformPoints = 15;

    public delegate void DelAndAddPlatform();
    public event DelAndAddPlatform OnPlatformMovement;

    public delegate void SpeedIncrease();
    public event SpeedIncrease OnIncrease;

    [SerializeField] private float _speedMax;
    [SerializeField] private float _changeSpeedAcceleration = 5;    //это нужно будет добавить в баланс
    [SerializeField] private float _currentSpeed = 0;

    [SerializeField] private PlatformBuilder _platformBuilder;
    [SerializeField] private ScoreSystem _scoreSystem;

    private float _platformLenght = 15; // переделать на точку end? 
    private float _difficultRange;
    private float _speedUpValue;
    private float _distance;

    public float MinZ { get { return -10; } }
    public float Distance { get { return _distance; } }
    public float MaxSpeed { get { return _speedMax; } }
    public bool StartMovement { get; set; }

    private void Start()
    {
        _speedMax = LoadBalance.speed;
        _speedUpValue = LoadBalance.increaseSpeed;
        _difficultRange = LoadBalance.distanceToUpDifficult;

        StartCoroutine(OnPlatformMovementCorutine());
    }

    private void Update()
    {
        if (StartMovement)
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
            yield return new WaitForSeconds(2f);
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
            if(OnIncrease != null)
            {
                OnIncrease();
            }            
        }
    }

    private void AddPlatformPoint()
    {
        if(transform.position.z < -_platformLenght)
        {
            _platformLenght += platformPoints;
            _scoreSystem.AddPoint();
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
            _currentSpeed += Time.deltaTime * _changeSpeedAcceleration;
        }
        else
        {
            _currentSpeed -= Time.deltaTime * _changeSpeedAcceleration;
        }
    }

    public IEnumerator SpeedUp()
    {
        _speedMax += LoadBalance.speedBonusValue;
        print("SpeedUp");
        yield return new WaitForSeconds(5f);
        _speedMax -= LoadBalance.speedBonusValue;
        print("SpeedDown");

        yield break;
    }

    public IEnumerator SpeedDown()
    {
        _speedMax -= LoadBalance.stopBonusValue;
        print("SpeedUp");
        yield return new WaitForSeconds(5f);
        _speedMax += LoadBalance.stopBonusValue;
        print("SpeedDown");

        yield break;
    }
}
