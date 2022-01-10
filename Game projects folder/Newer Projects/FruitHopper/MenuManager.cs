using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{
    public Image panel;
    

    private void Start()
    {
        panel.DOFade(0, 1); 
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    public void ExitGame()
    {
        StartCoroutine(Quit());
    }

    IEnumerator LoadGame()
    {
        Debug.Log("Start Game");
        panel.DOFade(1, 1);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("level_1");
    }

    IEnumerator Quit()
    {
        Debug.Log("Quit Game");
        panel.DOFade(1, 1);
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }

}
