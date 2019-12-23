using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    //velocidad de rotación
    public float velRot = 180.0f;
    //vector para almacenar la rotación de la cámara
    Vector3 currentRot;
    //límites de la rotación
    float minRot = -30.0f;
    float maxRot = 90.0f;
    float rotX;
    // Use this for initialization
    void Start()
    {
        currentRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        currentRot.x -= Input.GetAxis("Mouse Y") * velRot * Time.deltaTime;
        currentRot.x = Mathf.Clamp(currentRot.x, minRot, maxRot);
        transform.localEulerAngles = currentRot;
    }
}
