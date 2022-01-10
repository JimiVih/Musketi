using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changethings : MonoBehaviour
{

    public GameObject pyörre;

    public Animator alus;


    // Start is called before the first frame update
    void Start()
    {

        alus.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

            pyörre.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            pyörre.SetActive(true);

        }

        if(Input.GetKeyDown(KeyCode.P))
        {

            alus.enabled = true;

        }





    }
}
