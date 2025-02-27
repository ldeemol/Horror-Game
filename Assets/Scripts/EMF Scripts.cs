using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//여기서 충돌처리도 다해줄꺼임
public class EMFScripts : MonoBehaviour
{
    public GameObject AddEMF;
    int GhostEMF;

    private Quaternion fixedRotation;
    void Start()
    {
        fixedRotation = transform.rotation;
        AddEMF.GetComponent<EMFNeedle>();
    }

    void LateUpdate()
    {
        transform.rotation = fixedRotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GhostEvent"))
        {
            //GhostEMF를 여기서 받아주기 
            AddEMF.GetComponent<EMFNeedle>().AddPower(GhostEMF);
            //소리처리
        }
    }
}
