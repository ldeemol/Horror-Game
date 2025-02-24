using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Animator animator;
    float camRotSpeed = 1;
    float mouseX;
    float mouseY;
    Camera cam;
    private Rigidbody rb;
    float moveSpeed = 5f; // 이동 속도
    float moveSpeedMultiplier;
    public Transform Spine;
    public Transform Campos;
    public GameObject Item;


    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        Spine = animator.GetBoneTransform(HumanBodyBones.Spine);
    }

    void Update()
    {

        cam.transform.position = Campos.position;
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        cam.transform.rotation = Quaternion.Euler(mouseY * camRotSpeed, mouseX * camRotSpeed, 0);
        transform.rotation = Quaternion.Euler(0, mouseX * camRotSpeed, 0);
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        float speed = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat("Speed", speed);
        if (moveX + moveZ >= 0.1f)
        {
            moveSpeedMultiplier = 1f;
        }
        else if (moveX + moveZ <= -0.1f)
        {
            moveSpeedMultiplier = 1f;
        }
        else
        {
            moveSpeedMultiplier = -1f;
        }
        animator.SetFloat("Move", moveSpeedMultiplier);
    }
    private void LateUpdate()
    {
        Spine.transform.LookAt(cam.transform);
        Spine.rotation = cam.transform.rotation;
    }

}
