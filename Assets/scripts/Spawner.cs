using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    public float RandomTime;



    private void Awake()
    {
        StartCoroutine(RandomSpawn());
    }
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[5];
        for(int i=0; i<spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }
    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        RandomTime = Random.Range(15, 100);
    }

    IEnumerator RandomSpawn()
    {
        while(true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(RandomTime);
        }
    }
}
