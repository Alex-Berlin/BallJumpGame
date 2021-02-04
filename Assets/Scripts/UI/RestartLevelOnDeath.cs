using BallJump.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallJump.UI
{
    public class RestartLevelOnDeath : MonoBehaviour
    {

        private void Update()
        {
            if (PlayerDeath.IsDead && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
