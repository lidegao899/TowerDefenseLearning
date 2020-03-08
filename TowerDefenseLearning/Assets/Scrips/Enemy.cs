using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DeathEffect;

    //public EnemyMovement Movement;

    public float health = 100;

    public int Value = 50;

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    void Die()
    {
        GameObject deathEffect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        PlayerStats.Money += Value;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
}
