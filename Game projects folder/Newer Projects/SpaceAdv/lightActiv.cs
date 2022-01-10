using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightActiv : MonoBehaviour
{




    public GameObject lampu;





    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        




    }



    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "activLight")
        {

            lampu.SetActive(true);

        }
    }






}
