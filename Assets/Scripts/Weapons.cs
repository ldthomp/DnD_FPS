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
    [SerializeField] float damage = 25f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] GameObject weaponProjectile;
    [SerializeField] Transform weaponProjectileSpawn;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float shootForce = 20f;

    //[SerializeField] ParticleSystem arrowShot; Taken out for bow weapon. May need back for other weapons
    bool canShoot = true;

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
        if (ammoSlot.GetCurrentAmmo() >=1)
        {
            FireProjectile();
            //PlayShootingEffect(); temp took out - could serializefield to instantiate different effect for each weapon
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
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
            Rigidbody rigidBody = getProjectile.GetComponent<Rigidbody>();
            rigidBody.velocity = FPcamera.transform.forward * shootForce;
        }
    }


    //private void PlayShootingEffect()
    //{
    //    arrowShot.Play();
    //}

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            //todo add some hit effect
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .2f);
    }
}
