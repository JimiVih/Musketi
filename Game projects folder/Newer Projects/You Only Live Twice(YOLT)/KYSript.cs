using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYSript : MonoBehaviour
{

    public GameObject bensa, sytytin;
    public bool check;

    public float lasku;

    void Start()
    {
        bensa.SetActive(false);
        sytytin.SetActive(false);

        check = false;
    }

    public void BensaCheck()
    {

        if(lasku == 1 || check == true)
        {
            check = true;

            if(lasku == 2)
            {
                bensa.SetActive(true);
            }
            else if(lasku > 2)
            {
                lasku = 0;
                check = false;
            }


        }


    }





}
