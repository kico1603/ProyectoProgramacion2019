using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmEnemyController : MonoBehaviour
{

   
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    EnemyDataLife enemyLife;

    public float chargerMax;
    public float secondsReload;

    private float charger;

    public bool targetFound;

    Transform target;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        targetFound = false;
        nextFire = Time.time + fireRate;
        enemyLife = transform.parent.gameObject.GetComponent<EnemyDataLife>();
    }

    public void activated() {
        targetFound = true;
    }

    public void disabled() {

        targetFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound && !enemyLife.isDeath)
        {
            if (target != null)
            {

                Vector3 lookVector = target.transform.position - transform.position;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

                transform.parent.LookAt(Vector3.Lerp(transform.parent.forward, target.position, 1f));

                //Vector3 lookVectorParent = target.transform.position - transform.parent.position;
                //lookVector.x = transform.parent.position.x;
                //Quaternion rotParent = Quaternion.LookRotation(lookVector);
                //transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, rot, 1);

            }

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject instance = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                charger--;
                if (charger <= 0)
                {
                    charger = chargerMax;
                    nextFire += secondsReload;

                }
            }


        }
    }
}
