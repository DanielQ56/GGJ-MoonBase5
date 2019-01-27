using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public bool startingHasPassedThrough = false;

    cameraTransition cameraTransitionManager;
    static bool inHallway;
	public AudioSource openDoor;
	public AudioSource footsteps;
	private bool playingFootsteps = false;
    void Start()
    {
        cameraTransitionManager = GameObject.FindWithTag("MainCamera").transform.GetChild(0).gameObject.GetComponent<cameraTransition>();
        inHallway = startingHasPassedThrough;
    }

    // Update is called once per frame
    void Update()
    {
        if(playingFootsteps && !inHallway) {
			footsteps.Stop();
			playingFootsteps = false;
		}
    }

    void OnTriggerEnter(Collider other)
    {
		openDoor.Play();
        if (!inHallway){
			footsteps.Play();
			playingFootsteps = true;
            cameraTransitionManager.transitionDown();
            inHallway = true;
            Debug.Log(inHallway);
        } else {
            cameraTransitionManager.transitionUp();
            inHallway = false;
            Debug.Log(inHallway);
        }
    }
}
