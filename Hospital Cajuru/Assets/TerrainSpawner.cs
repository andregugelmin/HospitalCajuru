using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject terrainObj;
    private Vector3 spawnPos;
    [SerializeField]
    private float spawnTime;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        spawnPos = new Vector3(Random.Range(-2.4f, 2.4f), -6.0f, transform.position.y);
        Instantiate(terrainObj, transform.position + spawnPos, transform.rotation);
        nextSpawnTime = Time.time + spawnTime;
    }
}
