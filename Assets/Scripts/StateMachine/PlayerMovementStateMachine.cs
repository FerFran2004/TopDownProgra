using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
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

        if (Input.GetKey(KeyCode.W))
        {
            Direction = new Vector3(0f, 1f, 0f).normalized * CurrentSpeed * Time.deltaTime;
            transform.position += Direction;

        }

        if (Input.GetKey(KeyCode.D))
        {
            Direction = new Vector3(1f, 0f, 0f).normalized * CurrentSpeed * Time.deltaTime;
            transform.position += Direction;

        }

        if (Input.GetKey(KeyCode.A))
        {
            Direction = new Vector3(-1f, 0f, 0f).normalized * CurrentSpeed * Time.deltaTime;
            transform.position += Direction;

        }

        if (Input.GetKey(KeyCode.S))
        {
            Direction = new Vector3(0f, -1f, 0f).normalized * CurrentSpeed * Time.deltaTime;
            transform.position += Direction;

        }

        //Dash System
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCooldownCounter <= 0 && DashCounter <= 0) //Si los contadores estan en 0...
            {
                CurrentSpeed = DashSpeed; //Nueva velocidad mientras dure el dash
                DashCounter = DashTime; //El contador se vuelve el tiempo del Dash
            }
        }
        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime;
            if (DashCounter < 0)
            {
                CurrentSpeed = Speed;
                DashCooldownCounter = DashCooldown; //Se resetean la velocidad
            }
        }
        if (DashCooldownCounter > 0)
        {
            DashCooldownCounter -= Time.deltaTime;
        }

    }

}

