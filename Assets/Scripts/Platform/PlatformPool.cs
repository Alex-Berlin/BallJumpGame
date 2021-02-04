using System.Collections.Generic;
using UnityEngine;

namespace BallJump.Platform
{
    public class PlatformPool : MonoBehaviour
    {
        //***********************//
        // This component creates an object pool for PLATFORMS and manages their reusing.
        // Get() method used for getting the reference for the first platform in queue.
        // ReturnToPool() method returns the game object back to queue and deactivates it.
        // It's called on timer on the ReturnToQueue component, but you should call it instead of usual Destroy() method.
        //***********************//

        [SerializeField] private GameObject platformPrefab;
        [SerializeField] private int count = 5;
        private Queue<GameObject> platforms = new Queue<GameObject>();
        public static PlatformPool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            CreatePlatforms(count);
        }

        //create queue of PLATFORM objects with COUNT amount
        private void CreatePlatforms(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newPlatform = Instantiate(platformPrefab, transform);
                newPlatform.gameObject.SetActive(false);
                platforms.Enqueue(newPlatform);
            }
        }

        //returns used objects to pool
        public void ReturnToPool(GameObject platform)
        {
            platform.gameObject.SetActive(false);
            platforms.Enqueue(platform);
        }

        //returns first platform in queue and dequeues it
        public GameObject Get()
        {
            if (platforms.Count == 0)
            {
                CreatePlatforms(1);
            }

            return platforms.Dequeue();
        }
    }
}