using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject enemy;
    public Transform[] spawnLocations;

    public bool randomize;
    public bool spawn;

    public float spawnCooldown;


    // Start is called before the first frame update
    void Start()
    {
        startSpawnRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawnRoutine()
    {
        //calls spawnroutine to start spawning
        spawn = true;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        print("call Spawnroutine");
        if(spawn)
        {

            //randomizes spawning and enemies
            if(randomize)
            {
                randomEnemieLoc();
                
            }
            //spawns specific enemy to a random place
            else
            {
                print("call placeEnemy");
                PlaceEnemy();
                
            }
            yield return new WaitForSeconds(spawnCooldown);
            SpawnAgain();
        }
    }


    void randomEnemieLoc()
    {
        //randomizes spawning and enemies
        print("placeRandomEnemy");
        int randomEnemy = Random.Range(0, enemies.Length);
        int randomSpawnpoint = Random.Range(0, spawnLocations.Length);
        Instantiate(enemies[randomEnemy], spawnLocations[randomSpawnpoint]);
    }

    void PlaceEnemy()
    {
        //spawns specific enemy to a random place
        print("placeEnemy");
        int randomSpawnpoint = Random.Range(0, spawnLocations.Length);
        GameObject spawnedEnemy = Instantiate(enemy, spawnLocations[randomSpawnpoint], false);
        spawnedEnemy.transform.position = spawnLocations[randomSpawnpoint].position;

    }

    void SpawnAgain()
    {
        StartCoroutine(SpawnRoutine());
    }

}
