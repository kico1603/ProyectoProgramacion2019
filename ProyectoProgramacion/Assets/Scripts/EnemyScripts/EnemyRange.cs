using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    private SphereCollider triggerCollider;
    public float radio;
    public GameObject arma;
    ArmEnemyController armaController;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<SphereCollider>();
        armaController = arma.GetComponent<ArmEnemyController>();
        triggerCollider.radius = radio;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            armaController.activated();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            armaController.disabled();
        }


    }
}
