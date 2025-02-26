using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Animator animator;
    float camRotSpeed = 1;
    float mouseX;
    float mouseY;
    Camera PlayerCam;
    private Rigidbody rb;
    float moveSpeed = 5f; 
    float moveSpeedMultiplier;
    public Transform Spine;
    public Transform Campos;
    public GameObject[]  Item;


    void Start()
    {
        PlayerCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        Spine = animator.GetBoneTransform(HumanBodyBones.Spine);
    }

    void Update()
    {

        PlayerCam.transform.position = Campos.position;
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        PlayerCam.transform.rotation = Quaternion.Euler(mouseY * camRotSpeed, mouseX * camRotSpeed, 0);
        transform.rotation = Quaternion.Euler(0, mouseX * camRotSpeed, 0);
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        float speed = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat("Move", speed);
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
        Spine.transform.LookAt(PlayerCam.transform);
        Spine.rotation = PlayerCam.transform.rotation;
    }

}
