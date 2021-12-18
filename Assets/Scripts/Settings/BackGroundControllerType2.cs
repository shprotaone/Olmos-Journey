using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControllerType2 : MonoBehaviour
{
    [SerializeField] private WorldController _worldController;

    [SerializeField] private float _additionalScrollSpeed;

    [SerializeField] private GameObject[] _backgrounds;

    [SerializeField] private float[] _scrollSpeed;

    private float _mainSpeed;
    private float _timer;
    private bool _mainSpeedOK = false;
    private bool _isStopped;

    private void Start()
    {
        _timer = 0;
        _mainSpeed = LoadBalance.speed;
        _isStopped = false;
        DeathScript.OnDeath += StopSrolling;
    }

    private void FixedUpdate()
    {
        if (!_mainSpeedOK)
        {
            StartingScrolling();
        }
        _timer += Time.deltaTime;

        if (!_isStopped)
        {
            for (int i = 0; i < _backgrounds.Length; i++)
            {
                Renderer rend = _backgrounds[i].GetComponent<Renderer>();

                float offset = _timer * (_scrollSpeed[i] / 1000 * _additionalScrollSpeed);

                rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
    }

    public void StartingScrolling()
    {
        if (_worldController != null)
        {
            _additionalScrollSpeed = _worldController.CurrentSpeed;

            if (_worldController.CurrentSpeed > _mainSpeed)
            {
                _additionalScrollSpeed = _mainSpeed;
                _mainSpeedOK = true;
            }

        }            
        else
            _additionalScrollSpeed = 1;      
    }

    public void StopSrolling()
    {
        _isStopped = true;
    }
}
