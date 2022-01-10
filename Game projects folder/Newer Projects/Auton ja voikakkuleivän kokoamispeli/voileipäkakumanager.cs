using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voileipäkakumanager : MonoBehaviour
{
    public GameObject location, eka_taso, toka_taso, kolmas_taso, Next_state, autonosa_1, autonosa_2, autonosa_3, autonosa_4, autonosa_5, autonosa_6, autonosa_7, autonosa_8, autonosa_9, Kulho_1, Kulho_2, Kulho_3, Kulho_4, Kulho_5, Kulho_6, Kulho_7, aines_1, aines_2, aines_3, aines_4, aines_5, hienoateksti;
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

    //eka taso: 5 ainesta
    //autonosa = aines
    public void Dropautonosa_1()
    {
        float Distance = Vector3.Distance(autonosa_1.transform.position, Kulho_1.transform.position);
        if (Distance < 600)
        {
            autonosa_1.transform.position = Kulho_1.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_1.SetActive(false);
            Kulho_1.SetActive(false);
            Kulho_2.SetActive(true);
            aines_1.SetActive(false);
            aines_2.SetActive(true);
            Kulho_2.transform.position = Kulho_1.transform.position;

        }
        else
        {
            autonosa_1.transform.position = autonosa_1InitialPos;
        }

    }



    public void Dropautonosa_2()
    {
        float Distance = Vector3.Distance(autonosa_2.transform.position, Kulho_2.transform.position);
        if (Distance < 600)
        {
            autonosa_2.transform.position = Kulho_2.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_2.SetActive(false);
            Kulho_2.SetActive(false);
            Kulho_3.SetActive(true);
            aines_2.SetActive(false);
            aines_3.SetActive(true);
            Kulho_3.transform.position = Kulho_2.transform.position;
        }

        else
        {
            autonosa_2.transform.position = autonosa_2InitialPos;
        }

    }



    public void Dropautonosa_3()
    {
        float Distance = Vector3.Distance(autonosa_3.transform.position, Kulho_3.transform.position);
        if (Distance < 600)
        {
            autonosa_3.transform.position = Kulho_3.transform.position;
            points_kakupeli.scoreValue += 1;
            autonosa_3.SetActive(false);
            Kulho_3.SetActive(false);
            Kulho_4.SetActive(true);
            aines_3.SetActive(false);
            aines_4.SetActive(true);
            Kulho_4.transform.position = Kulho_3.transform.position;
        }
        else
        {
            autonosa_3.transform.position = autonosa_3InitialPos;
        }

    }


    public void Dropautonosa_4()
    {
        float Distance = Vector3.Distance(autonosa_4.transform.position, Kulho_4.transform.position);
        if (Distance < 600)
        {
            points_kakupeli.scoreValue += 1;
            autonosa_4.transform.position = Kulho_4.transform.position;
            autonosa_4.SetActive(false);
            Kulho_4.SetActive(false);
            Kulho_5.SetActive(true);
            aines_4.SetActive(false);
            aines_5.SetActive(true);
            Kulho_5.transform.position = Kulho_4.transform.position;
        }
        else
        {
            autonosa_4.transform.position = autonosa_4InitialPos;
        }

    }


    public void Dropautonosa_5()
    {
        float Distance = Vector3.Distance(autonosa_5.transform.position, Kulho_5.transform.position);
        if (Distance < 600)
           
        {
            points_kakupeli.scoreValue += 1;
            autonosa_5.transform.position = Kulho_5.transform.position;
            autonosa_5.SetActive(false);
            Kulho_5.SetActive(false);
            Kulho_6.SetActive(true);
            Kulho_6.transform.position = Kulho_5.transform.position;
            

        }
        else
        {
            autonosa_5.transform.position = autonosa_5InitialPos;
        }

    }

    //taso 2: leivän päällinen ja leipä
    //autonosa = täyte





} 

