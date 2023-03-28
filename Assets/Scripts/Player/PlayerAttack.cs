using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float AttackTime;
    public float StartAttackTime;
    public Transform AttackPos;

    public LayerMask EnemyFinder; //Para detectar enemigos dentro del rango
    public float AttackRange = 0.5f;
    public int Damage = 40;

    void Start()
    {

    }


    void Update()
    {

        Physics.SyncTransforms();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            Debug.Log("Hello");
            AttackTime = StartAttackTime;
            Collider2D[] DamageEnemies = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, EnemyFinder);
            
            foreach(Collider2D Enemy in DamageEnemies)
            {
                Enemy.GetComponent<EnemyMovement>().TakeDamage(Damage);
                //Debug.Log("ATTACKED: " + Enemy.name);
            }
        }      
        
    }


    private void OnDrawGizmosSelected()
    {
        if (AttackPos == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
