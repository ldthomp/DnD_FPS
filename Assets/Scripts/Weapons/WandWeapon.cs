using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class WandWeapon : MonoBehaviour
{
    [SerializeField] GameObject wandSpellPrefab;
    [SerializeField] Transform wandParent;
    [SerializeField] Ammo manaSlot;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(ProcessFire());
        }
    }

    IEnumerator ProcessFire()
    {
        canShoot = false;
        if (manaSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            FireProjectile();
            manaSlot.ReduceCurrentAmmo(ammoType);
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }

        void FireProjectile()
        {
            GameObject spell = Instantiate(wandSpellPrefab, wandParent.position, wandParent.rotation);
            spell.transform.parent = wandParent;
            Destroy(spell, 2f);
        }
    }
}
