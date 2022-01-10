using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTail : MonoBehaviour
{
    public Transform tailTargetFollow;
    public float tailFollowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, tailTargetFollow.position, tailFollowSpeed * Time.deltaTime);
    }
}
