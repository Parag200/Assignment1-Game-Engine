using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    private float speed = 7.0f;
    private float JumpForce = 4.5f;
    private Rigidbody rb;

    public ParticleSystem colparticleSystem;

    private Animator animator;

    private bool isJumping;
    private bool isGrounded;
    private bool isRunning;
    private bool isIdle;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animator.SetBool("IsIdle", true);
        isIdle = true;
        
    }

    // Update is called once per frame
    void Update()
    {
      

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(verticalInput * speed, rb.velocity.y, horizontalInput * -speed);

        if (horizontalInput != 0.0f || verticalInput != 0.0f)
        {
            animator.SetBool("IsRunning", true);
            isRunning = true;
            //Debug.Log("Running");

            animator.SetBool("IsIdle", false);
            isIdle = false;

            animator.SetBool("IsGrounded", true);
            isGrounded = true;

            animator.SetBool("IsJumping", false);
            isRunning = false;

            AudioManager.Instance.playFX("Footsteps", 0.4f);
           
        }

      

        if (horizontalInput == 0.0f && verticalInput == 0.0f)
        {
            //Debug.Log("Standing Idle");
            animator.SetBool("IsIdle", true);
            isIdle = true;

            animator.SetBool("IsRunning", false);
            isRunning = false;

            animator.SetBool("IsGrounded", true);
            isGrounded = true;

            animator.SetBool("IsJumping", false);
            isRunning = false;

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            isRunning = true;

            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            colparticleSystem.Play();

            AudioManager.Instance.playFX("Jump", 1f);

        }

       

        if (Input.GetKeyDown(KeyCode.Y))
        {

            this.GetComponent<Blur>().enabled = true;
        }

    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == ("DeathTrigger"))
        {
            SceneManager.LoadScene("Dead");
        }

        else if (other.gameObject.name == ("WinTrigger"))
        {
            SceneManager.LoadScene("Win");
        }

    }
}

