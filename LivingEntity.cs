using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour,IDamagable
{
    public float startingHealth;
    protected float health;
    protected bool dead;
    public event System.Action OnDeath;
    public virtual void Start()
    {
        health = startingHealth;

    }
    public void TakeHit(float damage,RaycastHit hit)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }

    }
    public void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }

        GameObject.Destroy(gameObject);
    }
}
