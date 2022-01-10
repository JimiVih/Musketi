using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMosue : MonoBehaviour
{


    public Transform targetTransf;

    private Camera mainCamera;

    public LayerMask mouseMask;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseMask))
        {

            targetTransf.position = hit.point;

        }


    }
}
