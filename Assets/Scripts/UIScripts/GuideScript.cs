using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour
{
    [SerializeField] private CurrentGameDataContainer _gameManager;
    [SerializeField] private Toggle _showMeGuideInStart;

    private void Start()
    {
        _showMeGuideInStart = GetComponentInChildren<Toggle>();

        _gameManager.guideActive = _gameManager.showGuideInStart;
    }

    public void ChangeShowGuideInStart()
    {
        _gameManager.showGuideInStart = false;
    }

    public void DisableGuideActiveState()
    {
        StartCoroutine(Activator());
    }

    private IEnumerator Activator()
    {
        yield return new WaitForSeconds(0.2f);

        _gameManager.guideActive = false;

        yield return null;
    }

}
