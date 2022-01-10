using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCover : MonoBehaviour
{

    public LayerMask dontCol;
    public int maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, dontCol))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("did hit");
        }

    }

}
