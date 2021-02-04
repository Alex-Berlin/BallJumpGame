using UnityEngine;

namespace BallJump.Core
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] 
        private GameObject pauseMenu;
        [Tooltip("Button to open main menu")]
        [SerializeField]
        private GameObject menuButton;
        public static bool IsPaused { get; private set; }

        private void Start()
        {
            Pause();
        }

        public void Pause()
        {
            menuButton.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        public void Unpause()
        {
            menuButton.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
    }
}
