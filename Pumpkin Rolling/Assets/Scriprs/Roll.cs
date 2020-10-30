using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Roll : MonoBehaviour
{

    public Animator anim;
    public Transform mesh;
    public Transform movement;
    public CameraPostion mainCamera;

    public float movementForce;

    private float push;
    public float jump;

    public Transform playerInputSpace;

    private Rigidbody rb;

    private bool isGrounded;

    private float lastVel;
    private float air = 1;

    public delegate void CandyCollected();
    public static event CandyCollected OnCollect;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        push = movementForce * air;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < lastVel)
        {
            push *= 2;
        }
        rb.AddForce(playerInputSpace.TransformDirection(new Vector3(x * push, 0, y * push)));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0));
            anim.SetTrigger("Jump");

            isGrounded = false;
        }

        lastVel = rb.velocity.magnitude;

        float speed = lastVel;

        AkSoundEngine.SetRTPCValue("pumpSpeed",Mathf.Clamp(speed,0,2), gameObject, 0001);


    }

    private void Update()
    {
        movement.position = transform.position;
        mesh.rotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        air = 1;
    }

    void OnCollisionExit(Collision collision)
    {
        air = 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            mainCamera.isMoving = false;

            StartCoroutine("FlyAway");

        }
        else if (other.CompareTag("Finish"))
        {
            other.GetComponent<PlayableDirector>().Play();
        }
        else if (other.CompareTag("Candy"))
        {
            if (OnCollect != null)
            {
                OnCollect();
                other.gameObject.SetActive(false);
            }
        }


    }

    private IEnumerator FlyAway()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = transform.parent.position;
        mainCamera.isMoving = true;
    }
}
 


