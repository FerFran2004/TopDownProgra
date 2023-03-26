using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int Health = 100;
    public int TouchDamage = 10;
    int currentHealth;
    public float Enem_Speed;
    public GameObject PlayerEnergy;


    void Start()
    {
        currentHealth = Health;


    }

    public void TakeDamage(int damage)
    {
        Physics.SyncTransforms();
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            //if (Player != null)
            //{
            //   Player.GetComponent<Movement>;
            //}
            Debug.Log("The enemy is dead");
            PlayerEnergy = GameObject.FindWithTag("Gun");
            PlayerEnergy.GetComponent<Gun>().FillEnergy(10);
            Destroy(gameObject);

        }
    }



    void Update()
    {
        
    }

}
