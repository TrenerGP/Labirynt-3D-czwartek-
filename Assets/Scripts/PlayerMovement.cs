using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 1.5f;
    Vector3 velocity;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = 0f;
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            velocity.y = jumpHeight;

        //velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
