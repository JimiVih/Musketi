using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationText : MonoBehaviour
{
     
   public Text rotationZ;
    public Text rotationY;
    public float Xrot;
    public float Yrot;
    public float Zrot;

    public Transform plääplää;

    void Update()
    {

        Xrot = transform.eulerAngles.x;
        Yrot = transform.eulerAngles.y;
        Zrot = transform.eulerAngles.z;


        rotationZ.text = "Zakseli:  " + Zrot;
        rotationY.text = "Yakseli:  " + Yrot;







    }




}
