using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeCameraTransition : MonoBehaviour
{
    // Start is called before the first frame update

    bool nearTree;
    cameraTransition cameraTransitionManager;
    GameObject player;

    void Start()
    {
        cameraTransitionManager = GameObject.FindWithTag("MainCamera").transform.GetChild(0).gameObject.GetComponent<cameraTransition>();
        nearTree = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player){
            if (!nearTree){
                cameraTransitionManager.treeTransition();
                nearTree = true;
                Debug.Log(nearTree);
            } 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player){
            cameraTransitionManager.transitionUp();
            nearTree = false;
            Debug.Log(nearTree);
        }
    }
}
