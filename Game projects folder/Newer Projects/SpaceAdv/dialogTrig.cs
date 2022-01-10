using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrig : MonoBehaviour
{

    private AudioSource dialogia;
    public AudioClip Dialog_1, Dialog_2;

   
    void Start()
    {
        dialogia = this.GetComponent<AudioSource>();
    }

   void OnTriggerEnter(Collider coll)
    {
        

        if(coll.gameObject.tag == "Dialogi1")
        {
            dialogia.clip = Dialog_1;
            dialogia.Play();
        }

        if(coll.gameObject.tag == "Dialogi2")
        {
            dialogia.clip = Dialog_2;
            dialogia.Play();
        }

    }



}
