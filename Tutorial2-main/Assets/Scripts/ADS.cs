using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour, IUnityAdsListener
{
    public string GooglePlayUserID;
    public string AppStoreUserID;

    public float AdsDelay;

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            StartCoroutine(adsDelay());
#if UNITY_ANDROID
            Advertisement.Initialize(GooglePlayUserID, false);
#elif UNITY_IOS
            Advertisement.Initialize(AppStoreUserID, false);
#endif
            Advertisement.AddListener(this);
        }
    }
    public void ShowADSVideo()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
    }
    public void ShowADSRewardedVideo()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }

    public IEnumerator adsDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(AdsDelay);
            ShowADSVideo();
        }
    }
    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        
        if (showResult == ShowResult.Finished) 
        {
            if (surfacingId == "rewardedVideo")
            {
                FindObjectOfType<EnergyManager>().energyCount = 100;
                FindObjectOfType<EnergyManager>().UpdateValues();
            }
        } else if (showResult == ShowResult.Skipped) {
            Debug.Log("Skip");
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }
}
