using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAttack : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;
    public float FireRate;
    public GameObject Player;

    private float ReadyToFire;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        if (Player != null)
        {
            if (ReadyToFire > FireRate)
            {
                Instantiate(Bullet, BulletPos.position, Quaternion.identity);
                ReadyToFire = 0;

            }


            if (ReadyToFire < FireRate)
            {
                ReadyToFire += Time.deltaTime;
            }

        }
        else
        {
            

        }


    }
    
    
}
