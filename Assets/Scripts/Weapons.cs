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
    [SerializeField] float damage = 1f;
    [SerializeField] ParticleSystem arrowShot;
    [SerializeField] GameObject hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayShootingEffect();
        ProcessRaycast();

    }

    private void PlayShootingEffect()
    {
        arrowShot.Play();
    }

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
