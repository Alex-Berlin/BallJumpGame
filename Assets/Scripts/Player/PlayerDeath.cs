using System;
using BallJump.Dummies;
using UnityEngine;

namespace BallJump.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        public event Action OnDeath;
        public static bool isDead { get; private set; }

        private void Awake()
        {
            isDead = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<LevelBorder>() != null)
            {
                OnDeath?.Invoke();
                isDead = true;
            }
        }

    }
}
