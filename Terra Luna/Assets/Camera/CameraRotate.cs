using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float rotateDegree;
    [SerializeField] GameObject player;
    [SerializeField] float speed;


    bool stuckAgainstWall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            CameraRotatation();
    }

    /*private void LateUpdate()
    {
        if (!inDistance())
        {
            transform.LookAt(player.transform, Vector3.up);
            KeepDistance();
        }
    }*/
    void CameraRotatation()
    {
        transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxisRaw("CameraRotate") * rotateDegree);
    }

    /*bool inDistance()
    {
        return Mathf.Sqrt(Mathf.Pow((transform.position.x - player.transform.position.x), 2) + Mathf.Pow((transform.position.z - player.transform.position.z), 2)) < 22f;


    }

    void KeepDistance()
    {
        float interpolation = speed * Time.deltaTime ;
        float x_pos = Mathf.Lerp(transform.position.x, player.transform.position.x, interpolation); 
        float z_pos = Mathf.Lerp(transform.position.z, player.transform.position.z, interpolation);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_pos, transform.position.y, z_pos), 0.2f);
    }*/
}
