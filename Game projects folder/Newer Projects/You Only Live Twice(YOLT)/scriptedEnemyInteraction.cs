using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class scriptedEnemyInteraction : MonoBehaviour
{
    public dialogNoAnsw dialog;

    public Transform mousePosTarg;
    public float dist;

    float walkspeed = 5;

    public Transform enemy;

    public Transform Player;

    public float maxRadians;
    public float maxMagnitude;

    public Rig rig;
    public Rigidbody rb;

    public Transform playerTrans;

    public bool SeePlayer;

    private float nextTimeToFire = 0f;
    public float fireRate;

    public float maxDistance;
    public LayerMask colPlay;
    public LayerMask dontCol;

    public GameObject bulletPref;
    public Transform BulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rig.weight = 0f;
        SeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SeePlayer == true)
        {

            dialog.enabled = true;

            Vector3 targetDirection = mousePosTarg.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, maxMagnitude);
            transform.rotation = Quaternion.LookRotation(newDirection);


           // if (Time.time >= nextTimeToFire)
           // {
              //  nextTimeToFire = Time.time + 1f / fireRate;
            //    Fire();
          //  }
        }

        // dist = Vector3.Distance(Player.position, enemy.transform.position);

        //  if(dist < 8)
        //  {
        //    enemy.transform.Translate(Vector3.right * Time.deltaTime * walkspeed, Space.World);
        //  }


    }


    //  void OnTriggerEnter(Collider coll)
    //{
    //   if(coll.gameObject.tag == "Player")
    // {
    //   nextTimeToFire = Time.time + 1f / fireRate;
    // rig.weight = 1f;
    //  SeePlayer = true;
    // }
    // }


    void FixedUpdate()
    {

        if (SeePlayer == true)
        {
            rb.MoveRotation(Quaternion.Euler(new Vector3(0, 90 * Mathf.Sign(playerTrans.position.x - transform.position.x), 0)));
        }


        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, colPlay))
        {
            print("cant see player");
            nextTimeToFire = Time.time + 1f / fireRate;
            rig.weight = 1f;
            SeePlayer = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("did hit");
        }


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, dontCol))
        {
            rig.weight = 0f;
            SeePlayer = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }




    }


    private void Fire()
    {

        Instantiate(bulletPref, BulletSpawn.transform.position, BulletSpawn.transform.rotation);

    }
}
