using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] float damage = 50f;

    void Update()
    {
        if (canShoot == true)
        {
            if (Input.GetMouseButton(0) && canShoot == true) // while left click is held down
            {
                GetComponent<Animator>().SetBool("CanAttack", true);
            }
            if (Input.GetMouseButtonUp(0)) // when left click is released
            {
                GetComponent<Animator>().SetBool("CanAttack", false);
            } // move back to idle state
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide (name) : " + collision.gameObject.name);
        EnemyHealth target = collision.transform.GetComponent<EnemyHealth>();
        if (target == null) return;
        target.TakeDamage(damage);
    }
}
