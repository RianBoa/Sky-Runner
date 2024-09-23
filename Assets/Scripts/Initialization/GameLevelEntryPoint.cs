using Assets.Scripts.UI;
using Assets.Scripts.Utilities;
using UnityEngine;

public class GameLevelEntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private MainLevelUI mainLevelUI;
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private GameMapController platformManager;

    //ServerAPI serverAPI;

    private void Awake()
    {
        if (player == null) Debug.LogError($"SET {typeof(PlayerBehaviour).Name} REFFERENCE ON GameLevelEntryPoint");
        if (inputController == null) Debug.LogError($"SET {typeof(PlayerInputController).Name} REFFERENCE ON GameLevelEntryPoint");
        if (mainLevelUI == null) Debug.LogError($"SET {typeof(MainLevelUI).Name} REFFERENCE ON GameLevelEntryPoint");
        if (coroutineRunner == null) Debug.LogError($"SET {typeof(CoroutineRunner).Name} REFFERENCE ON GameLevelEntryPoint");
        if (platformManager == null) Debug.LogError($"SET {typeof(GameMapController).Name} REFFERENCE ON GameLevelEntryPoint");

        //TODO: make serverAPI non MonoBeh
        //serverAPI = new();
        ServerAPI.Init(coroutineRunner);

        GameManager.Init(ServerAPI.Instance, player);
        ScoreManager.Init();

        mainLevelUI.Init();

        platformManager.Init(player);

        player.Init(inputController);
    }
}
