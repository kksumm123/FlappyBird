using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public Animator animator;
    
    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Flap();
    }

    public float forceY = 300;
    void Update()
    {
        // 마우스 클릭, 스페이스바
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > 0.5f)
            {
                Flap();
            }
        }
    }
    
    private void Flap()
    {
        //낙하중에 클릭시 조금만 띄워진다
        //낙하중 운동힘을 멈추고나서 힘을 줘야 항상 일정하게 띄워진다
        Vector2 force;
        force.x = 0;
        force.y = forceY;
        //속도 벡터 zero
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(force);
        animator.Play("Flap", 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDie(collision);
    }

    protected void OnDie(Collision2D collision)
    {
        Debug.Log($"{collision}이랑 충돌해따");
        // 새 죽음
        // 게임 오버 UI
        GameManager.instace.SetGameOver();
        animator.Play("Die", 0, 0);

        // 스크롤 멈춤
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instace.AddScore(100);
    }
}
