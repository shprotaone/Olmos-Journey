using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour,IAction
{
    private CharacterController controller;
    private Vector3 direction = Vector3.zero;
    
    private float _distanceForDrop = 0.5f;    //1f
    private float _distanceForFly = 5f;
    private float _distanceToGround;

    private float _jumpSpeed;
    private float _gravity;
    private float _dropGravity;
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

        if (!fly)
        {
            direction.y -= _currentGravity * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);
        }  
    }

    public void Action()
    {
        if (_distanceToGround > _distanceForDrop && !fly)
        {
            _currentGravity = _dropGravity;
            print("Drop");
        }
        else if (fly)
        {
            FlyMeth();
        }
        else
        {
            JumpMeth();
            print("Jump");
        }
    }

    private void JumpMeth()
    {
        _currentGravity = _gravity;
        direction.y = _jumpSpeed;
    }

    private void FlyMeth()
    {
        if (_distanceToGround > _distanceForFly)
        {
            _currentGravity = 0;
        }
    }

    public IEnumerator ChangeGravityToFly()
    {
        fly = true;
        JumpMeth();
        yield return new WaitForSeconds(0.2f);
        FlyMeth();

        yield return new WaitForSeconds(5f);
        fly = false;
        _currentGravity = LoadBalance.gravity;

        yield break;
    }
}
