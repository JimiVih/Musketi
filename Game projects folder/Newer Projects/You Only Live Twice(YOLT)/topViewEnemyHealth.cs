using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topViewEnemyHealth : MonoBehaviour
{
    public float Health = 100;
    bool alive;

    TopDownEnemyAIM change;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        change = gameObject.GetComponentInChildren<TopDownEnemyAIM>();
    }

    // Update is called once per frame
    void Update()
    {

        if (alive && Health <= 0)
        {
            var enem = GetComponent<TopViewMovementEnemy>();
            enem.AktvRagnukke();
            Destroy(change);
            alive = false;
        }

    }
}
