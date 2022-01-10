using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timescript : MonoBehaviour
{
    public GameObject aines, hianoa, taso_1, taso_2, taso_3;

    void Start()
    {
        StartCoroutine (test());
    }
    
    IEnumerator test()
    {
        hianoa.SetActive(true);
        aines.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        taso_2.SetActive(true);       
        taso_1.SetActive(false);
    }
}
