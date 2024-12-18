using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManagement : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;
    public float startHealth = 100;
    public float health;
    public int worth = 50;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar; // Đảm bảo rằng healthBar là một đối tượng Image
    private bool isDeath = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDeath) 
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
        Debug.Log("Slowing enemy");
    }

    private void Die()
    {
        isDeath = true;
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        WaveSpawner.EnmiesAlive--;
    }
}