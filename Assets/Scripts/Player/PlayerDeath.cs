using System;
using BallJump.Dummies;
using UnityEngine;

namespace BallJump.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        public static bool IsDead { get; private set; }

        private void Awake()
        {
            IsDead = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<LevelBorder>() == null) return;

            OnDeath?.Invoke();
            IsDead = true;
        }

        public event Action OnDeath;
    }
}