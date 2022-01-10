using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningZone : MonoBehaviour
{
    GameManager gameManager;
    GameObject GM_object;

    private void Start()
    {
        GM_object = GameObject.Find("gameManager");
        gameManager = GM_object.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            gameManager.gameWon = true;
        }
    }

}
