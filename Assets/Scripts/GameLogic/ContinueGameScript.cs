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

    public IEnumerator StartPlayDelay()
    {
        _timerText.gameObject.SetActive(true);

        AnimationReset();
        _healthSystem.ResetHealth();

        int delay = 3;

        while (delay > 0)
        {
            yield return new WaitForSeconds(1f);
            delay--;
            _timerText.text = delay.ToString();
        }

        _worldController.ResetGameSpeed();

        _currentGameData.gameIsStarted = false;
        _currentGameData.death = false;

        _timerText.gameObject.SetActive(false);

        yield return null;
    }

    private void AnimationReset()
    {
        _animationController.AnimationDeath(false);
        _animationController.AnimationStartRunning(true);
        _backGroundController.ResumeScrolling();
    }


}
