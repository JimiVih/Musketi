using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GameObject GM_object;
    GameObject player;
    PlayerMovement playerMove;
    GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        GM_object = GameObject.Find("gameManager");
        gameManager = GM_object.GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if(coll.transform.tag == "Player")
        {
            StartCoroutine(Explosion());
        }

    }

    IEnumerator Explosion()
    {
        rb.gravityScale = 0f;
        anim.SetBool("explode", true);
        gameManager.playerHealth -= 1;
        gameObject.transform.GetComponent<PolygonCollider2D>().enabled = false;
        gameObject.transform.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


}
