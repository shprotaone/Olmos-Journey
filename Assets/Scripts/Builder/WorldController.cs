using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private const float platformPoints = 15;

    public delegate void DelAndAddPlatform();
    public event DelAndAddPlatform OnPlatformMovement;

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
    public float CurrentSpeed { get { return _currentSpeed; } }
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
            Acceleration();
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
        }
    }

    private void AddPlatformPoint()
    {
        if(transform.position.z < -_platformLenght)
        {
            _platformLenght += platformPoints;
            //_scoreSystem.AddPoint(); - очки за дистанцию нужны?
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

    private void Acceleration()
    {
        if (_currentSpeed < _speedMax)
        {
            _currentSpeed += Time.deltaTime * _changeSpeedAcceleration;
        }
    }
}
