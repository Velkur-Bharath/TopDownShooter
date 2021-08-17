using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour,IUnityAdsListener
{
    string placement = "rewardedVideo";
    public static bool shottgun=false;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3614528", true);
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            shottgun = true;
            //AudioListener.pause;
        }
        else if (showResult == ShowResult.Failed)
        {
            //shottgun = false;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }
}
