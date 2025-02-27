//using System.Collections;
//using UnityEngine;
//using UnityEngine.AI;
//public class Ghost : MonoBehaviour
//{
//    public NavMeshAgent agent;
//    public Transform target; // 플레이어
//    Vector3 rememberTarget;


//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//    }

//    void Update()
//    {

//        if (Input.GetKey(KeyCode.B))
//        {
//            rememberTarget= target.position;
//            StartCoroutine(ChaseCoroutine());
//        }                                                     
//    }

//    IEnumerator ChaseCoroutine()
//    {
//        agent.SetDestination(rememberTarget);
//        yield return null;
//    }
//}

using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    private NavMeshAgent agent; // 유령의 NavMeshAgent
    public float detectionRange = 10f; // 감지 거리
    public float chaseRange = 20f; // 추격 거리
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange) // 플레이어를 감지하면
        {
            agent.SetDestination(player.position); // 플레이어를 따라감
            Debug.Log("👻 유령이 플레이어를 감지하고 추격 시작!");
        }
        else if (distanceToPlayer > chaseRange) // 너무 멀어지면
        {
            agent.SetDestination(transform.position); // 현재 위치에서 대기
            Debug.Log("😵‍💫 유령이 플레이어를 놓침!");
        }
    }
}
