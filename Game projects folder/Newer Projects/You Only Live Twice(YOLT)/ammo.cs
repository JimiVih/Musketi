using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ammo : MonoBehaviour
{

    public TMP_Text ammoText;
    public float amount;
    public float maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ammoText.text = "Bullets " + amount + "/" + maxAmmo;
        
    }
}
