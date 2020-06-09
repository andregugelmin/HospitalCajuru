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
        if(Time.time >= nextSpawnTime && GameSpeed.instance.gameState != GameSpeed.GameState.waitingBoost)
        {
            int rand = Random.Range(0, 99);
            if(rand <= 10)
            {
                SpawnCloud();
            }
            else
            {
                SpawnTerrain();
            }
            spawnTime = GameSpeed.instance.spawnTime;
        }       
        
    }

    private void SpawnTerrain()
    {
        GameObject groundSpawned;
        spawnPos = new Vector3(Random.Range(-2.4f, 2.4f), -6.0f, transform.position.z);
        groundSpawned = Instantiate(terrainObj, transform.position + spawnPos, transform.rotation);
        nextSpawnTime = Time.time + spawnTime;
        
    }
    private void SpawnCloud()
    {
        GameObject cloudSpawned;
        spawnPos = new Vector3(Random.Range(-1.8f, 1.6f), -6.0f, transform.position.z);
        cloudSpawned = Instantiate(cloudObj, transform.position + spawnPos, transform.rotation);
        nextSpawnTime = Time.time + spawnTime;
    }
}
