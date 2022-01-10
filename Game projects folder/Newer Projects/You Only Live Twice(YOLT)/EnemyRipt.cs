using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRipt : MonoBehaviour
{
    //PELIN RIPTI

    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> ragRB = new List<Rigidbody>();

    private Rigidbody parentRB;

    public BoxCollider upper, head;
    public CapsuleCollider down;
    public GameObject headd;

    public Rigidbody torsoRB;
    public float forcePower;

    public Transform Player;
  
    public Transform mana;


    public GameObject aim;

    Animator anim;

    private float rightMov = 3f;
    private float leftMov = -3f;
    public float walkSpeed;
    public float dist;

    public float vittu;

    public EnemyAim aimScript;
    public bool CanMove;
    


    // Start is called before the first frame update
    private void Start()
    {
        print("start");
        mana = GameObject.FindGameObjectWithTag("mana").transform;
        EtsiRagnukke();
        anim = GetComponent<Animator>();
        parentRB = GetComponent<Rigidbody>();
    }


    void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);
        float rotY = transform.eulerAngles.y;
        vittu = rotY;
        if (aimScript.SeePlayer == true && CanMove == true)
        {
            if (dist <= 6f)
            {


                if (rotY == 270)
                {
                    walkSpeed = 5f;
                    anim.SetBool("runFor", false);
                    anim.SetBool("runBack", true);
                }

                if (rotY == 90)
                {
                    walkSpeed = -5f;
                    anim.SetBool("runFor", false);
                    anim.SetBool("runBack", true);
                }



                //transform.Translate(Vector3.right * Time.deltaTime * walkspeed, Space.World)
            }

            if (dist > 9f)
            {
                if (rotY == 270)
               {
                    walkSpeed = 0f;
                    anim.SetBool("runFor", false);
                    anim.SetBool("runBack", false);

                }

               if(rotY == 90)
               {
                    walkSpeed = 0f;
                    anim.SetBool("runFor", false);
                    anim.SetBool("runBack", false);

                }

            }


            if (dist >= 12f)
            {

                if (rotY == 270)
                {
                    walkSpeed = -5f;
                    anim.SetBool("runFor", true);
                    anim.SetBool("runBack", false);
                }

                if (rotY == 90)
                {
                    walkSpeed = 5f;
                    anim.SetBool("runFor", true);
                    anim.SetBool("runBack", false);
                }




            }
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (aimScript.SeePlayer == true)
        {
            parentRB.MoveRotation(Quaternion.Euler(new Vector3(0, 90 * Mathf.Sign(Player.position.x - transform.position.x), 0)));
        }
        parentRB.velocity = new Vector3(walkSpeed, parentRB.velocity.y, 0);



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
                upper.isTrigger = false;
                down.isTrigger = false;
                head.isTrigger = false;
             
            }

        }

        foreach (Rigidbody r in rbs)
        {

            if(r.gameObject != this.gameObject)
            {
                ragRB.Add(r);
                r.useGravity = false;
                r.isKinematic = true;

            }


        }


    }


    public void AktvRagnukke()
    {
        
        Instantiate(mana, transform);
       

        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = false;
                
                upper.isTrigger = true;
                down.isTrigger = true;
                head.isTrigger = true;
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

        
        
        torsoRB.AddForce(-transform.forward * forcePower);

        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(head);
        Destroy(GetComponent<Rigidbody>());
        StartCoroutine(disappear());
    }


    IEnumerator disappear()
    {
        yield return new WaitForSeconds(3);
        stopRagdoll();
        
        

    }

    void stopRagdoll()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = true;
                
                
            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = false;
                r.isKinematic = true;

            }


        }
    }

    public void StartDestroying()
    {
        StartCoroutine(DestroyObject());
    }

    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }





}
