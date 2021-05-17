using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;
    public float delay = 4f;
    public float randomDelay;
    public float spawnX = 4;
    public float spawnY = 4;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            // ������Ű�� x���� ������
            // ��ġ�� �� y���� ����
            Vector3 pos = new Vector3();
            pos.x = spawnX;
            pos.y = Random.Range(-1, 1);
            pos.z = 0;
            Instantiate(column, pos, column.transform.rotation);
            randomDelay = Random.Range(-1, 1);
            yield return new WaitForSeconds(delay + randomDelay);
        }
    }
}
