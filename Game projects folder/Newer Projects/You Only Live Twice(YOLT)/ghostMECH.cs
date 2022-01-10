using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ghostMECH : MonoBehaviour
{

    public LayerMask mouseAimMask;
    public LayerMask wall;
    private Camera mainCamera;
    
    public GameObject AimMask;
    public GameObject SpawnMask;
    public GameObject PlayerCam;
    public GameObject SpawnCam;
    public Transform targetTransform;
    public Transform wallCheck;
    public ParticleSystem manaFog;

    public float Mana;

    public Transform PlayerTrans;

    public bool SpawnReady;
    public bool canTeleport;
    public bool canSpawn;
    public bool missionComplete;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpawnCam.SetActive(false);
        SpawnMask.SetActive(false);
        
        SpawnReady = false;
        
        canTeleport = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask)) 
        {
            targetTransform.position = hit.point;
        }

        

        if (canTeleport)
        {

            if (missionComplete && Input.GetKeyDown(KeyCode.B))
            {
                TakeBodyBack();
            }

            if (canSpawn)
            {
                print("canSpawn");
                
                if (SpawnReady)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PlayerTrans.position = new Vector3(targetTransform.position.x, targetTransform.position.y, 4.86f);
                    }
                }
                
                   
            }
                
                
                
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                SpawnCam.SetActive(true);
                SpawnMask.SetActive(true);
                PlayerCam.SetActive(false);
               
                SpawnReady = true;
            }
            else
            {
                
                SpawnMask.SetActive(false);
                SpawnCam.SetActive(false);
                PlayerCam.SetActive(true);
                SpawnReady = false;
                manaFog.Stop();

            }


        }
        
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (SpawnReady)
        {
            if (other.gameObject.tag == ("spawnPlatform"))
            {
                canSpawn = true;
                manaFog.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (SpawnReady)
        { 
            if (other.gameObject.tag == ("spawnPlatform"))
            {
                canSpawn = false;
                manaFog.Stop();
            }
        }
    }

    void TakeBodyBack()
    {
        GameObject body;
        body = GameObject.FindGameObjectWithTag("body");
        Destroy(body);
        canTeleport = false;
        missionComplete = false;
    }


}
