using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaserController : MonoBehaviour
{
    LineRenderer laser;

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            Vector3 puntoImpacto = hit.point;
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, puntoImpacto);
            //laser.enabled = true;


        }
        else {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.forward*1000);
        }
    }
}
