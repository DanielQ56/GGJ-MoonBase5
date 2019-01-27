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
	
	public AudioSource doorOpen;
	//public AudioSource doorClose;
	private bool audioPlayed = false;
	
	bool closeDoor = false;
	bool waitActive = false;
	
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
		    if (!audioPlayed) {
				doorOpen.Play();
				audioPlayed = true;
			}
			var DoorOpen = Quaternion.Euler(0, -90f, 0);
		    transform.localRotation = Quaternion.Slerp(transform.localRotation, DoorOpen, Time.deltaTime*Smooth);
		    doorIsOpen = true;
			triggerDoorClose();
	   } else if (doorIsOpen && !triggerOpen) { //close door
			//doorClose.Play();
			var DoorClose = Quaternion.Euler(0, 0f, 0);
		    transform.localRotation = Quaternion.Slerp(transform.localRotation, DoorClose, Time.deltaTime*Smooth);
		    doorIsOpen = false;
	   }
	   
    }
	
	public void triggerDoorOpen() {
		triggerOpen = true;
	}
	
	
	public void triggerDoorClose() {
		if(!waitActive) {
			StartCoroutine(Wait());
		} 
		if(closeDoor) {
			triggerOpen = false;
		}
	}

	IEnumerator Wait() {
		waitActive = true;
		yield return new WaitForSeconds(5.0f);
		closeDoor = true;
		waitActive = false;
	}
	
}
