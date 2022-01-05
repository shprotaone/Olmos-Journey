using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithSubject : MonoBehaviour
{
    [SerializeField] private WorldController _worldController;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private MagnetScript _magnet;

    private Jump _jumpScript;

    private bool _activated;
    
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

    public void AddCoin()
    {
        _scoreSystem.CatchUpCoin();
        _scoreSystem.GiftCounter();
    }

    public void MultiplyCoin()
    {
        _scoreSystem.EnableMultiply();
    }

    public void MagnetActivate()
    {
        _magnet.EnableMagnet();
    }

    public void Gift(int num)
    {
        if(num == 0)
        {
            MultiplyCoin();
        }
        else if( num == 1)
        {
            MagnetActivate();
        }
        else if(num == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                AddCoin();
            }
        }
    }

}
