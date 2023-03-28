using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletHolder;
    public Transform ShootPoint;
    public float ShootForce = 10f;
    public int Energy = 0;
    public float FireRate = 0.5f;


    private float ReadytoFire = 0;


    void Start()
    {
        
    }

    
    void Update()
    {
       // Debug.Log("MY ENERGY:" + Energy);
       // Debug.Log("FIRERATE:" + FireRate);

       if (FireRate == 0) //Si el arma es automatica, no hay retardo entre bala y bala...
        {

            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (Energy > 0)
                {
                    GameObject bullet = Instantiate(bulletHolder, ShootPoint.position, ShootPoint.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(ShootPoint.up * ShootForce, ForceMode2D.Impulse);
                    Energy -= 1;

                }
                if (Energy <= 0)
                {
                    Debug.Log("No Energy: " + Energy);

                }


            }

       }
       if (ReadytoFire < FireRate) //Sumatoria hasta llegar al tiempo para hacer el disparo
        {
            ReadytoFire += Time.deltaTime;

        }

       else //Si existe un retardo entre bala y bala...
       {
            //if (gameObject.name == "GunWeapon (1)")
            //{
            //    Debug.Log(gameObject.name);
            //
            //}
            //if (gameObject.name == "GunWeapon")
            //{
            //    Debug.Log(gameObject.name);
            //}
            if (Input.GetKey(KeyCode.Mouse1) && ReadytoFire > FireRate)
            {
                if (Energy > 0)
                {
                    GameObject bullet = Instantiate(bulletHolder, ShootPoint.position, ShootPoint.rotation);
                    Debug.Log(gameObject.name);
                    bullet.GetComponent<Rigidbody2D>().AddForce(ShootPoint.up * ShootForce, ForceMode2D.Impulse);
                    Energy -= 1;
                    ReadytoFire = 0;
                }
                if (Energy <= 0)
                {
                    Debug.Log("No Energy: " + Energy);

                }

            }
        }


    }

    public void FillEnergy(int energy)
    {
        Energy += energy;

    }
}
