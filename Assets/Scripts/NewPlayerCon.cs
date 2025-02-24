using UnityEngine;

public class NewPlayerCon : MonoBehaviour
{
    Animator animator;
    float camRotSpeed = 1;
    float mouseX;
    float mouseY;
    Camera cam;
    float moveSpeed = 5f; // 이동 속도
    public Transform Spine;

    void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        Spine = animator.GetBoneTransform(HumanBodyBones.Spine);
    }

    void Update()
    {
        // 카메라 회전
        mouseX += Input.GetAxis("Mouse X") * camRotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * camRotSpeed;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f); // 카메라가 위아래로 지나치게 회전하지 않도록 제한

        cam.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        // 키 입력받고 움직임
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Transform 기준으로 이동
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World); // 월드 공간 기준으로 이동

        // 이동 방향에 따른 애니메이션 상태 설정
        float speed = new Vector2(moveX, moveZ).magnitude; // 이동 속도 계산
        animator.SetFloat("Speed", speed);
    }

    private void LateUpdate()
    {
        // 카메라와 자연스럽게 Spine을 회전시킴
        Vector3 directionToCamera = cam.transform.position - Spine.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        Spine.rotation = Quaternion.Slerp(Spine.rotation, targetRotation, Time.deltaTime * 5f); // 부드럽게 회전
    }
}
