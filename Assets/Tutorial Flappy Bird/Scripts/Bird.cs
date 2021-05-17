using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public float forceY = 500;
    void Update()
    {
        // 마우스 클릭, 스페이스바
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force;
            force.x = 0;
            force.y = forceY;
            rigidbody2D.AddForce(force);
        }
    }
}
