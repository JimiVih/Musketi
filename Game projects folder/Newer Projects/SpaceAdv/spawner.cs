using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float WaitTime;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }


    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);

    }
}
