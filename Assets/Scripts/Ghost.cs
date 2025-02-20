using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target; // 플레이어
    Vector3 rememberTarget;
 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.B))
        {
            rememberTarget= target.position;
            StartCoroutine(ChaseCoroutine());
        }                                                     
    }

    IEnumerator ChaseCoroutine()
    {
        agent.SetDestination(rememberTarget);
        yield return null;
    }
}
