using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuskripti : MonoBehaviour
{
    public GameObject start, exit, ensimmäinen_taso, alkupaska;


    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        exit.SetActive(true);
    }

    public void Start_the_Game()
    {
        ensimmäinen_taso.SetActive(true);
        alkupaska.SetActive(false);

    }

    public void go_back_to_start_menu()
    {
        SceneManager.LoadScene("menyyy");

    }
}
