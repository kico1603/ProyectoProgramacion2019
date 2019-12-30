using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLife : MonoBehaviour
{
    public float life;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        life = 150f;
    }

    public void addDamage(float damage) {
        life -= damage;

        nextFire = Time.time + 6;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            if (life < 150f) {
                life += 10;
                nextFire = Time.time + 1;
                if (life > 150f)
                    life = 150;
            }
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            addDamage(30);
        }
    }



}
