using UnityEngine;

namespace BallJump.Platform
{
    public class PlatformSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject platform;

        [Header("Between Spaces")] [SerializeField]
        private float betweenSpaceMin = 1.5f;

        [SerializeField] private float betweenSpaceMax = 4f;

        [Header("Platform's Length")] [SerializeField]
        private float platformLengthMinimum = 5f;

        [SerializeField] private float platformLengthMaximum = 15f;
        private float betweenPlatformSpace;
        private bool isPlatformOnBottom; //important to be false
        private GameObject lastSpawnedPlatform;
        private SpriteRenderer spriteRenderer;
        private float verticalOffset;

        private void Awake()
        {
            DetermineLength();
        }

        private void Update()
        {
            if (CheckIfTimeForSpawn())
            {
                Spawn();
                isPlatformOnBottom = !isPlatformOnBottom;
            }
        }

        private void Spawn()
        {
            DetermineVerticalPosition();
            DetermineBetweenSpaceLength();
            lastSpawnedPlatform = PlatformPool.Instance.Get();
            lastSpawnedPlatform.TryGetComponent(out spriteRenderer);
            lastSpawnedPlatform.transform.position
                = //POSITION, it spawns on spawner position + half platform length((---- x.pos + [--half lenght--|))
                new Vector3(transform.position.x + nextSpawnedPlatformLength / 2, verticalOffset, transform.position.z);
            spriteRenderer.size = //SCALE
                new Vector2(nextSpawnedPlatformLength, 5f);
            lastSpawnedPlatform.gameObject.SetActive(true);
            DetermineLength();
        }

        #region pre-spawn settings

        //returns true if it's time to spawn the platform
        private bool CheckIfTimeForSpawn()
        {
            if (lastSpawnedPlatform == null)
                //checks if platform was already spawned
                return true;
            //distance here is between ((half the platform length + random spacing between platforms)) and position of spawner
            //|--half of platform--] + |between space| <= x.position
            return lastSpawnedPlatform.transform.position.x + spriteRenderer.size.x / 2 + betweenPlatformSpace <=
                   transform.position.x;
        }

        private float nextSpawnedPlatformLength;

        private void DetermineLength()
        {
            nextSpawnedPlatformLength = Random.Range(platformLengthMinimum, platformLengthMaximum);
        }

        private void DetermineVerticalPosition()
        {
            if (isPlatformOnBottom)
                verticalOffset = -5;
            else
                verticalOffset = 5;
        }

        private void DetermineBetweenSpaceLength()
        {
            betweenPlatformSpace = Random.Range(betweenSpaceMin, betweenSpaceMax);
        }

        #endregion pre-spawn settings
    }
}