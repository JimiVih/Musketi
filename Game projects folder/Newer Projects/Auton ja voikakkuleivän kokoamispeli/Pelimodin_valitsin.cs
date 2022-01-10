using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelimodin_valitsin : MonoBehaviour
{

    public GameObject AutonRassaus, Voileipäkakun_duunaus, pelivalitsin, loading, not_loading, autoras_nonint, kakku_nonint;
    Vector2 AutonRassausInitialPos, Voileipäkakun_duunausInitialPos, pelivalitsinInitialPos;
   // private int autonrassaus;


    void Start()
    {
        AutonRassausInitialPos = AutonRassaus.transform.position;
        Voileipäkakun_duunausInitialPos = Voileipäkakun_duunaus.transform.position;
        pelivalitsinInitialPos = pelivalitsin.transform.position;
    }

    public void DragAutonRassaus()

    {
        AutonRassaus.transform.position = Input.mousePosition;
        Voileipäkakun_duunaus.SetActive(false);

    }

    public void DragVoileipäkakun_duunaus()

    {
        Voileipäkakun_duunaus.transform.position = Input.mousePosition;
        AutonRassaus.SetActive(false);

    }


    public void DropAutonRassaus()

    {
        float Distance = Vector3.Distance(AutonRassaus.transform.position, pelivalitsin.transform.position);
        if (Distance < 50)
        {
            AutonRassaus.transform.position = pelivalitsin.transform.position;
            SceneManager.LoadScene("autonrassaus");
            loading.SetActive(true);
            
            
        }

        else
        {
            AutonRassaus.transform.position = AutonRassausInitialPos;
            not_loading.SetActive(true);
            Voileipäkakun_duunaus.SetActive(true);

        }

        }


    public void DropVoileipäkakun_duunaus()

    {
        float Distance = Vector3.Distance(Voileipäkakun_duunaus.transform.position, pelivalitsin.transform.position);
        if (Distance < 50)
        {
            Voileipäkakun_duunaus.transform.position = pelivalitsin.transform.position;
            SceneManager.LoadScene("voileipäkakun_duunaus v2");
            loading.SetActive(true);


        }

        else
        {
            Voileipäkakun_duunaus.transform.position = Voileipäkakun_duunausInitialPos;
            not_loading.SetActive(true);
            AutonRassaus.SetActive(true);

        }

    }



}

    








    


