using UnityEngine;

public class Jump : MonoBehaviour,IAction
{
    [SerializeField] private float _jumpSpeed = 9;
    [SerializeField] private float _gravity = 5;

    private Vector3 direction = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.y -= _gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);        
    }

    public void Action(bool triggered)
    {
        if (triggered)
        {
           direction.y = _jumpSpeed;                     
        }
    }
}
