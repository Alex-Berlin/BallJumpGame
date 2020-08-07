using UnityEngine;

public class DifficultyModifier : MonoBehaviour
{
    //linearly increases difficulty until reaching max at set timer

    [SerializeField] private float timeToMaxDifficulty = 60f; //in seconds
    private float currentTime;
    [SerializeField] private float difficultyMaxMod = 2f; //max multiplier for platform move speed
    public static float CurrentDifMod { get; private set; }

    private void Update()
    {
        currentTime = Mathf.Clamp01(Time.timeSinceLevelLoad / timeToMaxDifficulty);
        CurrentDifMod = Mathf.Lerp(1f, difficultyMaxMod, currentTime);
    }
}