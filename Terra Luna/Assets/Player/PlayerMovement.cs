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
<<<<<<< Updated upstream
        m_RigidBody.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed;
        //animator.SetFloat("Forward", Input.GetAxis("Vertical"));
=======
        float mVertical = Input.GetAxis("Vertical");
        //m_RigidBody.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

        /* Vector3 newMovement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        m_RigidBody.AddForce(newMovement * moveSpeed);
        if (m_RigidBody.velocity.magnitude > maxSpeed){
            m_RigidBody.velocity = m_RigidBody.velocity.normalized * maxSpeed;
        }*/


        m_RigidBody.velocity = (new Vector3(transform.forward.x * moveSpeed, m_RigidBody.velocity.y, transform.forward.z * moveSpeed) * mVertical);

        
>>>>>>> Stashed changes
    }

    void Rotate()
    {
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Horizontal") * 10, 0);
    }
}
