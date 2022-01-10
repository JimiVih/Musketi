using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour
{

    public float speed;
    private float walkInput;

    Rigidbody rb;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        walkInput = Input.GetAxis("Horizontal");

    }


    void FixedUpdate()
    {

        rb.velocity = new Vector3(walkInput * speed, rb.velocity.y, 0);


    }


}
