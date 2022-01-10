using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEvent : MonoBehaviour
{


    public GameObject player;
    public GameObject enemy1, enemy2;
    
    public Animator carAnim;

    public GameObject playerCam, carCam;

    public AudioSource carAudSour;
    public AudioClip carEngine;


    void OnTriggerEnter(Collider coll)
    {

        if(coll.gameObject.tag == "Player")
        {
      //      player.GetComponent<PlayerScript1>().CanMove = false;
            player.GetComponent<GunScritp>().CanShoot = false;
            
            carCam.SetActive(true);
            carAnim.SetBool("drive", true);
            carAudSour.clip = carEngine;
            carAudSour.Play();
            
            StartCoroutine(countDown());
        }

    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(8);
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        yield return new WaitForSeconds(2);
        carCam.SetActive(false);
       // player.GetComponent<PlayerScript1>().CanMove = true;
        player.GetComponent<GunScritp>().CanShoot = true;
        gameObject.SetActive(false);
        
    }


}
