using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixRotation : MonoBehaviour
{

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        rotationX = transform.rotation.x;
        rotationY = transform.rotation.y;
        rotationZ = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion LockRot = Quaternion.Euler(rotationX, rotationY, rotationZ);   
    }
}
