using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScritp : MonoBehaviour
{

    public float range;
    public float damage;

    private float nextTimeToFire = 0f;
    public float fireRate;

    public GameObject bulletPrefab;

    public GameObject GunTip;

    public Transform targetTransform;

    Vector3 moveDirection;

    public Animator playerAnim;

    public AudioSource gun, gunClickSource;
    public AudioClip gunShot, gunClick, reloadingStart, reloadingEnd;

    public bool CanShoot;
    public bool isAutomatic;
    bool isReloading;
    bool outOfAmmo;

    public ammo ammoScript;

    // Start is called before the first frame update
    void Start()
    {
        CanShoot = true;
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {

        GetInputs();


        if (CanShoot)
        {
            if (!isAutomatic)
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Fire();
                }
            }

            if(isAutomatic)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Fire();
                }
            }
        }
    }



    void Fire()
    {

        

        if (ammoScript.amount > 0)
        {
            print("shoot");
            Instantiate(bulletPrefab, GunTip.transform.position, GunTip.transform.rotation);
            ammoScript.amount -= 1;
            gun.clip = gunShot;
            gun.Play();
          
        }

        
        
            if (ammoScript.amount <= 0)
            {
        
                print("out of ammo");
                gunClickSource.clip = gunClick;
                gunClickSource.Play();
            
            }
        

        RaycastHit hit;
        if (Physics.Raycast(GunTip.transform.position, GunTip.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }


    }

    void GetInputs()
    {
        
        
            if (Input.GetKeyDown(KeyCode.R))
            {
                 
                float bullets = ammoScript.amount;

                if (!isReloading && bullets < ammoScript.maxAmmo)
                {
                    StartCoroutine(ReloadGun());
                    isReloading = true;
                }

            }
        
    }

    IEnumerator ReloadGun()
    {


        ammoScript.amount = 0f;

        CanShoot = false;
        gun.clip = reloadingStart;
        gun.Play();
        yield return new WaitForSeconds(2);
        gun.clip = reloadingEnd;
        gun.Play();
        ammoScript.amount = ammoScript.maxAmmo;
        CanShoot = true;
        isReloading = false;
        outOfAmmo = false;
    }








}
