using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithSubject : MonoBehaviour
{
    [SerializeField] private WorldController _worldController;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private MultiplyCoinScript _multiplyCoinScript;
    [SerializeField] private MagnetScript _magnet;

    public void IncreaseSpeed()
    {
        StartCoroutine(_worldController.SpeedChanger(LoadBalance.speedBonusValue));
    }

    public void DecreaseSpeed()
    {
        StartCoroutine(_worldController.SpeedChanger(LoadBalance.stopBonusValue));
    }

    public void AddCoin()
    {
        _scoreSystem.CatchUpCoin();
    }

    public void MultiplyCoin()
    {
        _multiplyCoinScript.EnableMultiply();
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
