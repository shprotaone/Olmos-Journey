using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    private AnimationController _animController;
    private Vector3 direction = Vector3.zero;
    
    private float _distanceForDrop = 0.5f;
    private float _distanceToGround;

    private float _jumpSpeed;
    private float _gravity;
    private float _dropGravity;
    private float _currentGravity;

    private bool fly;

    public Vector3 JumpDirection { get { return direction; } }

    private void Start()
    {
        _animController = GetComponent<AnimationController>();
        _jumpSpeed = LoadBalance.jumpForce;
        _gravity = LoadBalance.gravity;
        _dropGravity = LoadBalance.gravityToDrop;

        _currentGravity = _gravity;
    }

    private void Update()
    {
        _distanceToGround = GetComponent<PlayerController>().DistanceToGround;
        direction.y -= _currentGravity * Time.deltaTime;
    }

    public void Action()
    {
        if (_distanceToGround > _distanceForDrop && !fly)
        {
            _currentGravity = _dropGravity;            
        }
        else
        {
            _animController.JumpAnimation();
            JumpMeth();
        }
    }

    private void JumpMeth()
    {
        _currentGravity = _gravity;
        direction.y = _jumpSpeed;
    }
}
