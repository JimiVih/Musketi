using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnBody : MonoBehaviour
{
    ghostMECH ghostmek;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghostmek = player.GetComponentInChildren<ghostMECH>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if(ghostmek.SpawnReady == true)
        {
            print("mouse over body");
            if(Input.GetMouseButtonDown(1))
            {
                ghostmek.canTeleport = false;
                Destroy(gameObject);
            }
        }
    }

}
