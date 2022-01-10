using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCollider : MonoBehaviour
{

    public GameObject dialog;
    public ghostMECH ghostmek;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            dialog.SetActive(true);
        }
    }

    private void Update()
    {
        if(ghostmek.canTeleport == true)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }


}
