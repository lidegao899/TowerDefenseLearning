using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject DeathEffect;

    [Header("Unity Item")]
    public Image healthBar;

    //public EnemyMovement Movement;
    private float health = 100;

    public float startHealth = 100;

    public int Value = 50;

    public void Start()
    {
        health = startHealth;
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    private void Die()
    {
        GameObject deathEffect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        PlayerStats.Money += Value;
        Destroy(gameObject);

        WaveSpawner.EnemiseAlive--;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }
}