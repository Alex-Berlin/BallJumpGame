using BallJump.Player;
using UnityEngine;

namespace BallJump.Ads
{
    public class AdvertisementOnDeath : MonoBehaviour
    {
        private static int _deathCount;
        [SerializeField] private int deathCountToAdvertisement = 3;

        private void Awake()
        {
            FindObjectOfType<PlayerDeath>().OnDeath += AddToDeathCount;
        }
        private void AddToDeathCount()
        {
            _deathCount++;
            if (_deathCount < deathCountToAdvertisement) return;
            
            _deathCount = 0;
            ShowAdd();

        }

        private void ShowAdd()
        {
        }
    }
}
