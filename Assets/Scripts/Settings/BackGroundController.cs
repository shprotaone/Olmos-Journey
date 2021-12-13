using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private const string scrollName = "ScrollSpeed";
    private const string divideNumberName = "DivideNumber";
    private const string timerName = "Timer";

    [SerializeField] private SpriteRenderer[] _materials;
    [SerializeField] private WorldController _worldController;

    private Vector2 _offsetSpeed;
    private Vector2 _basicSpeed;

    private float _firstLayerDivide;
    private float _secondLayerDivide;
    private float _thirdLayerDivide;
    private float _fourLayerDivide;

    private bool _baseSpeed = false;
    private bool _isStopped = false;

    private void Start()
    {
        _materials = GetComponentsInChildren<SpriteRenderer>();

        _basicSpeed.x = _worldController.MaxSpeed;

        _firstLayerDivide = LoadBalance.divideFirstLayerBackground;
        _secondLayerDivide = LoadBalance.divideSecondLayerBackground;
        _thirdLayerDivide = LoadBalance.divideThirdLayerBackground;
        _fourLayerDivide = LoadBalance.divideFourLayerBackground;

        DeathScript.OnDeath += StopBackGround;
        ScrollCalculate();
    }

    private void Update()
    {
        SetSpeed();
        print(_materials[0].material.mainTextureOffset);
    }

    private void SetSpeed()
    {
        if (!_isStopped)
        {
            if (_basicSpeed.x > _worldController.CurrentSpeed && _worldController.StartMovement && !_baseSpeed)
            {
                _offsetSpeed = new Vector2(_worldController.CurrentSpeed, 0);
            }
            else if (_basicSpeed.x <= _worldController.CurrentSpeed)
            {
                _baseSpeed = true;
                _offsetSpeed = _basicSpeed;
            }

            foreach (var item in _materials)
            {
                item.material.SetVector(scrollName, _offsetSpeed);
            }
        }     
    }

    private void ScrollCalculate()
    {
        _materials[0].material.SetFloat(divideNumberName, _firstLayerDivide);
        _materials[1].material.SetFloat(divideNumberName, _secondLayerDivide);
        _materials[2].material.SetFloat(divideNumberName, _thirdLayerDivide);
        _materials[3].material.SetFloat(divideNumberName, _fourLayerDivide);
        _materials[4].material.SetFloat(divideNumberName, _firstLayerDivide);
    }

    private void StopBackGround()
    {
        _isStopped = true;
    }
}
