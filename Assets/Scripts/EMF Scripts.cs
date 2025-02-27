using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���⼭ �浹ó���� �����ٲ���
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
            //GhostEMF�� ���⼭ �޾��ֱ� 
            AddEMF.GetComponent<EMFNeedle>().AddPower(GhostEMF);
            //�Ҹ�ó��
        }
    }
}
