using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public float startSpeed = 10f;
    //[HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject deathEffect;
    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0) 
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
        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect,5f);
    }

    
}
