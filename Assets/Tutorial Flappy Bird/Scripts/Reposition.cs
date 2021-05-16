using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public float minX = -2;

    float width;
    private void Start()
    {
        width = GetComponentInChildren<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 최저 위치보다 뒤로 갔다면 앞으로 이동시키기
        if (transform.position.x < minX)
        {
            transform.Translate(width * 2, 0, 0);
        }
    }
}
