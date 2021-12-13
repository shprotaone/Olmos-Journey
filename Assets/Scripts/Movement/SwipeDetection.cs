using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    public delegate void OnSwipeInput(Vector2 direction);
    public static event OnSwipeInput SwipeEvent;

    public delegate void OnTouchInput(bool action);
    public static event OnTouchInput TouchEvent;

    public float resetTimer;

    public Text text1;
    public Text text2;
    public Text text3;

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
        ResetSwipe();
    }

    private void Update()
    {       
        Movement();
        CheckInput();
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
            if(SwipeEvent != null)      //swipe по оси Y
            {
                SwipeEvent(_swipeDelta.y > 0 ? Vector2.right : Vector2.left);  //менять тут если не будет работать
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
        text1.text = _startPosition.ToString();
        text2.text = _endPosition.ToString();
        text3.text = "_isTouch = " + _isTouch.ToString();

        if (_startPosition == _endPosition)
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
