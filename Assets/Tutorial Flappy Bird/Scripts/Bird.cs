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
    }
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position = originalPos;

            var rd = GetComponent<Rigidbody>();
            rd.velocity = Vector3.zero;
            rd.AddForce(0, force, 0);
        }
    }
}
