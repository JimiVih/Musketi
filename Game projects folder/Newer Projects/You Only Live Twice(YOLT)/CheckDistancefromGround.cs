using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistancefromGround : MonoBehaviour
{
    public float floorDist;

    public GameObject CharacterPos;
    public GameObject FloorPos;

    Vector3 CharPos;
    Vector3 FloPos;


    // Start is called before the first frame update
    void Start()
    {
        
        CharPos = CharacterPos.transform.position;
        FloPos = FloorPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FloorMeasure();
        

    }

    void FloorMeasure()
    {

        RaycastHit hit;

        if (Physics.Linecast(CharPos, FloPos, out hit))
        {
            floorDist = hit.distance;
        }

    }


}
