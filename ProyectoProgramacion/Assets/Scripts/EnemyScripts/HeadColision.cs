using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColision : MonoBehaviour
{
    EnemyDataLife enemyLife;


    void Start()
    {
        enemyLife = gameObject.GetComponentInParent<EnemyDataLife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            ColisionEnemy colisionEnemy = other.GetComponent<ColisionEnemy>();
            enemyLife.addDamage(colisionEnemy.damageInHead);
        }
    }
}
