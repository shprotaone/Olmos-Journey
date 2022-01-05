﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;
    [SerializeField] private CurrentGameDataContainer _gameContainer;    
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _platformLayer;
       
    private CharacterController _characterController;
    private AnimationController _animController;

    private PlatformTypes _type;

    private SwipeDetection _swipeDetection;
    private DeathScript _deathScript;
    private Jump _jumpScript;

    private Vector3 _targetPosition;
    private float _leftPoint = -5;
    private float _centerPoint = 0;
    private float _rightPoint = 5;
    private float _speedMovement;
    private float _distanceToGround;

    private bool _left;
    private bool _right;

    public float DistanceToGround { get { return _distanceToGround; } }

    private void Start()
    {
        _swipeDetection = GetComponent<SwipeDetection>();
        _characterController = GetComponent<CharacterController>();
        _animController = GetComponentInChildren<AnimationController>();
        _deathScript = GetComponent<DeathScript>();
        _jumpScript = GetComponent<Jump>();

        _swipeDetection.SwipeEvent += OnSwipe;
        _swipeDetection.TouchEvent += OnTouch;
       
        _speedMovement = LoadBalance.movement;
    }

    private void Update()
    {   
        Movement();        
        CheckPlatform();

        if (_gameContainer.gameIsStarted && !_gameContainer.death)
        {
            _soundController.SlideSound(_characterController.isGrounded);
        }

        print(_targetPosition);
    }

    private void OnSwipe(Vector2 direction)
    {
        if (_gameContainer.gameIsStarted && !_gameContainer.death)
        {
            Turn(direction.x);
        }       
    }

    private void OnTouch(bool action)
    {
        if (!_gameContainer.guideActive)
        {
            if (!_gameContainer.gameIsStarted)
            {
                _gameContainer.gameIsStarted = true;
                _animController.AnimationStartRunning();                
            }
            else if (!_gameContainer.death)
                _jumpScript.Action();
        }       
    }

    private void Turn(float direction)
    {

        if (transform.position.x > _leftPoint + 1 && direction == 1 && !_left)    //починить края
        {
            _left = true;
            _right = false;
            _animController.AnimationLeft();
            _soundController.TurnSound();
        }
        else if (transform.position.x < _rightPoint - 1 && direction == -1 && !_right)
        {
            _right = true;
            _left = false;
            _animController.AnimationRight();
            _soundController.TurnSound();
        }
    }

    private void Movement()
    {
        float tmpDist = Time.deltaTime * _speedMovement;

        Vector3 movement = Vector3.MoveTowards(transform.position, _targetPosition, tmpDist) - transform.position ;

        movement.y = _jumpScript.JumpDirection.y * Time.deltaTime;      //Jump and Drop
       
        _characterController.Move(movement);

        if (_left)
        {
            _targetPosition.x += _leftPoint;
        }
        else if (_right)
        {
            _targetPosition.x += _rightPoint;
        }

        ResetPosition();
    }

    private void ResetPosition()
    {
        _right = false;
        _left = false;
    }

    public void Death()
    {       
        _deathScript.Action();
        _animController.AnimationDeath();
    }

    public void CheckPlatform()
    {
        Ray ray = new Ray(transform.position, Vector3.down * 6);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _platformLayer))
        {
            if (hit.transform.CompareTag("Platform"))
            {
                _distanceToGround = hit.distance;
            }

            _type = hit.transform.GetComponentInParent<PlatformController>().Type;

            if (_type == PlatformTypes.SHOOTPLATFORM)
            {
                hit.transform.GetComponentInParent<GiftLauncher>().LaunchGift(_shootPoint);
            }
        }
    }
}
