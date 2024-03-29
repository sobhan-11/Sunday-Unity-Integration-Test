using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("LevelsData"), Space] 
    [SerializeField] private SO_LevelData levelData; // Read levels from level scriptableobject
    public int currentLevel=0; // Caching current level and using it for save and load later 

    [Header("Actions")] // Observe these actions for avoid dependencies
    public Action onLevelSuccess;
    public Action onLevelFail;

    // Creating Singelton Pattern For Accessing most usable objects through the game.
    private static LevelManager _instance;
    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        onLevelSuccess += LoadNextLevel;
        onLevelFail += LoadCurrentLevel;
    }

    private void OnDisable()
    {
        onLevelSuccess -= LoadNextLevel;
        onLevelFail -= LoadNextLevel;
    }

    #region HandleLevels
    
    private void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(levelData.levelScenes[currentLevel].name);
    }

    public void LoadCurrentLevel() => SceneManager.LoadScene(levelData.levelScenes[currentLevel].name);

    #endregion

}
