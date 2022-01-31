using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAdsButton : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private Button _showAdButton;
    [SerializeField] private ContinueGameScript _continue;

    private string _androidAdUnitId = "Rewarded_Android";
    private string _adUnityId;


    private void Start()
    {
        _adUnityId = _androidAdUnitId;
        StartCoroutine(DelayLoadRewardedAds());
    }

    private IEnumerator DelayLoadRewardedAds()
    {
        yield return new WaitForSeconds(1f);
        LoadAd();
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(_adUnityId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
        }
    }

    private void LoadAd()
    {
        Advertisement.Load(_adUnityId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnityId, this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Complete");
            StartCoroutine(_continue.StartPlayDelay());

        }
        else
        {
            Debug.Log("Uncomplete");
        }

        StartCoroutine(DelayLoadRewardedAds());
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) 
    { 
        print(placementId + " " + error + " " + message);
    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    private void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners();
    }
}
