using UnityEngine;

[CreateAssetMenu(fileName = "GameLevelSettings", menuName = "GameLevelSetup/GameLevelSettingsObject", order = 0)]
public class GameLevelSettings : ScriptableObject
{
    public int initialNumberOfPlatforms = 5; // Кількість початкових платформ

    public float firstPlatformLength = 20f;

    public Vector3 spawnPosition = new Vector3(0, 0, 0);
}
