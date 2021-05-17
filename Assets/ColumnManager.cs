using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    public GameObject column;

    public float spawnDelay = 3;
    public float spawnDelayRandom = 1;
    public float spawnX = 10f;
    public float spawnYmin = -1.62f;
    public float spawnYmax = 3.46f;
    IEnumerator Start()
    {
        while(GameManager.instance.gameover == false)
        {
            // 기둥 스폰(생성).
            Instantiate(column, new Vector3(spawnX, Random.Range(spawnYmin, spawnYmax), 0), column.transform.rotation);

            yield return new WaitForSeconds(spawnDelay + Random.Range(-spawnDelayRandom, spawnDelayRandom));
        }
    }
}
