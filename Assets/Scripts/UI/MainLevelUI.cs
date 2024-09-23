using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MainLevelUI : MonoBehaviour
    {
        [SerializeField] private GameOverScreen gameOverScreen;
        [SerializeField] private ScoreScreen scoreScreen;

        public void Init()
        {
            gameOverScreen.Init();
            scoreScreen.Init();
        }
    }
}