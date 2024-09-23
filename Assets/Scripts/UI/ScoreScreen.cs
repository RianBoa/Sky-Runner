using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ScoreScreen : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        public void Init()
        {
            scoreText.text = "0";

            ScoreManager.Instance.OnScoreChange += OnScoreChange;
        }

        private void OnScoreChange(int value)
        {
            scoreText.text = value.ToString();
        }
    }
}