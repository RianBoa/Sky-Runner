using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Canvas))]
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button submiteButton;

        public Canvas canvas;
        public InputField playerNameInput;  // ���� �������� ���� ������


        public void Init()
        {
            canvas.enabled = false;

            submiteButton.onClick.AddListener(OnSubminScroeClick);
            GameManager.Instance.OnDead += OnDeath;
        }

        public void OnDeath()
        {
            canvas.enabled = true;
        }

        public void OnSubminScroeClick()
        {
            GameManager.Instance.SubmitScore(playerNameInput.text);
        }

        private void OnDestroy() 
        {
            submiteButton.onClick.RemoveAllListeners();
            GameManager.Instance.OnDead -= OnDeath;
        }
    }
}