using UnityEngine;

namespace BallJump.Platform
{
    public class ReturnToQueue : MonoBehaviour
    {
        // returns object to POOL on TIMER seconds after enable.

        [SerializeField] private float timer = 10f;
        private float currentTime;

        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timer) PlatformPool.Instance.ReturnToPool(gameObject);
        }

        private void OnEnable()
        {
            currentTime = 0f;
        }
    }
}