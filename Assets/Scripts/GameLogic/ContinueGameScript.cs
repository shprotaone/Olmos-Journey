using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameScript : MonoBehaviour
{
    [SerializeField] private CurrentGameDataContainer _currentGameData;
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private WorldController _worldController;
    [SerializeField] private BackGroundControllerType2 _backGroundController;

    public void Continue()
    {
        _worldController.ResetGameSpeed();

        _backGroundController.ResumeScrolling();

        _currentGameData.gameIsStarted = false;
        _currentGameData.death = false;

        _healthSystem.ResetHealth();
        _animationController.AnimationDeath(false);
        _animationController.AnimationStartRunning(true); 

    }
}
