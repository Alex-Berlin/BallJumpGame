using BallJump.Player;
using UnityEngine;

namespace BallJump.UI
{
    public class PlayerDeathScreen : MonoBehaviour
    {
        [SerializeField] private GameObject deathScreen;

        private void Awake()
        {
            FindObjectOfType<PlayerDeath>().OnDeath += ActivateDeathScreen;
        }

        private void ActivateDeathScreen()
        {
            if (deathScreen != null)
                deathScreen.SetActive(true);
        }
    }
}