using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithSubject : MonoBehaviour
{
    [SerializeField] private WorldController _worldController;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private MagnetScript _magnet;

    private Jump _jumpScript;
    
    private void Start()
    {
        _jumpScript = GetComponent<Jump>();
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(_worldController.SpeedUp());
    }

    public void DecreaseSpeed()
    {
        StartCoroutine(_worldController.SpeedDown());
    }

    public void MultiplyCoin()
    {
        StartCoroutine(_scoreSystem.MultiplyScore());
    }

    public void MagnetActivate()
    {
        StartCoroutine(_magnet.MagnetActivate());
    }

    public void Fly()
    {
        StartCoroutine(_jumpScript.ChangeGravity());
    }

}
