using UnityEngine;

public class NightVisionReplacement : MonoBehaviour
{
    public Shader nightVisionShader;

    void Start()
    {
        if (nightVisionShader != null)
        {
            // 모든 오브젝트를 지정한 셰이더로 렌더링
            Camera.main.SetReplacementShader(nightVisionShader, "");
        }
    }
}