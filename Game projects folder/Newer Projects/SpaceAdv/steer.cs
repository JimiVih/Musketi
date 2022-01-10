using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steer : MonoBehaviour
{

    public float speedHor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speedHor * Time.deltaTime);
        
    }
}
