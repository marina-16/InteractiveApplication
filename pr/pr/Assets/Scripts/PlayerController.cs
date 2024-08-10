using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    // �������� ������ - ������������ � Inspector
    public float speed = 6f;
    // ������ ������ - ������������ � Inspector
    public float jumpHeight = 1.0f;
    // ������
    public Transform cameraHolder;
    // ���������������� ���� - ������������ � Inspector
    public float mouseSensivity = 2f;
    // ����������� ������� ����� � ���� - ������������ � Inspector
    public float upLimit = -50;
    public float downLimit = 50;
    // ����������
    private float gravityValue = -9.87f;
    // ����� �� ����� �� �����
    private bool groundedPlayer;
    // �������� ���������� ����������� ������ (�� Y)
    private Vector3 playerVelocity;
    void Start()
    {
        // ������ ������ ���� � ������
        Cursor.visible = false;
    }
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }
    // --�����������--
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
    // ���� �������� ����� �� �����, ������ ��������
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;
        else playerVelocity.y += gravityValue * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, playerVelocity.y, 0);
        Vector3 move = transform.forward * verticalMove + transform.right *
       horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove *
       Time.deltaTime);
    }
    // --�������� ������--
    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        transform.Rotate(0, horizontalRotation * mouseSensivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensivity, 0, 0);
        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }
    // --������--
    private void Jump()
    {
        // ���� �������� ����� �� �����, ������ ��������
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;
        // ���� ����� ������, � �������� ����� �� �����, ����������� �������� ������
    if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        // ����������� ��������� �� ��� Y (������)
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}