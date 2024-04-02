using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SO_LevelsData", menuName = "Data/Levels")]
public class SO_LevelData : ScriptableObject
{
    /*Use array of our levels , better create game object prefbs for levels and use them in one scene instead of
    using scene's name!*/
    public string[] levelScenes;
}