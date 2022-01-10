using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCntrl : MonoBehaviour
{

    public float speedHor;
    public float speedVer;
    public float RotX;
    private float RotXstay = 0;

    public float cooldown;

    public SphereCast raycastScritp;

    private float coolDownEnds = 0;
   

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(RotXstay, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.Rotate(0, Input.GetAxis("Horizontal") * speedHor * Time.deltaTime, 0);
        transform.Rotate(0, 0, Input.GetAxis("Vertical") * speedHor * Time.deltaTime);


        if (Input.GetButtonDown("Fire1") && Time.time >= coolDownEnds)
        {
            coolDownEnds = Time.time + 1f / cooldown;
            raycastScritp.rayHit();

        }

    }




}
