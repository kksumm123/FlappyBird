using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public Animator animator;
    Vector2 force;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public float forceY = 400;
    void Update()
    {
        // 마우스 클릭, 스페이스바
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            force.x = 0;
            force.y = forceY;
            rigidbody2D.AddForce(force);
            animator.Play("Flap", 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 새 죽음
        // 게임 오버 UI
        // 스크롤 멈춤
        GameManager.instace.SetGameOver();
        animator.Play("Die", 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instace.AddScore(100);
    }
}
