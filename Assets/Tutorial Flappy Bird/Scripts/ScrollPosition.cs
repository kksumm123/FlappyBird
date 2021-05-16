using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPosition : MonoBehaviour
{
    public float speed = -1f; // 1초에 한칸 왼쪽으로 이동.

    public float minX = -2;
    public Transform otherGround;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // 스크롤 처음 위치로 옮기기
        if (transform.position.x < minX)
        {
            var pos = transform.position;
            pos.x = otherGround.position.x + 2;
            transform.position = pos;
        }
    }

    // Update이후에 호출 Late(늦은)
    private void LateUpdate()
    {
        // 위치이동 x:speed, y:0, z:0
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
