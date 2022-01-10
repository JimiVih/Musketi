using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuripti : MonoBehaviour
{
    public GameObject loading;
    public GameObject controls;


    void Start()
    {

        loading.SetActive(false);
        controls.SetActive(false);

    }



    public void StartGame()
    {
        loading.SetActive(true);
        controls.SetActive(false);
        SceneManager.LoadScene("level1");
    }

    public void ExitGame()
    {

        Application.Quit();

        print("quit");


    }

    public void TestMap()
    {

        loading.SetActive(true);
        SceneManager.LoadScene("testi");

    }

    public void Contorls()
    {

        controls.SetActive(true);


    }

    public void X()
    {

        controls.SetActive(false);


    }







}
