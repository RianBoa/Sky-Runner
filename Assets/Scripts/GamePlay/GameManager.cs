using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager 
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private ServerAPI serverManager;
    private PlayerBehaviour player;

    public event Action OnDead;

    public bool IsDead { get; private set; }

    private GameManager(ServerAPI serverManager, PlayerBehaviour player)
    {
        OnDead = () => { };

        this.serverManager = serverManager;
        this.player = player;

        IsDead = false;

        this.player.OnFallDawn += PlayerDeath;
    }

    public static void Init(ServerAPI serverManager, PlayerBehaviour player)
    {
        instance = new GameManager(serverManager, player);
    }

    public void PlayerDeath()
    {
        IsDead = true;
        OnDead.Invoke();
        //TODO: Remove timescale = 0, the game processes must be paused in other way
        Time.timeScale = 0f;  // Зупиняємо час у грі
    }

    public void SubmitScore(string playerName)
    {
        float disctance = player.transform.position.z;

        int playerScore = Mathf.FloorToInt(disctance);  // Використовуємо пройдену відстань як рахунок

        Debug.Log("Player Name: " + playerName);  
        Debug.Log("Player Score: " + playerScore);  

        serverManager.AddPlayer(playerName, playerScore);

        // Перезапуск гри або повернення в головне меню після успішного надсилання даних
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}