using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCoder : MonoBehaviour
{
    public Camera customCamera;        // �߰����ÿ� ī�޶�
    public RenderTexture renderTexture; // ī�޶� ����� ������ Render Texture
    public Material nightVisionMaterial; // ������ ����� ������ ���̴� ��Ƽ����

    void Start()
    {
        // ī�޶��� ��� ����� Render Texture�� ����
        customCamera.targetTexture = renderTexture;
    }

    void Update()
    {
        // �߰����� ȿ���� �Ѱ� ���� Ű �Է� ó�� (��: 'N' Ű)
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }
    }

    void ToggleNightVision()
    {
        // Render Texture�� ����ϴ� UI�� ��ü�� ȿ���� ����
        if (nightVisionMaterial != null)
        {
            nightVisionMaterial.SetInt("_EffectOn", nightVisionMaterial.GetInt("_EffectOn") == 1 ? 0 : 1);
        }
    }
}
