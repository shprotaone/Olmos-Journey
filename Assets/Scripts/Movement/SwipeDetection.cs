using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public delegate void OnSwipeInput(Vector2 direction);
    public static event OnSwipeInput SwipeEvent;

    public delegate void OnTouchInput(bool action);
    public static event OnTouchInput TouchEvent;

    public float resetTimer;

    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private Vector2 _startPosition;
    private Vector2 _endPosition;

    private float _deadZone = 80;

    private bool _isSwiping;
    private bool _isTouch;
    private bool _isMobile;

    private float _holdTime;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;       
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
                _tapPosition = Input.mousePosition;
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
                    _isSwiping = true;
                    _tapPosition = Input.GetTouch(0).position;
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

        if (_isSwiping)
        {
            Swiping();            
        }

        if (_isTouch)
        {
            if (TouchEvent != null)
            {
                TouchEvent(_isTouch); 
                
                ResetSwipe();
            }            
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

        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }

    private void Swiping()
    {      
        if (!_isMobile && Input.GetMouseButton(0))
        {
            _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
        }
        else if (Input.touchCount > 0)
        {
            _swipeDelta = Input.GetTouch(0).position - _tapPosition;
        }
    }

    private void Check()
    {
        if (_tapPosition == _endPosition)
        {
            _isTouch = true;
        }
        else
        {
            _isSwiping = true;
            _isTouch = false;
        }
    }
}
