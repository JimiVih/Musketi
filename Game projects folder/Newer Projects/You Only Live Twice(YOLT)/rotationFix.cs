using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationFix : MonoBehaviour
{

    Transform myObj;
    GameObject player;
    public Transform handInd;
    public Transform mousePosTarg;

    public float maxRadians;
    public float maxMagnitude;

    public float fixedRotationX;
    public float fixedRotationY;
    public float fixedRotationZ;

    // Start is called before the first frame update
    void Start()
    {
        myObj = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = mousePosTarg.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadians, maxMagnitude);
        transform.rotation = Quaternion.LookRotation(newDirection);

        
        
    }
}
