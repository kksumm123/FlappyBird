using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLocating : MonoBehaviour
{
    // �� ������ ��ġX�� ������ ���������� ������
    public float minX = -14;
    [SerializeField] // private���� �ν����� ����
    private float showinspector = 123;
    void Update()
    {
        if (minX > transform.position.x)
        {
            // ���������� ���� ũ�� * 2 ��ŭ ������
            // ���� ũ�� = 20.48
            transform.Translate(14f, 0, 0);
        }
    }
}
