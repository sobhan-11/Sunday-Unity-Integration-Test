using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private LevelManager _levelManager;
    
    private void Awake()
    {
        _levelManager = LevelManager.instance;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerBall") // Better use tag except name 
        {
            MyEventSystem.I.FailLevel(_levelManager.currentLevel);
            _levelManager.onLevelFail?.Invoke();
        }
    }
    
    // public int currentLevel = 1;
    // public string sceneToLoad = "Level1";
}
