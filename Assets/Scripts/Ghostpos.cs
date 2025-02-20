using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostpos : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Destroy(gameObject);
        }
    }

}
