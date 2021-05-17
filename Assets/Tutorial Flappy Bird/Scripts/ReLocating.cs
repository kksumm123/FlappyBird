using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLocating : MonoBehaviour
{
    // 이 값보다 위치X가 작으면 오른쪽으로 보내자
    public float minX = -20.48f;
    [SerializeField] // private으로 인스펙터 노출
    private float showinspector = 123;
    void Update()
    {
        if (minX > transform.position.x)
        {
            // 오른쪽으로 가로 크기 * 2 만큼 보내자
            // 가로 크기 = 20.48
            transform.Translate(20.48f * 2, 0, 0);
        }
    }
}
