using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Health.IHealthListenter
{
    public float WalkingSpeed = 7;
    public float mouseSensitive = 1;
    public Transform cameraTransform;

    float horizontalAngle;
    float verticalAngle;

    InputAction moveAction;
    InputAction lookAction;

    CharacterController characterController;

    //중력 변수
    public float gravity = 10;
    public float terminalSpeed = 20;
    float verticalSpeed;

    //점프 변수
    bool isGrounded;
    float groundedTimer;
    public float jumpSpeed = 10;

    //총
    InputAction fireAction;
    InputAction reloadAction;

    public List<WeaponController> weapons;
    int currentWeaponIndex;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 화면 밖으로 안 나감
        Cursor.visible = false;

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions;
        moveAction = inputActions.FindAction("Move");
        lookAction = inputActions.FindAction("Look");

        characterController = GetComponent<CharacterController>();

        horizontalAngle = transform.localEulerAngles.y;

        isGrounded = true;
        groundedTimer = 0;

        fireAction = inputActions.FindAction("Attack");
        reloadAction = inputActions.FindAction("Reload");
    }

    private void Update()
    {
        if(!GameManager.Instance.isPlaying) return;

        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);

        if (move.magnitude > 1) //이동 벡터가 1보다 크면
        {
            move.Normalize(); //벡터의 길이 1로 맞춤. W,D 동시 입력 시 더 빠르게 이동하는 문제 해결
        }
        move = move * WalkingSpeed * Time.deltaTime;
        move=transform.TransformDirection(move); //벡터를 내가 보고 있는 방향으로 바꿔줌
        characterController.Move(move);

        //마우스 좌우 방향전환
        Vector2 look = lookAction.ReadValue<Vector2>();
        float turnPlayer = look.x * mouseSensitive;
        horizontalAngle += turnPlayer;

        if (horizontalAngle >= 360) horizontalAngle -= 360;
        if (horizontalAngle < 0) horizontalAngle += 360;
        Vector3 currentAngle=transform.localEulerAngles;
        currentAngle.y = horizontalAngle;
        transform.localEulerAngles = currentAngle;

        //마우스 상하 카메라 각도전환
        float turnCamera=look.y * mouseSensitive;
        verticalAngle -=turnCamera;
        verticalAngle = Mathf.Clamp(verticalAngle, -89f, 89f); //상하 회전 범위 제한
        currentAngle = cameraTransform.localEulerAngles;
        currentAngle.x = verticalAngle;
        cameraTransform.localEulerAngles = currentAngle;

        //중력
        verticalSpeed -= gravity * Time.deltaTime; //속도 = 가속도 * 시간
        if (verticalSpeed < -terminalSpeed) // -terminalSpeed보다 똘어지는 속도가 작으면
        {
            verticalSpeed = -terminalSpeed;
        }
        Vector3 verticalMove = new Vector3(0, verticalSpeed, 0);
        verticalMove*=Time.deltaTime;

        CollisionFlags flag = characterController.Move(verticalMove); //중력속도 적용
        if((flag & (CollisionFlags.Below | CollisionFlags.Above)) != 0) //캐릭터 flag에 Below비트가 없으면 = 떨어지는 상태가 아니면
        {
            verticalSpeed = 0;
        }

        //점프
        if (!characterController.isGrounded)
        {
            if (isGrounded)
            {
                groundedTimer += Time.deltaTime;
                if (groundedTimer > 0.3f)
                {
                    isGrounded = false;
                }
            }
        }
        else
        {
            isGrounded=true;
            groundedTimer = 0;
        }

        //총 발사
        if (fireAction.WasCompletedThisFrame())
        {
            weapons[currentWeaponIndex].FireWeapon();
        }
        //재장전
        if (reloadAction.WasCompletedThisFrame())
        {
            weapons[currentWeaponIndex].ReloadWeapon();
        }
    }
    void OnJump()
    {
        if (isGrounded)
        {
            verticalSpeed = jumpSpeed;
            isGrounded = false;
        }
    }

    public void OnChangeWeapon()
    {
        weapons[currentWeaponIndex].gameObject.SetActive(false);
        currentWeaponIndex++;

        if (currentWeaponIndex > weapons.Count - 1)
        {
            currentWeaponIndex = 0;
        }
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
    public void OnDie()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GameManager.Instance.GameEnd();
    }
}
