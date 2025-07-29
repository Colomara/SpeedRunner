using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float gravity = -20f;

    private CharacterController controller;
    private float verticalVelocity;
    private bool isGrounded;
    private float originalSpeed;
    private bool isBoosted = false;
    private float speedMultiplier = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalSpeed = moveSpeed;
    }
    public void ActivateSpeedBoost()
    {
        
        if (isBoosted) return;
        isBoosted = true;
        moveSpeed *= 2f;
        Invoke(nameof(ResetSpeed), 5f);
    }

    void ResetSpeed()
    {
        moveSpeed = originalSpeed;
        isBoosted = false;
    }
    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = value;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // небольшое значение чтобы не "парить"
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpForce;
        }

        // Гравитация
        verticalVelocity += gravity * Time.deltaTime;

        // Движение по осям XZ
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Объединяем с вертикалью
        Vector3 velocity = move * moveSpeed *speedMultiplier;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
