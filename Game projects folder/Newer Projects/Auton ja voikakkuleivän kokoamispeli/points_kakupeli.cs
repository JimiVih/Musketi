using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points_kakupeli : MonoBehaviour
{
    public GameObject toinen_kerros, kolmas_kerros, aikapaska, Winner;
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }


    void Update()
    {
        score.text = "Score: " + scoreValue;

        if (scoreValue == 5)
        {
            aikapaska.SetActive(true);
        }

    }

}
