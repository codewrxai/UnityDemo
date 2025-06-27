using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 initialPosition;
    private Rigidbody rb;
    public float jumpForce = 0.5f; // Adjust the jump force as needed

    public bool allowInput = true;

    private void Start()
    {
        // Store the initial position when the game starts
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the ball!");
        }
    }

    private void Update()
    {
        if (allowInput)
        {
            if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * moveSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Jumping!");
            Jump();
        }
        }
    }

    private void Jump()
    {
        // Apply an upward force to the ball to make it jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
