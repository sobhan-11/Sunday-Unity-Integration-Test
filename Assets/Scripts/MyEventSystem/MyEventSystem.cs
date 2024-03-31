using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;
using GameAnalyticsSDK;  /* We need to create an assembly definition reference in game analytics folder for it */
                        

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
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelStart,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
    
    public void FailLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelEnd,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
    
    public void CompleteLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
                new Parameter(FirebaseAnalytics.ParameterLevel, level));
    }
}
