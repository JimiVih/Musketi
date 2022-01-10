using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;

    public Transform[] enemies;
    public Transform[] spawnPoints;

    public float cooldown;

    int randomEnemy;
    int randomSpawn;

    bool koiIsDead;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        koiIsDead = gameManager.koiIsDead;
    }

    IEnumerator SpawnEnemy()
    {
        if (!koiIsDead)
        {
            randomEnemy = Random.Range(0, enemies.Length);
            randomSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawn]);
            yield return new WaitForSeconds(cooldown);
            CheckIfDead();
        }
    }

    void CheckIfDead()
    {
        if(!koiIsDead)
        {
            StartCoroutine(SpawnEnemy());
        }
    }
}
