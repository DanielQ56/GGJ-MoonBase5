using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public float rayDist = 1;
    [SerializeField] float boxX;
    [SerializeField] float boxY;
    [SerializeField] float boxZ;
    [SerializeField] float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit[] boxCasts = Physics.BoxCastAll(transform.position + transform.forward * rayDist, new Vector3(boxX, boxY, boxZ), transform.forward, transform.rotation, maxDistance);
            if (boxCasts.Length > 0)
            {
                foreach (RaycastHit ray in boxCasts)
                {
					Debug.Log("Testing");
					Debug.Log(ray.collider.gameObject.name);
                    if (ray.collider.tag == "Interactive")
                    {
                        ray.collider.gameObject.GetComponent<Interactable>().interact();
                    }
                    else
                    {
                        doorInteraction(ray);
                    }
                }
            }

            /*if(Physics.Raycast(transform.position, fwd, out hit, rayDist)) {
                if(hit.collider.tag == "Interactive" && Input.GetKeyDown(KeyCode.Space)) {
                    hit.collider.gameObject.GetComponent<Interactable>().interact();
                } else {
                    //door can only be closed on an update if a different interaction isnt happening
                    doorInteraction(hit);
                }
            }*/
        }
    }
	
	
	void doorInteraction(RaycastHit hit) {
		if(hit.collider.tag == "Door" && Input.GetKeyDown(KeyCode.Space)) {
			//GameObject doorObj = hit.transform.gameObject;
			//GameObject doorObj = GameObject.Find("DoorHinge");
			
			GameObject doorObj = findClosestGameObject("DoorHinge");
			doorObj.GetComponent<doorScript>().triggerDoorOpen();
		} /*else { //check if the door should be closed
			//GameObject doorObj = findClosestGameObject("DoorHinge");
			//doorObj.GetComponent<doorScript>().triggerDoorClose();
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0);
			int i = 0;
			bool closeDoor = true;
			while(i < hitColliders.Length) {
				if(hitColliders[i].tag == "Door") {
					closeDoor = false;
				}
			}
			if(closeDoor) {
				GameObject doorObj = findClosestGameObject("DoorHinge");
				doorObj.GetComponent<doorScript>().triggerDoorClose();
			}
		}*/
	}
	
	GameObject findClosestGameObject(string tagName) {
		GameObject[] objs;
		objs = GameObject.FindGameObjectsWithTag(tagName);
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach(GameObject o in objs) {
			Vector3 diff = o.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if(curDistance < distance) {
				closest = o;
				distance = curDistance;
			}
		}
		return closest;
	}
	
	void askTargetToRespond() {
		Debug.Log("asked the target to respond");
	}
	
}
