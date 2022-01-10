using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemy;


    void Start()
    {
        foreach (GameObject enem in enemy)
        {
            enem.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider coll)
    {

        if(coll.gameObject.tag == "Player")
        {
            foreach (GameObject enem in enemy)
            {
                enem.SetActive(true);
            }
        }

    }

}
