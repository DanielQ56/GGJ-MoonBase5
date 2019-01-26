using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
	public float rayDist = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if(Physics.Raycast(transform.position, fwd, out hit, rayDist)) {
			if(hit.collider.tag == "Interactive" && Input.GetKeyDown(KeyCode.Space)) {
				askTargetToRespond();
			}
			
		}
		
        //check if raycast from player hits a target that has the Interactive tag
    }
	
	void askTargetToRespond() {
		Debug.Log("asked the target to respond");
	}
	
}
