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
       var asy = SceneManager.LoadSceneAsync("1");  // ��'� ����� � ��������
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void ViewLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");  // ��'� ����� � �������� �����
    }
}
