using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameID;
    [SerializeField] private bool _testMode;

    private string _gameId;

    private void Awake()
    {
        InitializedAds();

        Advertisement.Initialize(_gameId, _testMode);
    }

    private void InitializedAds()
    {
        _gameId = _androidGameID;
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Init Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(error.ToString() + " " + message);
    }
}
