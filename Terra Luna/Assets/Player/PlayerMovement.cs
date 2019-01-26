using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotateDegree;
    [SerializeField] float moveSpeed;

    
    Rigidbody m_RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
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
    }

    void Rotate()
    {
        transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Horizontal") * rotateDegree, 0);
    }
}
