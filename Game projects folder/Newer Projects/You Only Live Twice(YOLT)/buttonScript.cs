using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{

    public Animator door;

    public Animator button;



    void OnTriggerStay(Collider coll)
    {

        if(coll.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                print("open");
                button.SetTrigger("push");
                door.SetBool("open", true);
            }
        }

    }



}
