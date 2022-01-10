using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class dialogNoAnsw : MonoBehaviour
{
    public GameObject wholeDialog;

    public AudioClip[] enemySounds;
    public AudioSource enemyAudioSource;

    public string[] dialogia;
    public int index;
    public int maxDialog;
    public float typingSpeed;

    public TMP_Text dialogipaikka;

    public GameObject playerr;
    public GameObject next;

    public bool hasTime;
    public bool endsGame;
    public bool isFinal;

    public Image panel;

    void Start()
    {
        StartCoroutine(TypeDialog());
        StartCoroutine(timer());
        wholeDialog.SetActive(true);
        disablePlayer();
        next.SetActive(true);
    }


    IEnumerator TypeDialog()
    {
        enemyAudioSource.clip = enemySounds[Random.Range(0, enemySounds.Length)];
        enemyAudioSource.Play();
        foreach (char letter in dialogia[index].ToCharArray())
        {
            dialogipaikka.text += letter;
            yield return new WaitForSeconds(typingSpeed);
           // yield return new WaitForSeconds(3);
           // wholeDialog.SetActive(false);
        }



    }


    public void NextSentence()
    {
        if (index < dialogia.Length - 1)
        {
            index++;
            dialogipaikka.text = "";
            StartCoroutine(TypeDialog());
        }

        if (endsGame)
        {
            if (index == 5)
            {
                StartCoroutine(endGame());
            }
        }

        if(index == maxDialog)
        {
            playerr.GetComponent<PlayerScript1>().canWalk = true;
            playerr.GetComponent<GunScritp>().enabled = true;
            wholeDialog.SetActive(false);
            next.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if(isFinal)
        {

        }

    }

    void disablePlayer()
    {
        if (!hasTime)
        {
            playerr.GetComponent<PlayerScript1>().canWalk = false;
            playerr.GetComponent<GunScritp>().CanShoot = false;
        }

    }

    IEnumerator timer()
    {
        if (hasTime)
        {
            
            playerr.GetComponent<GunScritp>().CanShoot = false;
            yield return new WaitForSeconds(10);
            wholeDialog.SetActive(false);
            
            playerr.GetComponent<GunScritp>().CanShoot = true;
            dialogipaikka.text = "";
        }
    }

    IEnumerator endGame()
    {
        panel.DOFade(1, 3);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("secondLevel");
    }

    IEnumerator RollTheCredits()
    {
        panel.DOFade(1, 6);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("credits");
    }

}

