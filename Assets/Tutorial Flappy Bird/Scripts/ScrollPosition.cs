using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPosition : MonoBehaviour
{
    public float speed = -1f; // 1초에 한칸 왼쪽으로 이동.

    public float minX = -2;

    float width;
    private void Start()
    {
        width = GetComponentInChildren<BoxCollider2D>().size.x;
    }
    void Update()
    {
        // 최저 위치보다 뒤로 갔다면 앞으로 이동시키기
        if (transform.position.x < minX)
        {
            transform.Translate(width * 2, 0, 0);
        }

        // 스크롤 가로 이동.
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
