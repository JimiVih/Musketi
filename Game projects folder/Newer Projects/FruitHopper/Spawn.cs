using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] Prefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomPrefab()
    {
        var spawnableObject = Prefabs[Random.Range(0, 6)];
        Instantiate(spawnableObject, transform.transform);
    }
}
