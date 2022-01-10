using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openStorageDoor : MonoBehaviour
{

    public GameObject playerCam, storageCam, player;
    public GameObject[] enemyProps;
    public GameObject execute_text;
    public bool entered;
    public Animator storageDoor;


    // Start is called before the first frame update
    void Start()
    {
        storageCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider coll)
    {

        if(coll.gameObject.tag == "Player")
        {
            print("Entered");
            entered = true;
            execute_text.SetActive(true);
            if (entered == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("open");
                    StartCoroutine(OpenStorageDoor());
                    entered = false;
                }
            }

        }

    }

    void OnTriggerExit(Collider coll)
    {

        if(coll.gameObject.tag == "Player")
        {
            print("Exited");
            entered = false;
            execute_text.SetActive(false);
        }

    }


    IEnumerator OpenStorageDoor()
    {
        player.SetActive(false);
        playerCam.SetActive(false);
        storageCam.SetActive(true);
        yield return new WaitForSeconds(2);
        storageDoor.SetBool("open", true);
        yield return new WaitForSeconds(3.5f);
        SpawnEnemyprops();
        yield return new WaitForSeconds(1.5f);
        playerCam.SetActive(true);
        storageCam.SetActive(false);
        player.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        player.GetComponentInChildren<ghostMECH>().missionComplete = true;
        DestroyEnemyprops();

    }

    void SpawnEnemyprops()
    {
        foreach (GameObject Eprop in enemyProps)
        {
            Eprop.SetActive(true);
        }
    }

    void DestroyEnemyprops()
    {
        foreach (GameObject Eprop in enemyProps)
        {
            Destroy(Eprop);
        }
    }


}
