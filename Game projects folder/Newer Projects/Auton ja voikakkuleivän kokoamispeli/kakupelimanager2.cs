using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakupelimanager2 : MonoBehaviour
{
    public GameObject location, eka_taso, toka_taso, kolmas_taso, Next_state, autonosa_1, autonosa_2, autonosa_3, autonosa_4, autonosa_5, autonosa_6, autonosa_7, autonosa_8, autonosa_9, Kulho_1, Kulho_2, Kulho_3, Kulho_4, Kulho_5, Kulho_6, Kulho_7, Kulho_8, Kulho_9, aines_1, aines_2, aines_3, aines_4, aines_5, hienoateksti, autonlokaatio_2, autonlokaatio_3;
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


    public void continue_to_next_state()
    {
        eka_taso.SetActive(false);
        toka_taso.SetActive(true);

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

    // autonosa = soossi
    // kulho = soossin paikka
    // aines ylhäältä = soossi kulho

    public void Dropautonosa_1()
    {
        float Distance = Vector3.Distance(autonosa_1.transform.position, Kulho_1.transform.position);
        if (Distance < 250)
        {
            autonosa_1.transform.position = Kulho_1.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_1.SetActive(false);
            Kulho_1.SetActive(true);
            autonosa_ylhäältä_2.transform.position = autonosa_ylhäältä_1.transform.position;

        }
        else
        {
            autonosa_1.transform.position = autonosa_1InitialPos;
        }

    }

    public void Dropautonosa_2()
    {
        float Distance = Vector3.Distance(autonosa_2.transform.position, Kulho_2.transform.position);
        if (Distance < 250)
        {
            autonosa_2.transform.position = Kulho_2.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_2.SetActive(false);
            Kulho_2.SetActive(true);
            autonosa_ylhäältä_3.transform.position = autonosa_ylhäältä_2.transform.position;
            

        }
        else
        {
            autonosa_2.transform.position = autonosa_2InitialPos;
        }




    }

    public void Dropautonosa_3()
    {
        float Distance = Vector3.Distance(autonosa_3.transform.position, Kulho_3.transform.position);
        if (Distance < 250)
        {
            autonosa_3.transform.position = Kulho_3.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_3.SetActive(false);
            Kulho_3.SetActive(true);
            autonosa_ylhäältä_4.transform.position = autonosa_ylhäältä_3.transform.position;
            toka_taso.SetActive(true);


        }
        else
        {
            autonosa_3.transform.position = autonosa_3InitialPos;
        }




    }


    public void Dropautonosa_4()
    {
        float Distance = Vector3.Distance(autonosa_4.transform.position, Kulho_4.transform.position);
        if (Distance < 250)
        {
            autonosa_4.transform.position = Kulho_4.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_4.SetActive(false);
            Kulho_4.SetActive(true);
            autonosa_ylhäältä_5.transform.position = autonosa_ylhäältä_4.transform.position;
            


        }
        else
        {
            autonosa_4.transform.position = autonosa_4InitialPos;
        }




    }

    public void Dropautonosa_5()
    {
        float Distance = Vector3.Distance(autonosa_5.transform.position, Kulho_5.transform.position);
        if (Distance < 250)
        {
            autonosa_5.transform.position = Kulho_5.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_5.SetActive(false);
            Kulho_5.SetActive(true);
            autonosa_ylhäältä_6.transform.position = autonosa_ylhäältä_5.transform.position;



        }
        else
        {
            autonosa_5.transform.position = autonosa_5InitialPos;
        }




    }

    public void Dropautonosa_6()
    {
        float Distance = Vector3.Distance(autonosa_6.transform.position, Kulho_6.transform.position);
        if (Distance < 250)
        {
            autonosa_6.transform.position = Kulho_6.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_6.SetActive(false);
            Kulho_6.SetActive(true);
            autonosa_ylhäältä_7.transform.position = autonosa_ylhäältä_6.transform.position;
            kolmas_taso.SetActive(true);



        }
        else
        {
            autonosa_6.transform.position = autonosa_6InitialPos;
        }

    }

    public void Dropautonosa_7()
    {
        float Distance = Vector3.Distance(autonosa_7.transform.position, Kulho_7.transform.position);
        if (Distance < 250)
        {
            autonosa_7.transform.position = Kulho_7.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_7.SetActive(false);
            Kulho_7.SetActive(true);
            autonosa_ylhäältä_8.transform.position = autonosa_ylhäältä_7.transform.position;



        }
        else
        {
            autonosa_7.transform.position = autonosa_7InitialPos;
        }




    }

    public void Dropautonosa_8()
    {
        float Distance = Vector3.Distance(autonosa_8.transform.position, Kulho_8.transform.position);
        if (Distance < 250)
        {
            autonosa_8.transform.position = Kulho_8.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_8.SetActive(false);
            Kulho_8.SetActive(true);
            autonosa_ylhäältä_9.transform.position = autonosa_ylhäältä_8.transform.position;



        }
        else
        {
            autonosa_8.transform.position = autonosa_8InitialPos;
        }




    }

    public void Dropautonosa_9()
    {
        float Distance = Vector3.Distance(autonosa_9.transform.position, Kulho_9.transform.position);
        if (Distance < 250)
        {
            autonosa_9.transform.position = Kulho_9.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_9.SetActive(false);
            Kulho_9.SetActive(true);
            location.SetActive(true);
            eka_taso.SetActive(false);
            



        }
        else
        {
            autonosa_9.transform.position = autonosa_9InitialPos;
        }




    }
}
