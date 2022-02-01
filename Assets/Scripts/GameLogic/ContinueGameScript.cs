using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinueGameScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
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
