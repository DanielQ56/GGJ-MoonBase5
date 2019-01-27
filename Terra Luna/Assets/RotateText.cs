using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateText : MonoBehaviour
{
    [SerializeField] Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithCamera();
    }

    void RotateWithCamera()
    {
        transform.rotation = camera.transform.rotation;
    }
}
