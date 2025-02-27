using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMFNeedle : MonoBehaviour
{
    int EMFPower;
    private Quaternion fixedRotation;
    

    void Start()
    {
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (EMFPower == 5)
        {
            transform.eulerAngles = new Vector3(0, 0, 45f);
        }
        else if (EMFPower == 4)
        {
            transform.eulerAngles = new Vector3(0, 0, 27f);
        }
        else if (EMFPower == 3)
        {
            transform.eulerAngles = new Vector3(0, 0, -9f);
        }
        else if (EMFPower == 2)
        {
            transform.eulerAngles = new Vector3(0, 0, -9f);
        }
        else if (EMFPower == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -27f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45f);
        }
    }
    
    public void AddPower(int EPower)
    {
        EMFPower = EPower;
    }
}
