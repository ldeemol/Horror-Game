using UnityEngine;

public class LaserDots : MonoBehaviour
{
    public float laserRange = 20f; 
    public GameObject dotPrefab;
    private GameObject dot;  

    void Update()
    {
        Vector3 startPos = transform.position;  
        Vector3 direction = transform.forward;  

        Debug.DrawRay(startPos, direction * laserRange, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(startPos, direction, out hit, laserRange))
        {
            if (dot == null) 
            {
                CreateDot(hit.point);
            }
            else if (dot.transform.position != hit.point) 
            {
                UpdateDotPosition(hit.point);
            }
        }
        else
        {
            if (dot != null)
            {
                Destroy(dot);
            }
        }
    }

    void CreateDot(Vector3 position)
    {
        dot = Instantiate(dotPrefab, position, transform.rotation);  // 도트 생성
    }

    void UpdateDotPosition(Vector3 newPosition)
    {
        dot.transform.position = newPosition;  // 도트 위치만 갱신
    }
}
