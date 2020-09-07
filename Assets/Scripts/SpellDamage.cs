using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    [SerializeField] int damage;

    public int SetDamage()
    {
        return damage;
    }
}
