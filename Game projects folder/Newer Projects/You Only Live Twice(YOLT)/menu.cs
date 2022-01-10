using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject startFog, exitFog, settingsFog;
    AudioSource menuSource;


    private void Start()
    {
        menuSource = GetComponent<AudioSource>();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("intro");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartFogEnable()
    {
        startFog.SetActive(true);
        menuSource.Play();
        
    }

    public void StartFogDisable()
    {
        startFog.SetActive(false);
    }

    public void ExitFogEnabled()
    {
        exitFog.SetActive(true);
        menuSource.Play();
    }

    public void ExitFogDisable()
    {
        exitFog.SetActive(false);
    }

    public void SettingsFogEnabled()
    {
        settingsFog.SetActive(true);
        menuSource.Play();
    }

    public void SettingsFogDisable()
    {
        settingsFog.SetActive(false);
    }

}
