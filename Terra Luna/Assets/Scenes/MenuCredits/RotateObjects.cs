using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
	public GameObject[] rotatingObjects;
	public float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < rotatingObjects.Length; i++) {
			rotatingObjects[i].transform.RotateAround(transform.position, Vector3.up, rotateSpeed*Time.deltaTime);
	    } 
    }
}
