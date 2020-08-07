using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        FindObjectOfType<PlayerDeath>().OnDeath += ActivateDeathScreen;

    }

    private void ActivateDeathScreen()
    {
        if (deathScreen != null)
            deathScreen.SetActive(true);
    }
}
