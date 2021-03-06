using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private CurrentGameDataContainer _gameStats;

    public delegate void OnSwipeInput(Vector2 direction);
    public event OnSwipeInput SwipeEvent;

    public delegate void OnTouchInput(bool action);
    public event OnTouchInput TouchEvent;

    public float resetTimer;

    private Vector2 _startPosition;
    private Vector2 _swipeDelta;
    private Vector2 _endPosition;

    private float _deadZone = 50;

    private bool _isSwiping;
    private bool _isTouch;
    private bool _isMobile;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
        _gameStats.gameInPaused = false;
        ResetSwipe();
    }

    private void Update()
    {
        if (!_gameStats.gameInPaused)
        {
            Movement();
            CheckInput();
            
        }
    }
    
    private void Movement()
    {       
        if (!_isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {                  
                _startPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _endPosition = Input.mousePosition;
                Check();
            }           
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _startPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
                         Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _endPosition = Input.GetTouch(0).position;
                    Check();                   
                }
            }
        }
    }

    private void CheckInput()
    {
        _swipeDelta = Vector2.zero;

        if (_isTouch)
        {
            if (TouchEvent != null)
            {
                TouchEvent(_isTouch);

                ResetSwipe();
            }
        }
        else if (_isSwiping)
        {
            Swiping();
        }

        if (_swipeDelta.magnitude > _deadZone)
        {
            if(SwipeEvent != null)      //swipe ?????? ????????? Y
            {
                SwipeEvent(_swipeDelta.y > 0 ? Vector2.right : Vector2.left); //???????????? SwipeDelta ?????????????????? ????????????, ?????? ?????????????????????, ???????????? ??????????????????, ?????? ??????????????????. 
            }

            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        _isTouch = false;

        _startPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }

    private void Swiping()
    {      
        if (!_isMobile)
        {
            _swipeDelta = (Vector2)Input.mousePosition - _startPosition;
        }
        else if (Input.touchCount > 0)
        {
            _swipeDelta = Input.GetTouch(0).position - _startPosition;
        }
    }

    private void Check()
    {
        float magnitude = (_startPosition - _endPosition).magnitude;

        if (magnitude < 40)
        {
            _isTouch = true;
            _isSwiping = false;
        }
        else
        {
            _isSwiping = true;
            _isTouch = false;
        }
    }
}
