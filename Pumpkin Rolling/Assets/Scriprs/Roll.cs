using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    
    public Animator anim;
    public Transform mesh;
    public Transform movement;

    public float push;
    public float jump;

    public Transform playerInputSpace;

    private Rigidbody rb;
    private Collider collider;

    private bool isGrounded;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<Collider>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.AddTorque(playerInputSpace.TransformDirection(new Vector3(y, 0, -x)) * push);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0));
            anim.SetTrigger("Jump");

            isGrounded = false;
        }
    }

    private void Update()
    {
        movement.position = transform.position;
        mesh.rotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
