﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;

    public void TakeDamage (float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0f)
        {
            print("destroying" + gameObject.name);
            Destroy(gameObject);
        }
    }
}
