using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMele : MonoBehaviour
{
    
    public float radio;
    private SphereCollider triggerCollider;
    private NavMeshAgent agent;
    private Vector3 positionOriginal;
    EnemyDataLife enemyLife;
    public bool isDeath;

    Transform target;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        triggerCollider = GetComponent<SphereCollider>();
        enemyLife = GetComponent<EnemyDataLife>();
        isDeath = false;
        positionOriginal = transform.position;
        triggerCollider.radius = radio;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target && !isDeath) {
            agent.SetDestination(target.position);
        }
            
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == target && !isDeath)
        {
            agent.SetDestination(target.position);
        }
        
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target && !isDeath) {
            agent.SetDestination(positionOriginal);
        }
    }

    private void Update()
    {
        if (enemyLife.isDeath)
        {
            isDeath = true;
            agent.enabled = false;
        }
    }






}
