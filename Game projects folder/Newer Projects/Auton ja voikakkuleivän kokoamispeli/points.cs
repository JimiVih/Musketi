using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour
{

    public GameObject toinen_kerros, kolmas_kerros, Winner;
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }
   

    void Update()
    {
        score.text = "Score: " + scoreValue;

        if (scoreValue == 3)
        {
            toinen_kerros.SetActive(true);
        }

        if (scoreValue == 6)
        {
            kolmas_kerros.SetActive(true);
        }

        if (scoreValue == 9)
        {
            Winner.SetActive(true);
        }

    }
}
