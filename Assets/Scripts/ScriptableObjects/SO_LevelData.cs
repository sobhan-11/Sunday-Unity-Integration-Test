using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SO_LevelsData", menuName = "Data/Levels")]
public class SO_LevelData : ScriptableObject
{
    public SceneAsset[] levelScenes; // Use array of our levels
}