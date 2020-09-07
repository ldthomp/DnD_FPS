using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody myBody;
    [SerializeField] float lifeTimer = 2f;
    [SerializeField] float timer;
    [SerializeField] float damage = 25f;
    bool hitSomething = false;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTimer)
        {
            Destroy(gameObject);
        }
        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide (name) : " + collision.gameObject.name);
        if (collision.collider.tag !="Arrow")
        {
            hitSomething = true;
            Stick();
            EnemyHealth target = collision.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);

        }

    }


    private void Stick()
    {

        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
