using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
	public float Smooth = 2f;
	//float doorOpenY;
	//float doorCloseY;
	//float openAngle = 90f;
	//float closeAngle = 0f;
	private bool triggerOpen;
	private Quaternion DoorOpen;
	private Quaternion DoorClose;
	private bool doorIsOpen;
	
    // Start is called before the first frame update
    void Start()
    {
		triggerOpen = false;
		doorIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(triggerOpen == true) {
			var DoorOpen = Quaternion.Euler(0, -90f, 0);
		    transform.localRotation = Quaternion.Slerp(transform.localRotation, DoorOpen, Time.deltaTime*Smooth);
		    doorIsOpen = true;
			triggerDoorClose();
	   } else if (doorIsOpen && !triggerOpen) { //close door
			var DoorClose = Quaternion.Euler(0, 90f, 0);
		    transform.localRotation = Quaternion.Slerp(transform.localRotation, DoorClose, Time.deltaTime*Smooth);
		    doorIsOpen = false;
	   }
	   
    }
	
	public void triggerDoorOpen() {
		triggerOpen = true;
	}
	
	public void triggerDoorClose() {
		triggerOpen = false;
		yield WaitForSeconds (5);
	}

}
