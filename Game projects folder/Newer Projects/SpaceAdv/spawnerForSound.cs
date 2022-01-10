using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerForSound : MonoBehaviour
{
    public float TimeLeft;
    public float TimeAdd;

    public GameObject Sound;
    public GameObject SoundSpawnPlace;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        
        if(TimeLeft < 0)
        {
            var SpawnThatObj = Instantiate(Sound);
            SpawnThatObj.transform.position = SoundSpawnPlace.transform.position;
            TimeLeft += TimeAdd;

        }
    }
}
