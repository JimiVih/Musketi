using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float Damage = 0.1f;
    public float speed = 0;
    public float forcePower;
    Rigidbody bulletRB;

    private SphereCollider collider;

    public EnemyRipt ragdollENEM;

    public float life = 1f;
    private float lifeTimer;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
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


    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            print("vittu");
            var PlayerHealth = coll.gameObject.GetComponent<Bars>();

            PlayerHealth.Health -= Damage;

            Destroy(gameObject);
        }
      //  else
      //  {
     //       Destroy(gameObject);
   //     }
        

        if(coll.gameObject.tag == "obsticle")
        {
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "enemy")
        {
            Physics.IgnoreCollision(coll.GetComponent<BoxCollider>(), collider);
        }


    }
}
