using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Hissi2 : MonoBehaviour
{
    Animator hissiAnim;
    public Transform standing;
    public GameObject topViewCam, elevatorCam;

    Transform player;
    public Image panel;

    public string level_Name;
    // Start is called before the first frame update
    void Start()
    {
        elevatorCam.SetActive(false);
        hissiAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            player = other.transform;
            PlayerInside();
        }
    }

    void PlayerInside()
    {
        player.position = standing.position;
        player.GetComponent<TopViewMovement>().enabled = false;
        player.GetComponent<GunScritp>().enabled = false;
        topViewCam.SetActive(false);
        elevatorCam.SetActive(true);
        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        hissiAnim.SetBool("open", false);
        yield return new WaitForSeconds(3);
        panel.DOFade(1, 3);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(level_Name);

    }

}
