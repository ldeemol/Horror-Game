using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public Light lightSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightSource.enabled = !lightSource.enabled;
        }
    }
}
