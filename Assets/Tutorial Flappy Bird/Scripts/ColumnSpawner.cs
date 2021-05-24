using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;
    public float delay = 4f;
    public float randomDelay = 1f;
    public float spawnX = 8f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            if (GameManager.instace.isGameOver == true)
                return;
            // 스폰시키는 x값은 고정값
            // 배치할 때 y값은 랜덤
            Vector3 pos = new Vector3();
            pos.x = spawnX;
            pos.y = Random.Range(-2f, 2f);
            pos.z = 0;
            Instantiate(column, pos, column.transform.rotation);

            yield return new WaitForSeconds(delay + Random.Range(-randomDelay, randomDelay));
        }
    }
}
