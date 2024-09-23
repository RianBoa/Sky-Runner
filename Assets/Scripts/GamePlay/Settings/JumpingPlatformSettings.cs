using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSettings", menuName = "GameLevelSetup/PlatformSettingsObject", order = 1)]
public class JumpingPlatformSettings : ScriptableObject
{
    [Space]
    public GameObject platformPrefab;
    public GameObject bonusPrefab;

    [Space]
    [Min(0)]
    public float minPlatformSpacing = 5f; // ̳������� ������� �� �����������
    [Min(0)]
    public float maxPlatformSpacing = 15f; // ����������� ������� �� �����������

    [Space]
    [Range(-5, 0)] public float minPlatformHeight = -2f; // ̳������� ������ ��������
    [Range(0, 5)] public float maxPlatformHeight = 2f; // ����������� ������ ��������

    [Space]
    [Range(0, 1)]
    public float bonusSpawnChance = 0.5f; // ��������� ������ ������

    public void IsSettingsValid()
    {

    }
}
