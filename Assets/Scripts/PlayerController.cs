using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;
    float moveX, moveY;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    private int countJump = 0;
    private bool isGrounded;
    public float airControl = 0.75f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(moveX, 0, moveY) * velocidad;
        if (isGrounded)
        {
            rb.AddForce(movimiento);
        }
        else
        {
            rb.AddForce(movimiento * airControl);

        }
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * 0.9f, rb.linearVelocity.y, rb.linearVelocity.z * 0.9f);
    }

    void OnMove(InputValue moveValue)
    {
        Vector2 move = moveValue.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points"))
        {
            Points point = other.gameObject.GetComponent<Points>();
            if (point != null)
            {
                point.GetPoints();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            countJump = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnJump(InputValue jumpValue)
    {
        if (countJump < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            countJump++;
        }
    }
}

