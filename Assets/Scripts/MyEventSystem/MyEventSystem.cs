using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;
using GameAnalyticsSDK;
                        

public class MyEventSystem : MonoBehaviour
{
    public static MyEventSystem I;

    private void Awake()
    {
        I = this;
        GameAnalytics.Initialize();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void StartLevel(int level)
    {
        // Game Analytics
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
        // Firebase Analytics
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelStart,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
    
    public void FailLevel(int level)
    {
        // Game Analytics
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
        // Firebase Analytics
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelEnd,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
    
    public void CompleteLevel(int level)
    {
        // Game Analytics
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
        // Firebase Analytics
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
}
