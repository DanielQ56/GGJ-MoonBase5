using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
	GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hideOnPause();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) {
			if(Time.timeScale == 0) {
				Time.timeScale = 1;
				hideOnPause();
			} else {
				Time.timeScale = 0;
				showOnPause();
			}
		}
    }
	
	public void hideOnPause() {
		foreach(GameObject g in pauseObjects) {
			g.SetActive(false);
		}
	}
	
	public void showOnPause() {
		foreach(GameObject g in pauseObjects) {
			g.SetActive(true);
		}
	}
}
