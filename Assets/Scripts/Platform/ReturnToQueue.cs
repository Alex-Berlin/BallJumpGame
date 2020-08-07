using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToQueue : MonoBehaviour
{
    // returns object to POOL on TIMER seconds after enable.

    [SerializeField] private float timer = 10f;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            PlatformPool.Instance.ReturnToPool(gameObject);
        }
    }

}
