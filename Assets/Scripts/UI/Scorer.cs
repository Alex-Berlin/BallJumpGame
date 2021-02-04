using BallJump.Player;
using UnityEngine;
using UnityEngine.UI;

namespace BallJump.UI
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        //Increase score on ground touch
        private int score;

        private void Awake()
        {
            score = 0;
            if (scoreText != null)
            {
                FindObjectOfType<GroundChecker>().OnGroundTouch += IncreaseScore;
                scoreText.text = score.ToString("000");
            }
        }

        private void IncreaseScore()
        {
            score++;
            if (scoreText != null)
                scoreText.text = score.ToString("000");
        }
    }
}