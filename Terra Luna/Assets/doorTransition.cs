using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public bool startingHasPassedThrough = false;

    cameraTransition cameraTransitionManager;
    bool hasPassedThrough;
    void Start()
    {
        cameraTransitionManager = GameObject.FindWithTag("MainCamera").transform.GetChild(0).gameObject.GetComponent<cameraTransition>();
        hasPassedThrough = startingHasPassedThrough;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasPassedThrough){
            cameraTransitionManager.transitionUp();
            hasPassedThrough = true;
        } else {
            cameraTransitionManager.transitionDown();
            hasPassedThrough = false;
        }
    }
}
