using UnityEngine;

public class MenuLevelEntryPoint : MonoBehaviour
{
    [SerializeField] private MainMenuScreen mainMenuScreen;
    private void Awake()
    {
        mainMenuScreen.Init();
    }
}
