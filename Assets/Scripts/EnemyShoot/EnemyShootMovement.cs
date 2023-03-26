using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMovement : MonoBehaviour
{
    public int Health = 150;
    public int BlueTouchDamage = 20;

    private int currentHealth;
    void Start()
    {
        currentHealth= Health;
    }
    public void TakeDamage(int damage)
    {
        Physics.SyncTransforms();
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Debug.Log("The shoot enemy is dead");
            Destroy(gameObject);

        }
    }

    void Update()
    {
        
    }
  
}
