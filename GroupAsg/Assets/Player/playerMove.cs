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

   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(verticalInput * speed, rb.velocity.y, horizontalInput * -speed);


        if (Input.GetKeyDown(KeyCode.Space) )
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            colparticleSystem.Play();
        }

       
       
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == ("DeathTrigger"))
        {
            SceneManager.LoadScene("Dead");
        }

        else if (other.gameObject.name == ("Trigger"))
        {
            SceneManager.LoadScene("Win");
        }


    }
}

