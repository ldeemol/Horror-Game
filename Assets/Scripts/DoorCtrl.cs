using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorScript;

public class DoorCtrl : MonoBehaviour
{
    public DoorControls controls = new DoorControls();
    public AnimNames AnimationNames = new AnimNames();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
