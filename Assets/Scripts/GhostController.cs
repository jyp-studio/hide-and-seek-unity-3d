using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class GhostController : MonoBehaviour
{
    // moving
    public Vector3 MovingDirection;
    Rigidbody rb;
    Animator animator;
    // [SerializeField] float movingSpeed = 0f;
    // [SerializeField] float JumpForce = 100f;
    bool run = false;
    public int SceneIndexDestination = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run = false;

        // move
        if (Input.GetKey(KeyCode.W))
        {
            run = true;
            // transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            run = true;
            // transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            run = true;
            // transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            run = true;
            // transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
        }
        animator.SetBool("Run", run);

        // attack
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Shoot");
        }
        //
    }

    // private void OnCollisionStay(UnityEngine.Collision collision)
    // {
    //     if (collision.transform.tag == "Ground")
    //     {
    //         if (Input.GetKey(KeyCode.Space))
    //         {
    //             // animator.SetTrigger("Jump");
    //             rb.AddForce(JumpForce * Vector3.up);
    //         }
    //     }
    // }
}
