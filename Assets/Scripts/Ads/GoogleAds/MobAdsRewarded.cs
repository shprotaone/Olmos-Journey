using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MobAdsRewarded : MonoBehaviour
{
    [SerializeField] private ContinueGameScript _continueGameScript;
    [SerializeField] private GameObject _resultWindow;

    private RewardedAd _rewardedAd;

    private string _rewardedUnitId = "ca-app-pub-6017936447497960/8117894091";

    private bool _loadError = false;

    private void OnEnable()
    {
        _rewardedAd = new RewardedAd(_rewardedUnitId);

        AdRequest adRequest = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(adRequest);

        _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        _rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
    }

    private void OnDisable()
    {
        _rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        _rewardedAd.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
    }

    public void ShowAd()
    {
        if (_rewardedAd.IsLoaded())
        {
            _rewardedAd.Show();
        }

        if (_loadError)
        {
            _continueGameScript.DeathWindowScript.GameEnd();
        }        
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        _loadError = true;
    }


    private void HandleUserEarnedReward(object sender, Reward args)
    {
        _continueGameScript.Continue();
    }
}
