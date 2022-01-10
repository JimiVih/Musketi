using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berry : MonoBehaviour
{
    GameObject GM_object;
    GameObject player;
    PlayerMovement playerMove;
    GameManager gameManager;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        GM_object = GameObject.Find("gameManager");
        gameManager = GM_object.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (playerMove.grabbing == true)
        {
            if (coll.gameObject.tag == "berry_basket")
            {
                GivePoints();
            }

            if (coll.gameObject.tag == "fruit_basket")
            {
                TakePoints();
            }
        }

    }

    

    void GivePoints()
    {
        gameManager.points += 10;
        Destroy(gameObject);
    }

    void TakePoints()
    {
        gameManager.points -= 5;
        Destroy(gameObject);
    }
}
