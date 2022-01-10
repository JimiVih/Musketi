using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public KoiController koiController;
    bool isYin;

    AudioSource swordAud;
    public AudioClip swordClip;
    // Start is called before the first frame update
    void Start()
    {
        isYin = koiController.isYin;
        swordAud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isYin)
        {
            if(collision.transform.tag == "YinHeron")
            {
                collision.gameObject.GetComponent<HeronScript>().Hit();
                swordAud.clip = swordClip;
                swordAud.Play();
            }
        }
        

        if (!isYin)
        {
            if (collision.transform.tag == "YangHeron")
            {
                collision.gameObject.GetComponent<HeronScript>().Hit();
                swordAud.clip = swordClip;
                swordAud.Play();
            }
        }
    }
}
