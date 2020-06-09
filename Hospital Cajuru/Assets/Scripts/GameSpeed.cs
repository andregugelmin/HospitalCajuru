using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed instance { get; private set; }
    public int objSpeed, objSpeedNormal, objSpeedBoosted;
    public float spawnTime, spawnTimeNormal, spawnTimeBoosted, timeBoosted;
    public GameState gameState;
    public enum GameState
    {
        normal, boosted, waitingBoost
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameState = GameState.normal;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.normal:
                spawnTime = spawnTimeNormal;
                objSpeed = objSpeedNormal;
                
                break;

            case GameState.boosted:
                spawnTime = spawnTimeBoosted;
                objSpeed = objSpeedBoosted;
                timeBoosted -= Time.deltaTime;
                if (timeBoosted <= 0)
                {
                    gameState = GameState.normal;
                }
                break;
            case GameState.waitingBoost:
                spawnTime = 0;
                objSpeed = 0;                
                break;
        }
        if (Points.instance.points >= 30 && spawnTime > 4)
        {
            spawnTimeNormal = 4;
            objSpeedNormal = 2;
            spawnTimeBoosted = 2;
            objSpeedBoosted = 4;
        }
        else if (Points.instance.points >= 60 && spawnTime > 3)
        {
            spawnTimeNormal = 3;
            objSpeedNormal = 3;
            spawnTimeBoosted = 1;
            objSpeedBoosted = 6;
        }
        else if (Points.instance.points >= 120 && spawnTime > 2)
        {
            spawnTimeNormal = 2;
            objSpeedNormal = 4;
            spawnTimeBoosted = 0.75f;
            objSpeedBoosted = 8;
        }
        else if (Points.instance.points >= 250 && spawnTime > 1)
        {
            spawnTimeNormal = 1;
            objSpeedNormal = 5;
            spawnTimeBoosted = 0.5f;
            objSpeedBoosted = 10;
        }

        if(timeBoosted > 0)
        {
            Debug.Log(timeBoosted);
            timeBoosted -= Time.deltaTime;
            gameState = GameState.boosted;
            
        }
    }
    
}
