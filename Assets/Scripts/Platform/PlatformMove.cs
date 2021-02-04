using BallJump.Core;
using UnityEngine;

namespace BallJump.Platform
{
    public class PlatformMove : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 50f)] private float speed = 12.5f;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.MovePosition(transform.position + Vector3.left * (speed * Time.fixedDeltaTime * DifficultyModifier.CurrentDifMod));
        }
    }
}