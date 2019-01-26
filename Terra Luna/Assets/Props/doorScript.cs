using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
	float Smooth = 1.5f;
	float doorOpenY;
	float doorCloseY;
	float openAngle = 90f;
	float closeAngle = 0f;
	private bool triggerOpen;
	
    // Start is called before the first frame update
    void Start()
    {
		triggerOpen = false;
		
    }

    // Update is called once per frame
    void Update()
    {
       if(triggerOpen == true) {
		   var DoorOpen = Quaternion.Euler(0, openAngle, 0);
		   transform.localRotation = Quaternion.Slerp(transform.localRotation, DoorOpen, Time.deltaTime*Smooth);
	   } 
	   
    }
	
	public void triggerDoorOpen() {
		triggerOpen = true;
	}
}
