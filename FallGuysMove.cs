using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float jumpSpeed = 15f;
    Rigidbody rb;
    Animator animator;
    Vector3 direction;
    Vector3 startPosition;
    bool isGrounded;
    bool slide;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if (direction.magnitude > 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Dance");
        }
        if (transform.position.y < -10)
        {
            transform.position = startPosition;
        }
        if (slide)
        {
            rb.AddForce(direction * 0.1f, ForceMode.VelocityChange);
        }

    }
    private void FixedUpdate()
    { 
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("slide"))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }  
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plate"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CheckPoint"))
        {
            startPosition = other.transform.position;
            Destroy(other.gameObject);
        }
    }
} 
