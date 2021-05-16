using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float gravity = -0.02f;
    public float force = 1f;
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;

        GameManager.instance.ShowGameOver(false);
    }
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position = originalPos;

            var rd = GetComponent<Rigidbody2D>();
            rd.velocity = Vector3.zero;
            rd.AddForce(new Vector2(0, force));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ãæµ¹ " + collision.transform.name);
        enabled = false;
        GameManager.instance.ShowGameOver(true);

        ScrollPosition.Items.ForEach(x => x.enabled = false);
    }
}
