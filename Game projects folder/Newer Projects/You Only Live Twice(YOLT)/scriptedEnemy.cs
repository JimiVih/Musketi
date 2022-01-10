using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptedEnemy : MonoBehaviour
{
    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> ragRB = new List<Rigidbody>();

    private Rigidbody parentRB;

    public BoxCollider upper, head;
    public CapsuleCollider down;
    public GameObject headd;

    public Rigidbody torsoRB;
    public float forcePower;

    public Transform Player;


    public GameObject aim;

    Animator anim;

    private float rightMov = 3f;
    private float leftMov = -3f;
    public float walkSpeed;
    public float dist;

    public float vittu;
    public bool startShooting;

    public scriptedEnemyInteraction aimScript;



    // Start is called before the first frame update
    private void Start()
    {
        EtsiRagnukke();
        anim = GetComponent<Animator>();
        parentRB = GetComponent<Rigidbody>();
        startShooting = false;
    }


    void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);
        float rotY = transform.eulerAngles.y;
        vittu = rotY;
        if (aimScript.SeePlayer == true)
        {




                //transform.Translate(Vector3.right * Time.deltaTime * walkspeed, Space.World)
            

            if (dist > 5f)
            {
                if (rotY == 270)
                {
                    walkSpeed = 0f;
                    anim.SetBool("runFor", false);
                    anim.SetBool("runBack", false);

                }

                if (rotY == 90)
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

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = false;
                r.isKinematic = true;

            }


        }


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
                RagdollParts.Add(c);
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
    }







    

}
