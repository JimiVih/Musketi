using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {


    public GameObject autonosa_1, autonosa_2, autonosa_3, autonosa_4, autonosa_5, autonosa_6, autonosa_7, autonosa_8, autonosa_9, autonosa_1_spot, autonosa_2_spot, autonosa_3_spot, autonosa_4_spot, autonosa_5_spot, autonosa_6_spot, autonosa_7_spot, autonosa_8_spot, autonosa_9_spot;
    public GameObject autonosa_ylhäältä_1, autonosa_ylhäältä_2, autonosa_ylhäältä_3, autonosa_ylhäältä_4, autonosa_ylhäältä_5, autonosa_ylhäältä_6, autonosa_ylhäältä_7, autonosa_ylhäältä_8, autonosa_ylhäältä_9;
    Vector2 autonosa_1InitialPos, autonosa_2InitialPos, autonosa_3InitialPos, autonosa_4InitialPos, autonosa_5InitialPos, autonosa_6InitialPos, autonosa_7InitialPos, autonosa_8InitialPos, autonosa_9InitialPos;



    void Start()
    {
        autonosa_1InitialPos = autonosa_1.transform.position;
        autonosa_2InitialPos = autonosa_2.transform.position;
        autonosa_3InitialPos = autonosa_3.transform.position;
        autonosa_4InitialPos = autonosa_4.transform.position;
        autonosa_5InitialPos = autonosa_5.transform.position;
        autonosa_6InitialPos = autonosa_6.transform.position;
        autonosa_7InitialPos = autonosa_7.transform.position;
        autonosa_8InitialPos = autonosa_8.transform.position;
        autonosa_9InitialPos = autonosa_9.transform.position;

    }

    public void Dragautonosa_1()
    {
        autonosa_1.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_2()
    {
        autonosa_2.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_3()
    {
        autonosa_3.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_4()
    {
        autonosa_4.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_5()
    {
        autonosa_5.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_6()
    {
        autonosa_6.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_7()
    {
        autonosa_7.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_8()
    {
        autonosa_8.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_9()
    {
        autonosa_9.transform.position = Input.mousePosition;
    }


    public void Dropautonosa_1()
    {
        float Distance = Vector3.Distance(autonosa_1.transform.position, autonosa_1_spot.transform.position);
        if (Distance < 100)
        {
            autonosa_1.transform.position = autonosa_1_spot.transform.position;
            points.scoreValue += 1;
            autonosa_1.SetActive(false);
            autonosa_ylhäältä_1.SetActive(true);

        }
        else
        {
            autonosa_1.transform.position = autonosa_1InitialPos;
        }

    }



    public void Dropautonosa_2()
    {
        float Distance = Vector3.Distance(autonosa_2.transform.position, autonosa_2_spot.transform.position);
        if (Distance < 50)
    {
            autonosa_2.transform.position= autonosa_2_spot.transform.position;
            points.scoreValue += 1;
            autonosa_2.SetActive(false);
            autonosa_ylhäältä_2.SetActive(true);

    }
    else
    {
        autonosa_2.transform.position = autonosa_2InitialPos;
    }
    
 }



    public void Dropautonosa_3()
    {
        float Distance = Vector3.Distance(autonosa_3.transform.position, autonosa_3_spot.transform.position);
        if (Distance < 50)
        {
            autonosa_3.transform.position = autonosa_3_spot.transform.position;
            points.scoreValue += 1;
            autonosa_3.SetActive(false);
            autonosa_ylhäältä_3.SetActive(true);
        }
        else
        {
            autonosa_3.transform.position = autonosa_3InitialPos;
        }

    }


    public void Dropautonosa_4()
    {
        float Distance = Vector3.Distance(autonosa_4.transform.position, autonosa_4_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_4.transform.position = autonosa_4_spot.transform.position;
            autonosa_4.SetActive(false);
            autonosa_ylhäältä_4.SetActive(true);
        }
        else
        {
            autonosa_4.transform.position = autonosa_4InitialPos;
        }

    }


    public void Dropautonosa_5()
    {
        float Distance = Vector3.Distance(autonosa_5.transform.position, autonosa_5_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_5.transform.position = autonosa_5_spot.transform.position;
            autonosa_5.SetActive(false);
            autonosa_ylhäältä_5.SetActive(true);
        }
        else
        {
            autonosa_5.transform.position = autonosa_5InitialPos;
        }

    }


    public void Dropautonosa_6()
    {
        float Distance = Vector3.Distance(autonosa_6.transform.position, autonosa_6_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_6.transform.position = autonosa_6_spot.transform.position;
            autonosa_6.SetActive(false);
            autonosa_ylhäältä_6.SetActive(true);
        }
        else
        {
            autonosa_6.transform.position = autonosa_6InitialPos;
        }

    }


    public void Dropautonosa_7()
    {
        float Distance = Vector3.Distance(autonosa_7.transform.position, autonosa_7_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_7.transform.position = autonosa_7_spot.transform.position;
            autonosa_7.SetActive(false);
            autonosa_ylhäältä_7.SetActive(true);
        }
        else
        {
            autonosa_7.transform.position = autonosa_7InitialPos;
        }

    }


    public void Dropautonosa_8()
    {
        float Distance = Vector3.Distance(autonosa_8.transform.position, autonosa_8_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_8.transform.position = autonosa_8_spot.transform.position;
            autonosa_8.SetActive(false);
            autonosa_ylhäältä_8.SetActive(true);
        }
        else
        {
            autonosa_8.transform.position = autonosa_8InitialPos;
        }

    }


    public void Dropautonosa_9()
    {
        float Distance = Vector3.Distance(autonosa_9.transform.position, autonosa_9_spot.transform.position);
        if (Distance < 50)
        {
            points.scoreValue += 1;
            autonosa_9.transform.position = autonosa_9_spot.transform.position;
            autonosa_9.SetActive(false);
            autonosa_ylhäältä_9.SetActive(true);
        }
        else
        {
            autonosa_9.transform.position = autonosa_9InitialPos;
        }

    }




}
