using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAim : MonoBehaviour
{

  //  public Transform handInd;
    public Transform mousePosTarg;
 
    public float dist;

    float walkspeed = 5;

    private AudioSource gunAudioSour;
    public AudioClip gunSound;

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
        rig.weight = 1f;
        SeePlayer = false;
        gunAudioSour = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {



        if (SeePlayer == true)
        {

            Vector3 targetDirection = mousePosTarg.position - transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, maxMagnitude);
            transform.rotation = Quaternion.LookRotation(newDirection);
            rig.weight = 1f;

            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
        }


    }

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
           // rig.weight = 1f;
            SeePlayer = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("did hit");
        }


       if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, dontCol))
       {
            rig.weight = 0f;
           SeePlayer = false;
           Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
       }




    }


    private void Fire()
    {
        gunAudioSour.clip = gunSound;
        gunAudioSour.Play();
        Instantiate(bulletPref, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        
    }


   // private void Fire()
 //   {
       // var go = Instantiate(bulletPref);
       // go.transform.position = BulletSpawn.position;
     //   var bullet = go.GetComponent<bullet>();
   //     bullet.Fire(go.transform.position, BulletSpawn.eulerAngles, gameObject.layer);
 //   }




}
