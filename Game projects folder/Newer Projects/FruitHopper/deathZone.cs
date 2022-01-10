using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{

    GameManager gameManager;
    GameObject GM_object;

    // Start is called before the first frame update
    void Start()
    {
        GM_object = GameObject.Find("gameManager");
        gameManager = GM_object.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.playerHealth = 0;
        }
    }

}
