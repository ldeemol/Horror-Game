using UnityEngine;

public class NewPlayerCon : MonoBehaviour
{
    Animator animator;
    float camRotSpeed = 1;
    float mouseX;
    float mouseY;
    Camera cam;
    float moveSpeed = 5f; // �̵� �ӵ�
    public Transform Spine;

    void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        Spine = animator.GetBoneTransform(HumanBodyBones.Spine);
    }

    void Update()
    {
        // ī�޶� ȸ��
        mouseX += Input.GetAxis("Mouse X") * camRotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * camRotSpeed;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f); // ī�޶� ���Ʒ��� ����ġ�� ȸ������ �ʵ��� ����

        cam.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        // Ű �Է¹ް� ������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Transform �������� �̵�
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World); // ���� ���� �������� �̵�

        // �̵� ���⿡ ���� �ִϸ��̼� ���� ����
        float speed = new Vector2(moveX, moveZ).magnitude; // �̵� �ӵ� ���
        animator.SetFloat("Speed", speed);
    }

    private void LateUpdate()
    {
        // ī�޶�� �ڿ������� Spine�� ȸ����Ŵ
        Vector3 directionToCamera = cam.transform.position - Spine.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        Spine.rotation = Quaternion.Slerp(Spine.rotation, targetRotation, Time.deltaTime * 5f); // �ε巴�� ȸ��
    }
}
