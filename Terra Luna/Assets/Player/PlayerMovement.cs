 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    
    Rigidbody m_RigidBody;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        m_RigidBody.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed;
        //animator.SetFloat("Forward", Input.GetAxis("Vertical"));
    }

    void Rotate()
    {
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Horizontal") * 10, 0);
    }
}
