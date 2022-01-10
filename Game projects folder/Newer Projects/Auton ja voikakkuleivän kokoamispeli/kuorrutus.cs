using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuorrutus : MonoBehaviour
{
    public GameObject kuorrutus1, kuorrutus2, kuorrutus3, kuorrutus4, kuorrutuspaikka1, kuorrutuspaikka2, kuorrutuspaikka3, kuorrutuspaikka4, autonkuorrutus, kuorrutuspalat, koristeet;
    public GameObject kulho1, kulho2, kulho3, kulho4;
    Vector2 kuorrutus_1InitialPos, kuorrutus_2InitialPos, kuorrutus_3InitialPos, kuorrutus_4InitialPos;

    void Start()
    {
        kuorrutus_1InitialPos = kuorrutus1.transform.position;
        kuorrutus_2InitialPos = kuorrutus2.transform.position;
        kuorrutus_3InitialPos = kuorrutus3.transform.position;
        kuorrutus_4InitialPos = kuorrutus4.transform.position;
    }

    public void Dragautonosa_1()
    {
        kuorrutus1.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_2()
    {
        kuorrutus2.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_3()
    {
        kuorrutus3.transform.position = Input.mousePosition;
    }

    public void Dragautonosa_4()
    {
        kuorrutus4.transform.position = Input.mousePosition;
    }


    // autonosa = koriste
    // kulho = koristeen paikka
    // aines ylhäältä = 

    public void Dropautonosa_1()
    {
        float Distance = Vector3.Distance(kuorrutus1.transform.position, kuorrutuspaikka1.transform.position);
        if (Distance < 250)
        {
            kuorrutus1.transform.position = kuorrutuspaikka1.transform.position;
            kulho2.SetActive(true);
            kulho1.SetActive(false);
            kulho2.transform.position = kulho1.transform.position;

        }
        else
        {
            kuorrutus1.transform.position = kuorrutus_1InitialPos;
        }

    }

    public void Dropautonosa_2()
    {
        float Distance = Vector3.Distance(kuorrutus2.transform.position, kuorrutuspaikka2.transform.position);
        if (Distance < 250)
        {
            kuorrutus2.transform.position = kuorrutuspaikka2.transform.position;
            kulho3.SetActive(true);
            kulho2.SetActive(false);
            kulho3.transform.position = kulho2.transform.position;

        }
        else
        {
            kuorrutus2.transform.position = kuorrutus_2InitialPos;
        }

    }

    public void Dropautonosa_3()
    {
        float Distance = Vector3.Distance(kuorrutus3.transform.position, kuorrutuspaikka3.transform.position);
        if (Distance < 250)
        {
            kuorrutus3.transform.position = kuorrutuspaikka3.transform.position;
            kulho4.SetActive(true);
            kulho3.SetActive(false);
            kulho4.transform.position = kulho3.transform.position;

        }
        else
        {
            kuorrutus3.transform.position = kuorrutus_3InitialPos;
        }

    }

    public void Dropautonosa_4()
    {
        float Distance = Vector3.Distance(kuorrutus4.transform.position, kuorrutuspaikka4.transform.position);
        if (Distance < 250)
        {
            kuorrutus4.transform.position = kuorrutuspaikka4.transform.position;
            kulho4.SetActive(false);
            autonkuorrutus.SetActive(true);
            kuorrutuspalat.SetActive(false);
            koristeet.SetActive(true);


        }
        else
        {
            kuorrutus4.transform.position = kuorrutus_4InitialPos;
        }

    }
}
