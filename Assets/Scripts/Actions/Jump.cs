using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour,IAction
{
    private float _jumpSpeed;
    private float _gravity;
    private float _dropGravity;

    private Vector3 direction = Vector3.zero;
    private CharacterController controller;
    private float _distanceToGround;

    private float _distanceForJump = 0.2f;
    private float _distanceForDrop = 1f;    //1f
    private float _distanceForFly = 5f;
    private float _currentGravity;

    private bool fly;

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
        _distanceToGround = controller.GetComponent<PlayerController>().DistanceToGround;

        direction.y -= _currentGravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        if (_distanceToGround > _distanceForFly && fly)
        {
            direction.y = 5;
            controller.Move(direction * Time.deltaTime);
        }
    }

    public void Action(bool triggered)
    {       
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

    public IEnumerator ChangeGravity()
    {
        fly = true;
        _gravity = 4;

        Action(true);

        yield return new WaitForSeconds(10f);
        fly = false;
        _gravity = LoadBalance.gravity;

        yield break;
    }
}
