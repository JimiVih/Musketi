using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchViews : MonoBehaviour
{

    public GameObject sideView, topView, sideViewPlayer, topViewPlayer, roof;
    public Transform sidePlayer, topPlayer;
    public BoxCollider wall;

    public GameObject[] enemies;

    bool exited;

    
    void Start()
    {
        exited = true;
        wall.enabled = false;
        HideEnemies();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (exited)
        {
            if (coll.gameObject.tag == "Player")
            {
                ChangeView();
                exited = false;
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            exited = true;
        }
    }

    public void ChangeView()
    {
        sideViewPlayer.SetActive(false);
        topViewPlayer.SetActive(true);
        topPlayer.position = sidePlayer.position;
        sideView.SetActive(false);
        topView.SetActive(true);
        wall.enabled = true; ;
        SpawnEnemies();
        roof.SetActive(false);
    }

    public void SpawnEnemies()
    {
        foreach (GameObject enem in enemies)
        {
            enem.SetActive(true);
        }
    }

    public void HideEnemies()
    {
        foreach (GameObject enem in enemies)
        {
            enem.SetActive(false);
        }
    }
}
