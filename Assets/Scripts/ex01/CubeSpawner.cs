using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject[] Spawns;
    public GameObject[] SpawnItems;
    public float DelaySpawn = 1.0f;

    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (_nextSpawnTime < Time.time)
        {
            int numberSpawn = Random.Range(0, 3);

            Instantiate(SpawnItems[numberSpawn], Spawns[numberSpawn].transform.position, Quaternion.identity);
            _nextSpawnTime += DelaySpawn;
        }
    }
}
