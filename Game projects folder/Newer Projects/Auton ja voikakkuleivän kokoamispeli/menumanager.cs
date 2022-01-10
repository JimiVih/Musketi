using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    public GameObject Pause_menu;

    public void openup_menu()

    {
        Pause_menu.SetActive(true);
    }

        public void Quit_to_Menu()
    {
        SceneManager.LoadScene("menyyy");
    }

    public void Continue_game()
    {
        Pause_menu.SetActive(false);
    }
}