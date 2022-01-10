using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkCollider : MonoBehaviour
{
    AudioSource step;

    private void Start()
    {
        step = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            float stepPitch = Random.Range(0.6f, 1);
            step.pitch = stepPitch;
            step.Play();
        }
    }

}
