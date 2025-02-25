using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCoder : MonoBehaviour
{
    public Camera customCamera;        // 야간투시용 카메라
    public RenderTexture renderTexture; // 카메라 출력을 저장할 Render Texture
    public Material nightVisionMaterial; // 렌더링 결과에 적용할 셰이더 머티리얼

    void Start()
    {
        // 카메라의 출력 결과를 Render Texture에 설정
        customCamera.targetTexture = renderTexture;
    }

    void Update()
    {
        // 야간투시 효과를 켜고 끄는 키 입력 처리 (예: 'N' 키)
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }
    }

    void ToggleNightVision()
    {
        // Render Texture를 사용하는 UI나 객체에 효과를 적용
        if (nightVisionMaterial != null)
        {
            nightVisionMaterial.SetInt("_EffectOn", nightVisionMaterial.GetInt("_EffectOn") == 1 ? 0 : 1);
        }
    }
}
