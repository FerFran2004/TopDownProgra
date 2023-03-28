using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  //  private bool CanDamaged = false;
  public float Speed;
  private float CurrentSpeed;
  public Rigidbody2D rbPlayer;
  Vector3 Direction;
  public Gun weapon;


  [SerializeField] int angleOffset;

  public float DashSpeed;
  public float DashTime; //Length
  public float DashCooldown;

  private float DashCounter;
  private float DashCooldownCounter;

  public float Health = 100;

  public GameObject RedEnemy;
  public GameObject ShootEnemy;
  public GameObject EnemyShootBullet;


  void Start()
  {
    rbPlayer = GetComponent<Rigidbody2D>();
    CurrentSpeed = Speed;
  }

  void Update()
  {


    //Look at Mouse
    var MouseDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    var Angle = Mathf.Atan2(MouseDir.x, MouseDir.y) * Mathf.Rad2Deg * angleOffset;
    transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

    //Movement Keys
    if (DashCounter<=0)
    {
      Direction = Vector3.zero;
      if (Input.GetKey(KeyCode.W))
      {
        Direction += new Vector3(0f, 1f, 0f).normalized;
      }

      if (Input.GetKey(KeyCode.D))
      {
        Direction += new Vector3(1f, 0f, 0f).normalized;

      }

      if (Input.GetKey(KeyCode.A))
      {
        Direction += new Vector3(-1f, 0f, 0f).normalized;

      }

      if (Input.GetKey(KeyCode.S))
      {
        Direction += new Vector3(0f, -1f, 0f).normalized;

      }
    }


    transform.position += Direction * CurrentSpeed * Time.deltaTime;
    
    
    //Dash System
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (DashCooldownCounter <= 0 && DashCounter <= 0) //Si los contadores estan en 0...
      {
        CurrentSpeed = DashSpeed; //Nueva velocidad mientras dure el dash
        DashCounter = DashTime; //El contador se vuelve el tiempo del Dash
        gameObject.layer = 8;
      }
    }
    if (DashCounter > 0)
    {
      DashCounter -= Time.deltaTime;

      if (DashCounter <= 0)
      {
        CurrentSpeed = Speed;
        DashCooldownCounter = DashCooldown; //Se resetean la velocidad
        gameObject.layer = 3;
      }
    }
    else
    {

    }
    if (DashCooldownCounter > 0)
    {
      DashCooldownCounter -= Time.deltaTime; //Se va restando poco a poco
    }

  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "EnemiesShoot")
    {
      ShootEnemy = GameObject.Find("EnemyShoot");
      int BlueDamage = ShootEnemy.GetComponent<EnemyShootMovement>().BlueTouchDamage;
      Health -= BlueDamage;
      if (Health <= 0) // Feature de last stande?: (Health < 0) Hace que tenga 0 pero aun asi se pueda mover, pero se muere al siguente golpe
      {
        Destroy(gameObject);
      }
    }
    if (collision.gameObject.tag == "Enemies")
    {
      RedEnemy = GameObject.Find("Enemy");
      int RedDamage = RedEnemy.GetComponent<EnemyMovement>().TouchDamage;
      Health -= RedDamage;
      if (Health <= 0)
      {
        Destroy(gameObject);

      }

    }
    if (collision.gameObject.tag == "EnemyShootBullet")
    {
      EnemyShootBullet = GameObject.FindWithTag("EnemyShootBullet");
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //  Debug.Log("CHANGE BODYTYPE");
      gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      int EnemyShootBulletDamage = EnemyShootBullet.GetComponent<EnemyShootBullet>().Damage;
      Health -= EnemyShootBulletDamage;
      if (Health <= 0)
      {
        Destroy(gameObject);

      }

    }
  }

}

