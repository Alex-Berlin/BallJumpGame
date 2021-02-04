using System;
using UnityEngine;

namespace BallJump.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class GroundChecker : MonoBehaviour
    {
        //Checks whether the player touches ground or not. 

        public event Action OnGroundTouch;
        public bool isGrounded = false;
        [Tooltip("Enable time delay till ground leave registers.")]
        [SerializeField] private bool coyoteTimeEnabled; //coyote time adds a little bit of time for player to tap after they ran off the platform, making the game more forgiving
        [SerializeField] private float coyoteTime = 0.05f; //in seconds
        private bool cancelCoyote = true;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isGrounded = true;
            cancelCoyote = true;
            OnGroundTouch?.Invoke();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (coyoteTimeEnabled)
            {
                cancelCoyote = false;
                Invoke(nameof(ToggleGroundedToFalse), coyoteTime); 
            } else
            {
                isGrounded = false;
            }

        }

        private void ToggleGroundedToFalse()
        {
            if (cancelCoyote) return; //already on ground, no need to toggle
            isGrounded = false;
        }




    }
}