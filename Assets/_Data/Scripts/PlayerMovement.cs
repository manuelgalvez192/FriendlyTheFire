using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    public bool isGrounded = false;
    [SerializeField] LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

	private void FixedUpdate()
	{
        isGrounded = groundRaycast();

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;

            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;

            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }

	private bool groundRaycast()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundMask);
    }
}
