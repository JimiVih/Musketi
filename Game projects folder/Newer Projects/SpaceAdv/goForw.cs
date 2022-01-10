using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goForw : MonoBehaviour
{

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);

    }
}
