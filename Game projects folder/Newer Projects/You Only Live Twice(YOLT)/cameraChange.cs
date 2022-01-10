using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{

    public GameObject camOff, camOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider player)
    {

        if(player.gameObject.tag == "Player")
        {
            camOff.SetActive(false);
            camOn.SetActive(true);
        }

    }





}
