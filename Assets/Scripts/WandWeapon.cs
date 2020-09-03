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


    //[SerializeField] ParticleSystem arrowShot; Taken out for bow weapon. May need back for other weapons
    bool canShoot = true;

    void Start()
    {

    
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
        if (manaSlot.GetCurrentAmmo() >= 1)
        {
            FireProjectile();
            manaSlot.ReduceCurrentAmmo();
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
        else
        {
            Debug.Log("shooting disabled. out of ammo");
        }

        void FireProjectile()
        {
           GameObject spell = Instantiate(wandSpellPrefab, wandParent.position, wandParent.rotation);
            spell.transform.parent = wandParent;
            Destroy(spell, 2f);
        }
    }

}
