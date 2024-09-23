using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "GameLevelSetup/PlayerSettingsObject", order = 2)]
public class PlayerSettings : ScriptableObject
{
    [Range(1f, 20f)]
    public float jumpForce = 10f;
    [Range(1f, 20f)]
    public float moveSpeed = 5f;
    [Range(-30f, 0f)]
    public float deathHeight = -10f;  // Висота, на якій гравець вмирає під час падіння
}
