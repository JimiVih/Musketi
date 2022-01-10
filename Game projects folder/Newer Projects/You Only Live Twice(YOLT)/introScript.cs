using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator timer()
    {
        yield return new WaitForSeconds(90);
        SceneManager.LoadScene("firstLevel");
    }

}
