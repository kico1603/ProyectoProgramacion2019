using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMele : MonoBehaviour
{
    public Transform target;
    public float radio;
    private SphereCollider triggerCollider;
    private NavMeshAgent agent;
    private Vector3 positionOriginal;
    EnemyDataLife enemyLife;
    public bool isDeath;
    

    // Start is called before the first frame update
    void Start()
    {
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
