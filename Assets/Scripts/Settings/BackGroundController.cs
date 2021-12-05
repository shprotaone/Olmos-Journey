using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private const string scrollName = "ScrollSpeed";
    private const string divideNumber = "DivideNumber";

    [SerializeField] private SpriteRenderer[] _materials;
    [SerializeField] private WorldController _worldController;

    private Vector2 _offsetSpeed;

    private float _firstLayerDivide;
    private float _secondLayerDivide;
    private float _thirdLayerDivide;
    private float _fourLayerDivide;

    private void Start()
    {
        _materials = GetComponentsInChildren<SpriteRenderer>();

        _firstLayerDivide = LoadBalance.divideFirstLayerBackground;
        _secondLayerDivide = LoadBalance.divideSecondLayerBackground;
        _thirdLayerDivide = LoadBalance.divideThirdLayerBackground;
        _fourLayerDivide = LoadBalance.divideFourLayerBackground;

        ScrollCalculate();
    }

    private void FixedUpdate()
    {
        _offsetSpeed = new Vector2 (_worldController.CurrentSpeed,0);

        foreach (var item in _materials)
        {
            item.material.SetVector("ScrollSpeed", _offsetSpeed);
        }
    }

    private void ScrollCalculate()
    {
        _materials[0].material.SetFloat(divideNumber, _firstLayerDivide);
        _materials[1].material.SetFloat(divideNumber, _secondLayerDivide);
        _materials[2].material.SetFloat(divideNumber, _thirdLayerDivide);
        _materials[3].material.SetFloat(divideNumber, _fourLayerDivide);
        _materials[4].material.SetFloat(divideNumber, _firstLayerDivide);
    }
}
