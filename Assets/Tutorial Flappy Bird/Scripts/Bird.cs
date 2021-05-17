using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float gravity = -0.02f;
    public float force = 1f;
    private Vector3 originalPos;
    public Animator animator;

    private void Start()
    {
        originalPos = transform.position;

        GameManager.instance.ShowGameOver(false);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);


        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            var rd = GetComponent<Rigidbody2D>();
            rd.velocity = Vector3.zero;
            rd.AddForce(new Vector2(0, force));

            animator.Play("Flap", 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ãæµ¹ " + collision.transform.name);
        enabled = false; // Update ÇÔ¼ö ¹Ýº¹À» ¸ØÃã.
        animator.Play("Die", 0, 0);

        GameManager.instance.ShowGameOver(true);

        ScrollPosition.Items.ForEach(x => x.enabled = false);

    }
}
