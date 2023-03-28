using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointInArea : MonoBehaviour
{
    public Transform m_referencia1;
    public Transform m_referencia2;

    public float m_waitTime = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 getRandomPoint()
    {
        return new Vector2(Random.Range(m_referencia1.position.x, m_referencia2.position.x),
                           Random.Range(m_referencia1.position.y, m_referencia2.position.y));
    }
    float getRandomX()
    {
        return Random.Range(m_referencia1.position.x, m_referencia2.position.x);
    }

    float getRandomY()
    {
        return Random.Range(m_referencia1.position.y, m_referencia2.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(m_referencia1.position, m_referencia2.position);
    }
}