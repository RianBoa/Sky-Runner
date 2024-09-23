using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSettings", menuName = "GameLevelSetup/PlatformSettingsObject", order = 1)]
public class JumpingPlatformSettings : ScriptableObject
{
    [Space]
    public GameObject platformPrefab;
    public GameObject bonusPrefab;

    [Space]
    [Min(0)]
    public float minPlatformSpacing = 5f; // Мінімальна відстань між платформами
    [Min(0)]
    public float maxPlatformSpacing = 15f; // Максимальна відстань між платформами

    [Space]
    [Range(-5, 0)] public float minPlatformHeight = -2f; // Мінімальна висота платформ
    [Range(0, 5)] public float maxPlatformHeight = 2f; // Максимальна висота платформ

    [Space]
    [Range(0, 1)]
    public float bonusSpawnChance = 0.5f; // Ймовірність спавну бонуса

    public void IsSettingsValid()
    {

    }
}
