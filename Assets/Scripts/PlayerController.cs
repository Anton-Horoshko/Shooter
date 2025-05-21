using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isGrounded;
    public float groundDistance = 0.4f;
    public float gravityCoefficient = 2;
    public Transform groundCheck;
    public Transform playerBody;
    public Transform playerCamera;
    public CharacterController characterController;
    public LayerMask groundMask;

    private const float gravity = -9.81f;
    private float cameraRotationX = 0f;

    Vector3 velocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //player look
        float mousePositionX = Input.GetAxis("Mouse X") * SensitivitySettings.sensitivity * Time.deltaTime;
        float mousePositionY = Input.GetAxis("Mouse Y") * SensitivitySettings.sensitivity * Time.deltaTime;

        cameraRotationX -= mousePositionY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mousePositionX);

        //player movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float playerPositionX = Input.GetAxis("Horizontal");
        float playerPositionZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * playerPositionX + transform.forward * playerPositionZ;
        characterController.Move(move * PlayerStats.Instance.moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(PlayerStats.Instance.jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * gravityCoefficient * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
