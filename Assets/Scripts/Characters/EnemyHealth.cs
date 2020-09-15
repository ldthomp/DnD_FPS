using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] SpellDamage spellDamage;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage (float damage)
    {
        BroadcastMessage("OnDamageTaken");
        print(gameObject.name+"enemy taking " + damage);
        hitPoints -= damage;
        if(hitPoints <= 0f)
        {
            print("destroying" + gameObject.name);
            Die();
        }
    }
    void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.tag == "FireSpell")
        {
            float damage = spellDamage.SetDamage();
            TakeDamage(damage);
        }
    }
    private void Die()
    {
        if (isDead) return; 
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
