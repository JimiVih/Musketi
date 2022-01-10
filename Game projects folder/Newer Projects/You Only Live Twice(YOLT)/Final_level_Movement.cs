using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Final_level_Movement : MonoBehaviour
{
    public float walkSpeed = 2.5f;

    private float inputMovement;
    private Animator animator;
    private Rigidbody rb;

    public Image panel;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        panel.DOFade(0, 3);
    }


    // Update is called once per frame
    void Update()
    {
        inputMovement = Input.GetAxis("Horizontal");
        float currentSpeed = inputMovement;
        animator.SetFloat("speed", inputMovement);

        if (currentSpeed > 0.01f)
        {

            animator.SetBool("walk", true);
        }

        if (currentSpeed == 0)
        {
            animator.SetBool("walk", false);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, inputMovement * walkSpeed);
        

        //flip
     
    }
}
