using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float Health = 100;
    bool alive;

    public EnemyAim change;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(alive && Health <= 0)
        {
            var enem = GetComponent<EnemyRipt>();
            enem.AktvRagnukke();
            Destroy(change);
            alive = false;
        }

    }
}
