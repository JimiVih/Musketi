using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform mirroredObject;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mirror = new Vector3(-transform.position.x, 0, -transform.position.z);
        mirroredObject.position = mirror;
    }
}
