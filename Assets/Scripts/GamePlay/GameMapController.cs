using UnityEngine;

public class GameMapController : MonoBehaviour
{
    [SerializeField] private JumpingPlatformSettings platformSettings;
    [SerializeField] private GameLevelSettings gameSettings;

    private PlayerBehaviour player;

    private int platformsPassed = 0; // Лічильник пройдених платформ

    private Vector3 currentSpawnPos;

    public void Init(PlayerBehaviour player)
    {
        this.player = player;
        currentSpawnPos = gameSettings.spawnPosition;

        // Генерація початкових платформ
        SpawnStarterPlatform();
    }

    private void SpawnStarterPlatform()
    {
        var firstPlatform = Instantiate(platformSettings.platformPrefab, currentSpawnPos, Quaternion.identity);
        for (int i = 0; i < gameSettings.initialNumberOfPlatforms; i++)
        {
            SpawnPlatform(true);
        }
    }

    private void Update()
    {
        if (CanSpanNewPlatform()) SpawnPlatform();
    }

    private bool CanSpanNewPlatform()
    {
        return player.transform.position.z > currentSpawnPos.z;
    }

    private void SpawnPlatform(bool initial = false)
    {
        Debug.Log("Spawn Platform. Is Initial: " + initial);

        // Генерація випадкових параметрів платформи
        float platformHeight = Random.Range(platformSettings.minPlatformHeight, platformSettings.maxPlatformHeight);
        float platformSpacing = Random.Range(platformSettings.minPlatformSpacing, platformSettings.maxPlatformSpacing);

        // Створення нової платформи
        Vector3 platformPosition = new Vector3(currentSpawnPos.x, platformHeight, currentSpawnPos.z + platformSpacing);
        var platform = Instantiate(platformSettings.platformPrefab, platformPosition, Quaternion.identity);

        // Збільшення лічильника пройдених платформ і збільшення швидкості гравця
        if (!initial) player.IncreaseSpeed(platformsPassed);

        // Спавн бонуса з певною ймовірністю
        TryToSpawnBonus(platformPosition);

        // Оновлення позиції для наступної генерації платформи
        currentSpawnPos = platformPosition;

        if (!initial) platformsPassed++;
    }

    private bool TryToSpawnBonus(Vector3 platformPosition)
    {
        if (Random.value < platformSettings.bonusSpawnChance)
        {
            Vector3 bonusPosition = platformPosition + new Vector3(0, 1, 0); // Позиція бонуса над платформою
            Instantiate(platformSettings.bonusPrefab, bonusPosition, Quaternion.identity);
            return true;
        }

        return false;
    }

   
}
