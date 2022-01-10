using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptedEnemyHealth : MonoBehaviour
{
    public float Health = 5;
    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (alive && Health <= 0)
        {
            var enem = GetComponent<scriptedEnemy>();
            enem.AktvRagnukke();
            alive = false;
        }

    }
}
