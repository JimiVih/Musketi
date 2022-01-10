using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemript : MonoBehaviour
{

    public float add;

    public KYSript kys;



    public void Addnumber()
    {

        kys.lasku += add;
        kys.BensaCheck();

    }



}
