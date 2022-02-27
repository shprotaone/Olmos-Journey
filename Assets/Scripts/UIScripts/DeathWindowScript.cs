using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathWindowScript : MonoBehaviour
{
    [SerializeField] private GameObject _resultWindow;
    [SerializeField] private TMP_Text _timerText;
    private int _timer;

    private void OnEnable()
    {
        StartCoroutine(TimerCoroutine());
    }

    public void ContinueGame()
    {
        this.gameObject.SetActive(false);
        StopCoroutine(TimerCoroutine());
    }

    public void GameEnd()
    {
        this.gameObject.SetActive(false);
        _resultWindow.SetActive(true);
        Debug.Log("End Game");
    }

    private IEnumerator TimerCoroutine()
    {
        _timer = 10;

        while (_timer > 0)
        {
            _timer--;
            _timerText.text = _timer.ToString();
            yield return new WaitForSeconds(1f);
        }

        GameEnd();
        this.gameObject.SetActive(false);

        yield return null;
    }
}
