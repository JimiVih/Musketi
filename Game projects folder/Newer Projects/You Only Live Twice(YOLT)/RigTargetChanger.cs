using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigTargetChanger : MonoBehaviour
{
    GameObject aimTrans;
    GameObject player;
    TwoBoneIKConstraint TwoBoneIKConstraint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aimTrans = GameObject.FindGameObjectWithTag("aimTrans");
        TwoBoneIKConstraint = gameObject.GetComponent<TwoBoneIKConstraint>();

        
        
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
