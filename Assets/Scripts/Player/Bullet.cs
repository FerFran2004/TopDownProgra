using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public GameObject EnemyShootHealth;
   // public LayerMask ShootEnemy;
    public float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "EnemiesShoot") 
        {
            // EnemyShootHealth = GameObject.FindWithTag("EnemiesShoot");                  //Bajarle vida al objetivo al que se le esta disparando
            // EnemyShootHealth.GetComponent<EnemyShootMovement>().TakeDamage(Damage);     //Bajarle vida al objetivo al que se le esta disparando
            collision.gameObject.GetComponent<EnemyShootMovement>().TakeDamage(Damage);
            Destroy(this.gameObject);
            Debug.Log("HIT THE TARGET");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
 
    }
}
