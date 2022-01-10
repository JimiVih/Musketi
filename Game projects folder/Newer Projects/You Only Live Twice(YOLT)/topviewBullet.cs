using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topviewBullet : MonoBehaviour
{
    public float Damage = 15;
    public float speed = 0;
    public float forcePower;
    Rigidbody bulletRB;

    public EnemyRipt ragdollENEM;

    public float life = 1f;
    private float lifeTimer;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 13);
        lifeTimer = Time.time;
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * speed);
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.x = 0;
        moveDirection.Normalize();
    }



    // Update is called once per frame

    void Update()
    {


        if (Time.time > lifeTimer + life)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "enemy")
        {
            print("vittu");
            var ragENEMY = coll.gameObject.GetComponent<topViewEnemyHealth>();

            ragENEMY.Health -= Damage;

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        if (coll.gameObject.tag == "scriptedEnemy")
        {
            print("vittu");
            var ragScript = coll.gameObject.GetComponent<scriptedEnemyHealth>();

            ragScript.Health -= Damage;

            Destroy(gameObject);
        }


    }
}
