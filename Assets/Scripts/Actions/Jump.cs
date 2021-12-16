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

        direction.y -= _currentGravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
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
            direction.y = _distanceForFly;
            controller.Move(direction * Time.deltaTime);
        }
        else
        {
            _currentGravity = _gravity;
            direction.y = _jumpSpeed;
            print("Jump");
        }
    }

    public IEnumerator ChangeGravityToFly()
    {
        fly = true;
        _gravity = 4;

        Action();

        yield return new WaitForSeconds(10f);
        fly = false;
        _gravity = LoadBalance.gravity;

        yield break;
    }
}
