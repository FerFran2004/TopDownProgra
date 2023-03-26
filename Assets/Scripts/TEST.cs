using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MOVEMENTTYPE
{
    TRANSFORM = 0,
    RIGIDBODY2D
}
public class MovementBall : MonoBehaviour
{
    public float m_SPEED = 2;
    public float m_JUMPFORCE = 2;
    public float m_GRAVITY = 2;
    public MOVEMENTTYPE m_MoveType;


    public Vector3 m_DIRECTION;
    public Vector3 m_VECTORMOVE;
    public float m_FALLSPEED;


    public Rigidbody2D m_RigidBody2D;
    public BoxCollider2D m_BoxCollider2D;


    public bool m_OnGROUND;

    void Start()
    {
        if (!m_RigidBody2D) //Si no tiene RigidBody-Se lo ponemos
        {
            m_RigidBody2D = GetComponent<Rigidbody2D>();
        }
        if (!(m_BoxCollider2D)) //Lo mismo pero con box collider 2D
        {
            m_BoxCollider2D = GetComponent<BoxCollider2D>();
        }

    }


    void Update()
    {
        movement();
    }


    void movement()
    {
        switch (m_MoveType) // If con else 
        {
            case MOVEMENTTYPE.TRANSFORM: //En el caso (case) de que el movement sea transform...
                handleInput();
                m_RigidBody2D.bodyType = RigidbodyType2D.Static;
                transformMovement();
                break;
            case MOVEMENTTYPE.RIGIDBODY2D:
                rigidInput();
                rigidBodyMove();
                m_RigidBody2D.bodyType = RigidbodyType2D.Dynamic;
                break;
        }
    }

    void handleInput()
    {
        m_DIRECTION = Vector3.zero; //La direccion de movimiento va a ser zero
        if (Input.GetKey(KeyCode.D))
        {
            m_DIRECTION.x += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_DIRECTION.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_DIRECTION.y -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_DIRECTION.y += 1;
        }
    }

    void rigidInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_DIRECTION.x += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_DIRECTION.x -= 1;
        }

    }

    void transformMovement()
    {
        transform.position += m_DIRECTION * m_SPEED * Time.deltaTime;
    }

    void rigidBodyMove()
    {
        m_RigidBody2D.AddForce(m_DIRECTION * m_SPEED * Time.deltaTime, ForceMode2D.Force);
        if (m_RigidBody2D.velocity.x > m_SPEED)
        {
            m_RigidBody2D.velocity = new Vector2(m_SPEED, m_RigidBody2D.velocity.y);

        }
        if (m_RigidBody2D.velocity.x > -m_SPEED)
        {
            m_RigidBody2D.velocity = new Vector2(m_SPEED, m_RigidBody2D.velocity.y);

        }
    }
}