using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 1.5f;
    public Transform legs;
    public LayerMask groundMask;
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
        if (GroundCheck() && Input.GetKeyDown(KeyCode.Space))
            velocity.y = jumpHeight * -gravity;
            
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        if ( Physics.Raycast(legs.position, 
            transform.TransformDirection(Vector3.down),
            out hit, 0.3f, groundMask))
        {
            switch(hit.collider.gameObject.tag)
            {
                case "FASTPlane":
                    speed = 20f;
                    break;
                case "SLOWPlane":
                    speed = 1f;
                    break;
                case "ReversePlane":
                    speed = -10f;
                    break;
                default:
                    speed = 10f;
                    break;
            }

            return true;
        }

        return false;
    }
}
