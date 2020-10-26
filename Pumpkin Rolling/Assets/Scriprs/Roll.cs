using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float push;
    public float jump;

    public Transform playerInputSpace;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.transform.GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.AddTorque(playerInputSpace.TransformDirection(new Vector3(y, 0, -x)) * push);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jump, 0));
            anim.SetTrigger("Jump");
        }
     
    }
}
