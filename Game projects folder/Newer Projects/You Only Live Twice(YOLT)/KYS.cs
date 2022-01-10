using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{

    Bars bars;
    ghostMECH ghostmech;
    PlayerScript1 playerscript;
    public bool canKys;
    public GameObject playerRagdoll;
    public GameObject dialog;
    public GameObject E_text;
    GameObject player;
    public Transform ragdollSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canKys = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            print("playerInside");
            playerscript = other.GetComponent<PlayerScript1>();            
            player = other.gameObject;
            ghostmech = other.GetComponentInChildren<ghostMECH>();
            bars = other.GetComponent<Bars>();
            if(bars.Mana >= 1)
            {
                print("enough mana");
                canKys = true;
                E_text.SetActive(true);
                GetInput();
            }
            else
            {
                E_text.SetActive(false);
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        E_text.SetActive(false);
        canKys = false;
    }

    void GetInput()
    {
        if(canKys && Input.GetKeyDown(KeyCode.E))
        {
            print("KYS");
            playerscript.ChangeToGhostColor();
            ghostmech.canTeleport = true;
            Instantiate(playerRagdoll, player.transform);
            canKys = false;
            bars.Mana = 0;
            dialog.SetActive(true);
            
        }
    }

}
