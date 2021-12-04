using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private const float speedUpValue = 3;
    private const float platformPoints = 15;

    public delegate void DelAndAddPlatform();
    public event DelAndAddPlatform OnPlatformMovement;

    [SerializeField] private float _speedMax = 1;
    [SerializeField] private float _changeSpeed = 0.01f;
    [SerializeField] private float _currentSpeed = 0;
    [SerializeField] private float _smoothLenght = 5;
    [SerializeField] private PlatformBuilder _platformBuilder;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GameObject _speedUpUI;

    private float _difficultRange = -200;
    private float _platformLenght = 15;
    private float _distance;

    public float MinZ { get { return -10; } }
    public float Distance { get { return _distance; } }
    public bool StartMovement { get; set; }

    private void Start()
    {
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
            yield return new WaitForSeconds(1f);
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
            _speedMax += speedUpValue;
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
            _currentSpeed += Time.deltaTime * _changeSpeed;
        }
    }

    private IEnumerator BlinkSpeedUPUI()
    {
        for (int i = 0; i < 2; i++)
        {
            _speedUpUI.SetActive(true);

            yield return new WaitForSeconds(1);

            _speedUpUI.SetActive(false);

            yield return new WaitForSeconds(1);
        }

        yield break;
    }
}
