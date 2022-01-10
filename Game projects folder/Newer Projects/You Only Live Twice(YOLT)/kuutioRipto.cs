using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kuutioRipto : MonoBehaviour
{

    public Vector3 velositi;
    private Rigidbody rb;

    public float TimesHit;
    public bool Entered;

    public Image fillMiter;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }


    private void OnTriggerEnter(Collider coll)
    {
        if (Entered == false)
        {
            
                fillMiter.fillAmount += 0.05f;
                Entered = true;
            
        }

    }



    private void OnTriggerExit(Collider coll)
    {

        Entered = false;

    }






}
