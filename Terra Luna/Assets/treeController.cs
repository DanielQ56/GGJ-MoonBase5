using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour
{
    // First stage is the minimum possible familiarity
    public int SecondStageMinimum = 25;
    public int ThirdStageMinimum = 50;
    public int FinalStageMinimum = 75;
    public GameObject[] rooms;

    // "stageObject" means the different GameObjects containing different meshes/etc.
    // for the different stages of the tree
    public GameObject initialStageObject;
    public GameObject secondStageObject;
    public GameObject thirdStageObject;
    public GameObject finalStageObject;

    GameObject player;
    GameObject aRoom;
    GameObject currentStageObject;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
        }
        player = GameObject.FindWithTag("Player");
        aRoom = rooms[0];
        currentStageObject = initialStageObject;
        currentStageObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        updateTreeState();
    }

    void updateTreeState()
    {
        float current = player.GetComponent<playerFamiliarity>().currentFamiliarity();

        if (current > FinalStageMinimum){
            changeTreeStage(finalStageObject);
        } else if (current > ThirdStageMinimum){
            changeTreeStage(thirdStageObject);
        } else if (current > SecondStageMinimum){
            changeTreeStage(secondStageObject);
        } else {
            changeTreeStage(initialStageObject);
        }
        
    }

    void changeTreeStage(GameObject newStageObject){
        if (newStageObject != currentStageObject){
            currentStageObject.SetActive(false);
            currentStageObject = newStageObject;
            currentStageObject.SetActive(true);
        }
    }
}
