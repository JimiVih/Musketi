using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAimPositionfix : MonoBehaviour
{

    public Transform playerTrans;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, playerTrans.position.z);
    }
}
