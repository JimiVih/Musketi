using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;

public class PlayerScript1 : MonoBehaviour
{
    public Transform noCrouchAim;
    public Transform yesCrouchAim;
    public Transform enemyAimTrans;
    public Material playerMat;
    public Renderer rend;

    public float walkSpeed = 2.5f;
    public float whatIsSpeedWLK;
    public float whatIsSpeedCRCH;
    public float thrust = 2;
    public float jumpHeight = 5f;
    public float groundCheckRadius;
    public float Gravity = -9.81f;
    public Transform groundCheck;
    public float GChk_radius = 0.2f;

  //  public bool CanMove;

    public BoxCollider bxColUP, bxColDOWN;
    public bool ceiling;
    

    public Transform targetTransform;
    public LayerMask mouseAimMask;
    public LayerMask WhatIsGround;

    private float inputMovement;
    private Animator animator;
    private Rigidbody rb;
    public bool Grounded;
    private Camera mainCamera;

    public bool walking;
    public bool crouch;
    public bool canWalk;

    public GameObject bulletPref;
    public Transform BulletSpawn;

    Vector3 velocity;

    public Rig WeightChanger;

    private int FacingSign
    {
        get
        {
            Vector3 perp = Vector3.Cross(transform.forward, Vector3.forward);
            float dir = Vector3.Dot(perp, transform.up);
            return dir > 0f ? -1 : dir < 0f ? 1 : 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
     //   CanMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {



        if (canWalk)
        {
            inputMovement = Input.GetAxis("Horizontal");
        }
        var currentSpeed = animator.GetFloat("speed");

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask)) ;
        {
            targetTransform.position = hit.point;
        }

        if(currentSpeed > 0.01f)
        {

            animator.SetBool("walk", true);
        }
        else if(currentSpeed < -0.01f)
        {
            animator.SetBool("walk", true);
        }

        if(currentSpeed == 0)
        {
            animator.SetBool("walk", false);
        }



        if(Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {

            Jump();

        }

        if(Grounded && velocity.y < 0)
        {

            velocity.y = -2f;

        }

        velocity.y += Gravity * Time.deltaTime;

        bool running = animator.GetBool("walk");
        
        float TheSpeed = animator.GetFloat("speed");
        crouch = animator.GetBool("crouch");



            if (Input.GetKey(KeyCode.LeftControl))
            {
            animator.SetBool("crouch", true);
            walkSpeed = whatIsSpeedCRCH;
            bxColUP.isTrigger = true;
            enemyAimTrans.position = yesCrouchAim.position;
                
            }
            else
            {
                animator.SetBool("crouch", false);
                
            Notrigger();
            }
        


        //if (TheSpeed > 0.02)
        //{
          //  if (Input.GetKeyDown(KeyCode.S) && running)
            //{
              //  bxColUP.isTrigger = true;
                //animator.SetTrigger("roll");
                //WeightChanger.weight = 0;
                
                //StartCoroutine(DisapleFor());
            //}
        //}



    }




    IEnumerator DisapleFor()
    {
        
        
        yield return new WaitForSeconds(1);
        Notrigger();
        


    }

    public void Notrigger()
    {
        if (ceiling == false)
        {
           // WeightChanger.weight = 1;
            bxColUP.isTrigger = false;
            walkSpeed = whatIsSpeedWLK;
            enemyAimTrans.position = noCrouchAim.position;
        }
        else
        {
            walkSpeed = whatIsSpeedCRCH;
        }

    }

    
    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector3(inputMovement * walkSpeed, rb.velocity.y, 0);
        animator.SetFloat("speed", (FacingSign * rb.velocity.x) / walkSpeed);

        //flip
        rb.MoveRotation(Quaternion.Euler(new Vector3(0, 90 * Mathf.Sign(targetTransform.position.x - transform.position.x), 0)));

        //GroundChk
        Grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, WhatIsGround, QueryTriggerInteraction.Ignore);


    }


   // private void Fire()
    //{
      //  var go = Instantiate(bulletPref);
        //go.transform.position = BulletSpawn.position;
        //var bullet = go.GetComponent<bullet>();
       // bullet.Fire(go.transform.position, BulletSpawn.eulerAngles, gameObject.layer);
    //}


    public void Jump()
    {

        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -1 * Physics.gravity.y), ForceMode.VelocityChange);
        animator.SetTrigger("jump");

    }

    public void OnAnimatorIK()
    {

        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.RightHand, targetTransform.position);

    }


    void OnTriggerStay(Collider coll)
    {

        if(coll.gameObject.tag == "ceiling")
        {
            ceiling = true;
            animator.SetBool("ceiling", true);
            print("kekw");
        }

    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "ceiling")
        {
            ceiling = false;
            //Notrigger();
            animator.SetBool("ceiling", false);
        }

    }

    public void ChangeToGhostColor()
    {
        
        rend.material.DOColor(Color.cyan, 3);
        print("changeColor");
    }

    public void ChangeToNormalColor()
    {
        rend.material.DOColor(Color.white, 3);
    }

}
