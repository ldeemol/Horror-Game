using UnityEngine;

public class NightVisionReplacement : MonoBehaviour
{
    public Shader nightVisionShader;

    void Start()
    {
        if (nightVisionShader != null)
        {
            // ��� ������Ʈ�� ������ ���̴��� ������
            Camera.main.SetReplacementShader(nightVisionShader, "");
        }
    }
}