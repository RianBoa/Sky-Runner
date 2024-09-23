using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameeButton;
    [SerializeField] private Button leaderboardButton;
    public void Init()
    {
        startGameButton.onClick.AddListener(StartGame);
        startGameButton.onClick.AddListener(ExitGame);
        leaderboardButton.onClick.AddListener(ViewLeaderboard);
    }

    public void StartGame()
    {
       var asy = SceneManager.LoadSceneAsync("1");  // ²μ'ÿ ρφενθ η γειμολεΊμ
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void ViewLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");  // ²μ'ÿ ρφενθ η ςΰαλθφεώ λ³δεπ³β
    }
}
