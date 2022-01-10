using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRAG : MonoBehaviour
{

    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> ragRB = new List<Rigidbody>();



    

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        EtsiRagnukke();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EtsiRagnukke()
    {
        print("etsiRAG");
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {

                c.isTrigger = true;
                RagdollParts.Add(c);
     


            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                ragRB.Add(r);
                r.useGravity = false;
                r.isKinematic = true;

            }


        }

        AktvRagnukke();
    }


    public void AktvRagnukke()
    {




        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = false;

       

            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = true;
                r.isKinematic = false;

            }


        }



        



        

    }


}
