using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour
{
    // First stage is the minimum possible familiarity
    public int SecondStageMinimum = 25;
    public int FinalStageMinimum = 75;
    public GameObject[] rooms;

    // "stageObject" means the different GameObjects containing different meshes/etc.
    // for the different stages of the tree
    public GameObject firstStageObject;
    public GameObject secondStageObject;
    public GameObject finalStageObject;

	public AudioSource firstMusic;
	public AudioSource secondMusic;
	public AudioSource thirdMusic;
	
	private bool playedFirst = false;
	private bool playedSecond = false;
	private bool playedThird = false;
	
    GameObject player;
    GameObject aRoom;
    GameObject currentStageObject;

    int totalMaxPoints;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
        }
        player = GameObject.FindWithTag("Player");
        aRoom = rooms[0];
        currentStageObject = firstStageObject;
        currentStageObject.SetActive(true);

        totalMaxPoints = 0;
        foreach(GameObject room in rooms){
            totalMaxPoints += room.GetComponent<RoomFamiliarity>().getMaxPoints();
        }

        SecondStageMinimum = totalMaxPoints / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTreeState();
    }

    void updateTreeState()
    {
        float current = player.GetComponent<playerFamiliarity>().currentFamiliarity();

        if (current == totalMaxPoints){
			
			if (!playedThird) {
				Debug.Log("Playing Third");
				secondMusic.Stop();
				thirdMusic.Play();
				playedThird = true;
			}
            changeTreeStage(finalStageObject);
        } else if (current > SecondStageMinimum){
			if(!playedSecond) {
				Debug.Log("Playing Second");
				firstMusic.Stop();
				secondMusic.Play();
				playedSecond = true;
			}
            changeTreeStage(secondStageObject);
        } else {
			if(!playedFirst) {
				Debug.Log("Playing First");
				firstMusic.Play();
				playedFirst = true;
			}
			
            changeTreeStage(firstStageObject);
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
