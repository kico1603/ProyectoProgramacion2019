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
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        positionOriginal = transform.position;
        triggerCollider.radius = radio;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == target)
            agent.SetDestination(target.position);
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
            agent.SetDestination(positionOriginal);

        
    }



    
}
