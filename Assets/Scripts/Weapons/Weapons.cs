using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float range = 100f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GameObject weaponProjectile;
    [SerializeField] Transform weaponProjectileSpawn;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float shootForce = 20f;

    //[SerializeField] ParticleSystem arrowShot; Taken out for bow weapon. May need back for other weapons
    bool canShoot = true;
    private void OnEnable()
    {
        canShoot = true;
    }
    void Start()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            FireProjectile();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
        else
        {
            Debug.Log("shooting disabled. out of ammo");
        }

        void FireProjectile()
        {
            GameObject getProjectile = Instantiate(weaponProjectile, weaponProjectileSpawn.position, Quaternion.identity);
            Debug.Break();
            Rigidbody rigidBody = getProjectile.GetComponent<Rigidbody>();
            rigidBody.velocity = FPcamera.transform.forward * shootForce;
        }
    }
}
