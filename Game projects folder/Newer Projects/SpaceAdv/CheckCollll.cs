using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollll : MonoBehaviour
{

    public collectables ChkColl;
    private Animator tääopjekti;




    // Start is called before the first frame update
    void Start()
    {


        tääopjekti = GetComponent<Animator>();
    }

  



    public void NextAnimationPLZ()
    {

        var kerätyt = ChkColl.collected;
        var kerättävät = ChkColl.colcdAmount;

        if (kerätyt == kerättävät)
        {
            tääopjekti.SetBool("allCollected", true);
        }

    }


}
