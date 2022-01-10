using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class creditRoll : MonoBehaviour
{
    public Image panel;

    void Start()
    {
        StartCoroutine(GOmenu());
    }

    IEnumerator GOmenu()
    {
        panel.DOFade(1, 4);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("menu");
    }

}
