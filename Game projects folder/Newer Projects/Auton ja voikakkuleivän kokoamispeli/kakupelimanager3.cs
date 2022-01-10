using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakupelimanager3 : MonoBehaviour
{
    public GameObject kurkku, tomaatti, kinkku, salaatinlehti, kurkkupaikka, tomaattipaikka, kinkkupaikka, salaatinpaikka;
    public GameObject kurkkukulho, otmaattikulho, kinkkukasa, salaattikasa, winner, aikapaksa;
    Vector2 kurkkuInitialPos, tomaattiInitialPos, kinkkuInitialPos, salaattiInitialPos;

    void Start()
    {
        kurkkuInitialPos = kurkku.transform.position;
        tomaattiInitialPos = tomaatti.transform.position;
        kinkkuInitialPos = kinkku.transform.position;
        salaattiInitialPos = salaatinlehti.transform.position;

    }



    public void Dragautonosa_1()
    {
        kurkku.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_2()
    {
        tomaatti.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_3()
    {
        kinkku.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_4()
    {
        salaatinlehti.transform.position = Input.mousePosition;
    }

    // autonosa = koriste
    // kulho = soossin paikka
    // aines ylhäältä = soossi kulho

    public void Dropautonosa_1()
    {
        float Distance = Vector3.Distance(kurkku.transform.position, kurkkupaikka.transform.position);
        if (Distance < 250)
        {
            kurkku.transform.position = kurkkupaikka.transform.position;
            tomaattipaikka.SetActive(true);

        }
        else
        {
            kurkku.transform.position = kurkkuInitialPos;
        }

    }

    public void Dropautonosa_2()
    {
        float Distance = Vector3.Distance(tomaatti.transform.position, tomaattipaikka.transform.position);
        if (Distance < 250)
        {
            kurkku.transform.position = kurkkupaikka.transform.position;
            kinkkupaikka.SetActive(true);

        }
        else
        {
            tomaatti.transform.position = tomaattiInitialPos;
        }

    }

    public void Dropautonosa_3()
    {
        float Distance = Vector3.Distance(kinkku.transform.position, kinkkupaikka.transform.position);
        if (Distance < 250)
        {
            kinkku.transform.position = kinkkupaikka.transform.position;
            salaatinpaikka.SetActive(true);

        }
        else
        {
            kinkku.transform.position = kinkkuInitialPos;
        }

    }

    public void Dropautonosa_4()
    {
        float Distance = Vector3.Distance(salaatinlehti.transform.position, salaatinpaikka.transform.position);
        if (Distance < 250)
        {
            salaatinlehti.transform.position = salaatinpaikka.transform.position;
            winner.SetActive(true);
            aikapaksa.SetActive(true);


        }
        else
        {
            salaatinlehti.transform.position = salaattiInitialPos;
        }

    }
}
