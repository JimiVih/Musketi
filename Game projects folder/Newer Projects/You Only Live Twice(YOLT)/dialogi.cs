using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dialogi : MonoBehaviour
{
    public GameObject wholeDialog;

    public GameObject answ_1, answ_2, nextOBJ;

    public Text ansText_1, ansText_2;
    public string ansString_1, ansString_2;

    public AudioClip[] pikkuPiruSounds;
    public AudioSource piruAudSour;

    public string[] dialogia;
    private int index;
    public float typingSpeed;

    public TMP_Text dialogipaikka;

    void Start()
    {
        StartCoroutine(TypeDialog());
        answ_1.SetActive(false);
        answ_2.SetActive(false);
    }


    IEnumerator TypeDialog()
    {
        piruAudSour.clip = pikkuPiruSounds[Random.Range(0, pikkuPiruSounds.Length)];
        piruAudSour.Play();
        foreach(char letter in dialogia[index].ToCharArray())
        {
            dialogipaikka.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if(index == 2)
        {
            answ_1.SetActive(true);
            answ_2.SetActive(true);

            ansText_1.text = ansString_1;
            ansText_2.text = ansString_2;
            nextOBJ.SetActive(false);



        }

    }

    public void NextSentence()
    {
        if(index < dialogia.Length - 1)
        {
            index++;
            dialogipaikka.text = "";
            StartCoroutine(TypeDialog());
        }
    }



    public void Answer_1()
    {
        StartCoroutine(ans_1());
    }


    public void Answer_2()
    {
        StartCoroutine(ans_2());
    }


    IEnumerator ans_1()
    {
        answ_1.SetActive(false);
        answ_2.SetActive(false);
        nextOBJ.SetActive(true);
        dialogipaikka.text = "";
        piruAudSour.clip = pikkuPiruSounds[Random.Range(0, pikkuPiruSounds.Length)];
        piruAudSour.Play();
        foreach (char letter in dialogia[3].ToCharArray())
        {
            dialogipaikka.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2);
        wholeDialog.SetActive(false);

    }

    IEnumerator ans_2()
    {
        dialogipaikka.text = "";
        piruAudSour.clip = pikkuPiruSounds[Random.Range(0, pikkuPiruSounds.Length)];
        piruAudSour.Play();
        foreach (char letter in dialogia[4].ToCharArray())
        {
            dialogipaikka.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(3);
        QuitTutorial();
    }

    void QuitTutorial()
    {
        SceneManager.LoadScene("Menu");
    }




}
