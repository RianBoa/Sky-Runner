using System;
using UnityEngine;

public class ScoreManager
{
    private static ScoreManager instance;
    public static ScoreManager Instance => instance;

    public int Score { get; private set; }

    public event Action<int> OnScoreChange;

    private ScoreManager() 
    {  
        Score = 0;
        OnScoreChange = (int s) => { }; 
    }

    public static void Init()
    {
        instance = new ScoreManager();
    }

    public void AddScore(int value)
    {
        Debug.Log("Adding score: " + value);
        Score += value;
        OnScoreChange.Invoke(Score);
    }
}