using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GhostAI : MonoBehaviour
{
    public enum GhostState { Idle, Investigate, Hunt, Disappear } // 유령의 상태 정의
    private GhostState currentState = GhostState.Idle; // 초기 상태

    public Transform targetPlayer;  // 플레이어
    public NavMeshAgent agent;      // NavMeshAgent
    float detectionRange = 10f;  // 플레이어 감지 범위
    float huntRange = 5f;  // 사냥 모드로 전환하는 범위
    public float disappearTime = 20f; // 유령이 아무것도 못 찾으면 사라지는 시간

    private Vector3 lastHeardSound; // 소리가 들린 위치 저장
    private bool heardSound = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(RandomPatrol());  // 초반에는 랜덤 이동 시작
    }

    private void Update()
    {
        switch (currentState)
        {
            case GhostState.Idle:
                CheckForPlayer();
                break;

            case GhostState.Investigate:
                InvestigateSound();
                break;

            case GhostState.Hunt:
                HuntPlayer();
                break;

            case GhostState.Disappear:
                Disappear();
                break;
        }
    }

    private void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, targetPlayer.position) <= detectionRange)
        {
            Debug.Log("👻 유령이 플레이어를 감지했다!");
            currentState = GhostState.Hunt;
        }
    }
    public void HearSound(Vector3 soundPosition)
    {
        Debug.Log("🔊 유령이 소리를 들었다!");
        lastHeardSound = soundPosition;
        heardSound = true;
        currentState = GhostState.Investigate;
    }

    private void InvestigateSound()
    {
        if (heardSound)
        {
            agent.SetDestination(lastHeardSound);

            // 도착했는지 확인
            if (Vector3.Distance(transform.position, lastHeardSound) < 1f)
            {
                heardSound = false; // 도착 후 소리 정보 초기화
                currentState = GhostState.Idle; // 다시 랜덤 탐색으로 변경
            }
        }
    }
    private void HuntPlayer()
    {
        agent.SetDestination(targetPlayer.position);

        if (Vector3.Distance(transform.position, targetPlayer.position) < 2f)
        {
            Debug.Log("💀 유령이 플레이어를 죽였다!");
            KillPlayer();
        }
        else if (Vector3.Distance(transform.position, targetPlayer.position) > huntRange)
        {
            Debug.Log("😵‍💫 유령이 플레이어를 놓쳤다...");
            currentState = GhostState.Idle;
        }
    }

    private void KillPlayer()
    {
        // 플레이어 사망 
    }
    private void Disappear()
    {
        // 메쉬렌더러랑 콜라이더 끄기 
    }

    IEnumerator RandomPatrol()
    {
        while (currentState == GhostState.Idle)  // 대기 상태일 때만 랜덤 이동
        {
            Vector3 randomPoint = GetRandomPoint();
            agent.SetDestination(randomPoint);

            // 유령이 랜덤 위치에 도착할 때까지 대기
            while (Vector3.Distance(transform.position, randomPoint) > 1f)
            {
                yield return null;
            }

            // 도착 후 잠깐 기다렸다가 다음 랜덤 위치 설정
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;  // 반경 10m 내에서 랜덤 방향 설정
        randomDirection += transform.position;  // 현재 위치를 기준으로 랜덤 위치 설정
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
        {
            return hit.position; 
        }
        return transform.position; 
    }
}
