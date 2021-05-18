using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhyBird : Bird
{
    private void Start()
    {
        base.Start();

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.useFullKinematicContacts = true;
    }

    public float gravity = -0.07f;
    public float g_Acceleration = 0;
    private void Update()
    {
        //성능차이에 따른 fps에 
        // 물리적인 계산 등 성능에 따라 결과가 달라지므로
        // FixedUpdate사용하자
        //GrivityAcceleration();

        // 마우스 클릭, 스페이스바
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > 0.5f)
            {
                Flap();
            }
        }
    }
    void Flap()
    {
        base.forceY = 0.07f;
        //낙하중에 클릭시 조금만 띄워진다
        //낙하중 운동힘을 멈추고나서 힘을 줘야 항상 일정하게 띄워진다
        g_Acceleration = forceY;
        animator.Play("Flap", 0, 0);
    }
    private void FixedUpdate()
    {
        GrivityAcceleration();
    }
    void GrivityAcceleration()
    {
        if (Time.deltaTime == 0)
            return;

        //중력에 의한 낙하 구현
        //중력가속도
        g_Acceleration += gravity * Time.fixedDeltaTime;

        //중력가속도에 의한 y값 변경
        transform.Translate(0, g_Acceleration, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        OnDie(collision);

        //물리를 다시 살리자
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        enabled = false;
        GameManager.instace.scrollSpeedMult = 0;
    }
}
