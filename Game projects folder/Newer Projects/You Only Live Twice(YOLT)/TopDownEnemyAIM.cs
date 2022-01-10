using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TopDownEnemyAIM : MonoBehaviour
{
    public Transform playerTrans;
    public bool canShoot;

    public Rig rig;
    private float nextTimeToFire = 0f;
    public float fireRate;

    public AudioSource gunAudioSour;
    public AudioClip gunSound;

    public GameObject bulletPref;
    public Transform BulletSpawn;

    public float maxDistance;
    public LayerMask colPlay;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (canShoot == true)
        {

          //  Vector3 targetDirection = mousePosTarg.position - transform.position;

           // Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, maxMagnitude);
           // transform.rotation = Quaternion.LookRotation(newDirection);
          //  rig.weight = 1f;

            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
        }
    }

    void FixedUpdate()
    {
      
    }


    private void Fire()
    {
        gunAudioSour.clip = gunSound;
        gunAudioSour.Play();
        Instantiate(bulletPref, BulletSpawn.transform.position, BulletSpawn.transform.rotation);

    }



}
