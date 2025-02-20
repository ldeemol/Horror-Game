using UnityEngine;

public class LaserDots : MonoBehaviour
{
    public LineRenderer lineRenderer;  // LineRenderer ������Ʈ
    public float laserRange = 100f;   // ������ ����
    public LayerMask laserHitLayer;   // �������� �浹�� �� �ִ� ���̾�
    public Color laserColor = Color.green;  // ������ ���� (�ʷϻ�)

    void Start()
    {
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    void Update()
    {
        FireLaser();
    }

    void FireLaser()
    {
        RaycastHit hit;
        Ray laserRay = new Ray(transform.position, transform.forward); // ���� ��ġ���� �������� ������ ���

        // �������� ��ü�� �浹�� ���
        if (Physics.Raycast(laserRay, out hit, laserRange, laserHitLayer))
        {
            // �������� ���� �浹 �������� ����
            lineRenderer.SetPosition(0, transform.position);  // �������� ���� ��ġ
            lineRenderer.SetPosition(1, hit.point);            // �������� �� ��ġ
        }
        else
        {
            // �������� �ƹ��͵� �� ������ �� ��ġ�� ������ �ִ� �Ÿ��� ����
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserRange);
        }
    }
}