﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAddOnDeathCount : MonoBehaviour
{
    private static int deathCount;
    [SerializeField] private int deathCountToAdvertisment = 3;

    private void Awake()
    {
        GameObject.FindObjectOfType<PlayerDeath>().OnDeath += AddToDeathCount;
    }
    private void AddToDeathCount()
    {
        deathCount++;
        if (deathCount >= deathCountToAdvertisment)
        {

            deathCount = 0;
            ShowAdd();
        }

    }

    private void ShowAdd()
    {
    }
}
