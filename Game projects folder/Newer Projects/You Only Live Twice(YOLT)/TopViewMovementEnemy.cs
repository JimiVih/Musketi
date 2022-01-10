using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TopViewMovementEnemy : MonoBehaviour
{
    public Transform playerTrans;
    GameObject player;
    NavMeshAgent enemyAI;
    private Rigidbody parentRB;
    public BoxCollider upper, head;
    public CapsuleCollider down;
    public Rigidbody torsoRB;
    public GameObject aim;
    public float forcePower;
    
    public int stopDistance;
    public int doesShoot;
    Animator anim;
    Vector3 playerDestination;

    public Vector3 velocity;

    public TopDownEnemyAIM aimScript;
    public bool dead;
    bool ActRandShoot;
    bool startShooting;
    public GameObject mana;
  

    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> ragRB = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        EtsiRagnukke();
        anim = GetComponent<Animator>();
        parentRB = GetComponent<Rigidbody>();
        enemyAI = GetComponent<NavMeshAgent>();
        enemyAI.enabled = false;
        enemyAI.enabled = true;
        player = GameObject.FindWithTag("Player");
        playerTrans = player.transform;
        aimScript.canShoot = false;
        dead = false;
       // mana = GameObject.Find("mana");
        mana.SetActive(false);
        RandomStopDist();
        startShooting = false;
        transform.parent = null;
        anim.SetBool("runFor", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            FollowPlayer();
        }
    }

    void RandomStopDist()
    {
        stopDistance = (Random.Range(30, 80));
        enemyAI.stoppingDistance = stopDistance;
    }

    void FollowPlayer()
    {
       
        enemyAI.SetDestination(playerTrans.position);
        velocity = enemyAI.velocity;
        //float distance = Vector3.Distance(transform.position, playerTrans.position);

       if(velocity.x > 0 || velocity.z > 0)
        {
            startShooting = true;
            anim.SetBool("runFor", true);
            if (ActRandShoot == true)
            {
                RandomShootBool();
                ActRandShoot = false;
            }
        }

        if (startShooting)
        {

            if (velocity.x == 0 && velocity.z == 0)
            {
                anim.SetBool("runFor", false);
                aimScript.canShoot = true;
                ActRandShoot = true;
            }
        }
        
        
        
    }

    void RandomShootBool()
    {
        
        
        doesShoot = Random.Range(0, 4);

        if(doesShoot == 1)
        {
            print("canShoot");
            aimScript.canShoot = true;
        }
        else
        {
            print("cannotShoot");
            aimScript.canShoot = false;
        }
    }


    public void EtsiRagnukke()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                c.isTrigger = true;
                RagdollParts.Add(c);
                upper.isTrigger = false;
                down.isTrigger = false;
                head.isTrigger = false;
                

            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                ragRB.Add(r);
                r.useGravity = false;
                r.isKinematic = true;

            }


        }


    }


    public void AktvRagnukke()
    {
        dead = true;
        print("akti");
        mana.SetActive(true);


        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = false;
                
                upper.isTrigger = true;
                down.isTrigger = true;
                head.isTrigger = true;
                
            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = true;
                r.isKinematic = false;

            }


        }


        torsoRB.AddForce(-transform.forward * forcePower);

        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(head);
        Destroy(GetComponent<Rigidbody>());
        StartCoroutine(disappear());
    }

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(3);
        stopRagdoll();



    }

    void stopRagdoll()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        Rigidbody[] rbs = this.gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                anim.enabled = false;
                c.isTrigger = true;


            }

        }

        foreach (Rigidbody r in rbs)
        {

            if (r.gameObject != this.gameObject)
            {
                r.useGravity = false;
                r.isKinematic = true;

            }


        }
        StartDestroying();
    }

    public void StartDestroying()
    {
        StartCoroutine(DestroyObject());
    }

    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }




}
