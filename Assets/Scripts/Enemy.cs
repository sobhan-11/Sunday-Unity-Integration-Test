using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int currentLevel = 1;
    public string sceneToLoad = "Level1";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerBall")
        {
            MyEventSystem.I.FailLevel(currentLevel);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
