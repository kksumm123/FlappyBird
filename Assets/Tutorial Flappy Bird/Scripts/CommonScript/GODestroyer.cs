using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GODestroyer : MonoBehaviour
{
    public float minX = -10;

    void Update()
    {
        if (transform.position.x < minX)
            Destroy(gameObject);
    }
}
