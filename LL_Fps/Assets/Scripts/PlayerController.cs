using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float WalkingSpeed = 7;
    public float mouseSensitive = 1;
    public Transform cameraTransform;

    float horizontalAngle;
    float verticalAngle;

    InputAction moveAction;
    InputAction lookAction;

    CharacterController characterController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ�� ȭ�� ������ �� ����
        Cursor.visible = false;

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions;
        moveAction = inputActions.FindAction("Move");
        lookAction = inputActions.FindAction("Look");

        characterController = GetComponent<CharacterController>();

        horizontalAngle = transform.localEulerAngles.y;
    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);

        if (move.magnitude > 1) //�̵� ���Ͱ� 1���� ũ��
        {
            move.Normalize(); //������ ���� 1�� ����. W,D ���� �Է� �� �� ������ �̵��ϴ� ���� �ذ�
        }
        move = move * WalkingSpeed * Time.deltaTime;
        move=transform.TransformDirection(move); //���͸� ���� ���� �ִ� �������� �ٲ���
        characterController.Move(move);

        //���콺 �¿� ������ȯ
        Vector2 look = lookAction.ReadValue<Vector2>();
        float turnPlayer = look.x * mouseSensitive;
        horizontalAngle += turnPlayer;

        if (horizontalAngle >= 360) horizontalAngle -= 360;
        if (horizontalAngle < 0) horizontalAngle += 360;
        Vector3 currentAngle=transform.localEulerAngles;
        currentAngle.y = horizontalAngle;
        transform.localEulerAngles = currentAngle;

        //���콺 ���� ī�޶� ������ȯ
        float turnCamera=look.y * mouseSensitive;
        verticalAngle -=turnCamera;
        verticalAngle = Mathf.Clamp(verticalAngle, -89f, 89f); //���� ȸ�� ���� ����
        currentAngle = cameraTransform.localEulerAngles;
        currentAngle.x = verticalAngle;
        cameraTransform.localEulerAngles = currentAngle;
    }
}
