using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject terrainObj;
    [SerializeField]
    private GameObject cloudObj;
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

        if (Points.instance.points >= 100 && spawnTime > 4)
        {
            spawnTime -= 1;
        }
        if (Points.instance.points >= 300 && spawnTime > 3)
        {
            spawnTime -= 1;
        }
        if (Points.instance.points >= 500 && spawnTime > 2)
        {
            spawnTime -= 1;
        }
        if (Points.instance.points >= 800 && spawnTime > 1)
        {
            spawnTime -= 1;
        }
        
    }

    private void SpawnTerrain()
    {
        GameObject groundSpawned;
        spawnPos = new Vector3(Random.Range(-2.4f, 2.4f), -6.0f, transform.position.y);
        groundSpawned = Instantiate(terrainObj, transform.position + spawnPos, transform.rotation);
        nextSpawnTime = Time.time + spawnTime;
        Points.instance.gainPoints(50);
    }
}
