using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Main : MonoBehaviour
{
    private BannerView bannerView;
    void Start()
    {
#if UNITY_ANDROID
//        string appId = "ca-app-pub-3940256099942544~3347511713";
        string appId = "ca-app-pub-1246753635915961~2196132351";
#elif UNITY_IPHONE
                string appId = "あなたのiOS アプリID";
#else
                string appId = "unexpected_platform";
#endif

        //コメントアウトしても良い
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    AdRequest request;
    private void RequestBanner()
    {
#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        string adUnitId = "ca-app-pub-1246753635915961/3031536020";
#elif UNITY_IPHONE
                string adUnitId = "あなたのiOS バナーユニットID";
#else
                string adUnitId = "unexpected_platform";
#endif

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }
}