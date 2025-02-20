using UnityEngine;

public class LaserDots : MonoBehaviour
{
    public LineRenderer lineRenderer;  // LineRenderer 컴포넌트
    public float laserRange = 100f;   // 레이저 길이
    public LayerMask laserHitLayer;   // 레이저가 충돌할 수 있는 레이어
    public Color laserColor = Color.green;  // 레이저 색상 (초록색)

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
        Ray laserRay = new Ray(transform.position, transform.forward); // 현재 위치에서 전방으로 레이저 쏘기

        // 레이저가 물체와 충돌할 경우
        if (Physics.Raycast(laserRay, out hit, laserRange, laserHitLayer))
        {
            // 레이저의 끝을 충돌 지점으로 설정
            lineRenderer.SetPosition(0, transform.position);  // 레이저의 시작 위치
            lineRenderer.SetPosition(1, hit.point);            // 레이저의 끝 위치
        }
        else
        {
            // 레이저가 아무것도 안 닿으면 끝 위치를 레이저 최대 거리로 설정
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserRange);
        }
    }
}