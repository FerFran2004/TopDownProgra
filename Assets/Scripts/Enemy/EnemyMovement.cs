using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int Health = 100;
    public int TouchDamage = 10;
    public float Speed;

    //Random numbers for movement
    public float MoveTime;
    public float MaxX = 16f;
    public float MinX = -16f;
    public float MaxY = 9f;
    public float MinY = -9f;
    public float RandomDirX;
    public float RandomDirY;
    
    public GameObject PlayerEnergy;

    Vector3 Direction;
    private float CurrentMoveTime;
    int currentHealth;


    void Start()
    {
        currentHealth = Health;
       // Speed = Random.Range(0, 1);
        //Debug.Log(Speed);
    }

    public void TakeDamage(int damage)
    {
        Physics.SyncTransforms();
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Debug.Log("The enemy is dead");
            PlayerEnergy = GameObject.FindWithTag("Gun");
            PlayerEnergy.GetComponent<Gun>().FillEnergy(10);
            Destroy(gameObject);

        }
    }



    void Update()
    {
        //Changing Direction a certain time period
        if (MoveTime <= 0) 
        {
            int NewTime = Random.Range(0, 7);
            MoveTime = NewTime;
        }
        if (MoveTime> 0) 
        {
            MoveTime -= Time.deltaTime;
        }


        //Direction Position
        if (CurrentMoveTime <= 0) 
        {
            RandomDirX = Random.Range(MinX, MaxX);
            RandomDirY = Random.Range(MinY, MaxY);
            CurrentMoveTime = MoveTime;
        }
        if (CurrentMoveTime > 0) 
        {
            Direction = new Vector3(RandomDirX, RandomDirY);
            transform.position += Direction * Speed * Time.deltaTime;
            CurrentMoveTime -= Time.deltaTime;
        }
  
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            RandomDirX *= -1;
            RandomDirY *= -1;
        }
        if (collision.gameObject.tag == "Player")
        {

            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }


    //Moverlo por ints o moverlo hacia un gameobject vacio con una posicion
  


}
