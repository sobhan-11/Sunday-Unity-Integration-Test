using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTarget : MonoBehaviour
{
    private LevelManager _levelManager;
    
    private void Awake()
    {
        _levelManager = LevelManager.instance;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBall") // Better use tag except name 
        {
            MyEventSystem.I.CompleteLevel(_levelManager.currentLevelIndex + 1); 
            _levelManager.onLevelSuccess?.Invoke();
        }
    }
}
