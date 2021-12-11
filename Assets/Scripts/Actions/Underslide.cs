using System.Collections;
using UnityEngine;

public class Underslide : MonoBehaviour, IAction
{
    private CharacterController _characterController;

    private Vector3 _centerRoll = new Vector3(0, -0.3f, 0);
    private Vector3 _center;
    private float _heightRoll = 0.5f;
    private float _height;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _center = _characterController.center;
        _height = _characterController.height;
    }
    public void Action()
    {
        StartCoroutine(Slide());
        print("Action");
    }

    IEnumerator Slide()
    {
        _characterController.center = _centerRoll;
        _characterController.height = _heightRoll;

        yield return new WaitForSeconds(1f);

        _characterController.center = _center;
        _characterController.height = _height;

        yield break;
    }
}
