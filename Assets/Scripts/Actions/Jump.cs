using UnityEngine;

public class Jump : MonoBehaviour,IAction
{
    private float _jumpSpeed;
    private float _gravity;
    private float _dropGravity;

    private Vector3 direction = Vector3.zero;
    private CharacterController controller;

    private float _distanceForJump = 0.2f;
    private float _distanceForDrop = 1f;
    private float _currentGravity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _jumpSpeed = LoadBalance.jumpForce;
        _gravity = LoadBalance.gravity;
        _dropGravity = LoadBalance.gravityToDrop;

        _currentGravity = _gravity;
    }

    private void Update()
    {
        direction.y -= _currentGravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);        
    }

    public void Action(bool triggered)
    {
        float _distanceToGround = controller.GetComponent<PlayerController>().DistanceToGround;

        if (triggered)
        {
            if( _distanceToGround < _distanceForJump)
            {
                _currentGravity = _gravity;
                direction.y = _jumpSpeed;
            }
            else if(_distanceToGround > _distanceForDrop)
            {
                _currentGravity = _dropGravity;
            }
        }
    }
}
