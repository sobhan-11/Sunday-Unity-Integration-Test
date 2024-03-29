using System;
using System.Collections;
using System.Collections.Generic;
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
    }
    
    public void FailLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
    }
    
    public void CompleteLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
    }
}
