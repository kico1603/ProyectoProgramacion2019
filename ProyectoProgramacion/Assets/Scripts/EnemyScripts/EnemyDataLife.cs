using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataLife : MonoBehaviour
{
    public float life;
    public bool isDeath;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void addDamage(float damage)
    {
        //Debug.Log("name" + this.gameObject.name + " damage " + damage);
        life -= damage;
        if (life <= 0) {
            isDeath = true;
            death();
        }
    }

    private void death() {

        rb.freezeRotation = false;

        Destroy(this.gameObject,5);
    }
    
}
