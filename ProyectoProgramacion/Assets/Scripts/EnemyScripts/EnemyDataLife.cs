using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataLife : MonoBehaviour
{
    public float life;

    public void addDamage(float damage)
    {
        life -= damage;
        if (life <= 0) {
            death();
        }
    }

    private void death() {

        Destroy(this.gameObject);
    }
    
}
