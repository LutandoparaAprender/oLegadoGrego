using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth;

    public heart Hearth;

    void Start()
    {
        currentHealth = maxhealth;
        Hearth.SetMaxHealth(maxhealth);
    }

       public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Hearth.SetHealth(currentHealth);
        Debug.Log("eu acertei");

        if (currentHealth <= 0)
        {
            Die();
        }
        void Die()
        {
            Debug.Log("Enemy died");
            Destroy(gameObject);
        }
    }
}