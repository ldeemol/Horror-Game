using System.Collections.Generic;
using UnityEngine;

public class LaserDots : MonoBehaviour
{
    public float length = 20f;
    public GameObject dotPrefab;
    int Xwidth = 3;
    int Ywidth = 3;
    int minA = -30;
    int maxA = 30;

    private List<GameObject> dots = new List<GameObject>();

    void Update()
    {
        Vector3 startPos = transform.position;
        List<GameObject> Dot = new List<GameObject>();

        for (int x = minA; x <= maxA; x += Xwidth)
        {
            for (int y = -maxA; y <= maxA; y += Ywidth)
            {
                Quaternion rotation = transform.rotation * Quaternion.Euler(x, y, 0);
                Vector3 direction = rotation * Vector3.forward;
                //Debug.DrawRay(startPos, direction * length, Color.red);
                RaycastHit hit;
                if (Physics.Raycast(startPos, direction, out hit, length))
                {
                    GameObject dot = AddDot(hit.point);
                    Dot.Add(dot);
                }
            }
        }
        foreach (var dot in dots)
        {
            if (!Dot.Contains(dot))
            {
                Destroy(dot);
            }
        }
        dots = Dot; 
    }

    GameObject AddDot(Vector3 pos)
    {
        GameObject dot = Instantiate(dotPrefab, pos, transform.rotation);
        return dot;
    }
}
