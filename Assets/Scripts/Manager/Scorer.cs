using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    //Increase score on ground touch
    private int score = 0;
    [SerializeField] private Text scoreText;

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
