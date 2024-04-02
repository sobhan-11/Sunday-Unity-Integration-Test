using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("LevelsData"), Space] 
    [SerializeField] private SO_LevelData levelData; // Read levels from level scriptableobject
    public int currentLevelIndex = 0; // Caching current level and using it for save and load later 

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
        // Use this code for remove frame rate cap on strong devices and have better fps in them instead of limited 60! 
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
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
        currentLevelIndex++;
        if (currentLevelIndex >= levelData.levelScenes.Length) // Check For if player played all of our game levels and restart game
            currentLevelIndex = 0;
        SceneManager.LoadScene(levelData.levelScenes[currentLevelIndex]);
    }

    public void LoadCurrentLevel() => SceneManager.LoadScene(levelData.levelScenes[currentLevelIndex]);

    #endregion

}
