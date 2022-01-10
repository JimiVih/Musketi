using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScrir : MonoBehaviour
{

    public float range = 100f;
    public RaycastHit hit;

    public bool RcastEnab;

    public Transform lamppu;
    public GameObject salama;

    public Animator alusAn;


    void Start()
    {
        

    }

    void Update()
    {




            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.tag);



            }

        

    }

    public void rayHit()
    {
        if (hit.transform.tag == "lightTrigEvent")
        {
            var lato = hit.transform.gameObject;

            var playSund = salama.GetComponent<AudioSource>();
            playSund.Play();
            alusAn.SetBool("go to another place", true);
            Destroy(lato);

        }

    }
        


}
