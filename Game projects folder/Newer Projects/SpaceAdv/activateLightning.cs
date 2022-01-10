using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateLightning : MonoBehaviour
{

    public GameObject salami;
    public AudioSource salamiÄäni;

    void Start()
    {

        salami.SetActive(false);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "salami")
        {
            salamiÄäni.Play();
            salami.SetActive(true);
        }
    }



}
