﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDogCredits : MonoBehaviour
{
	private float timePerMovement;
	
    // Start is called before the first frame update
    void Start()
    {
		ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        timePerMovement -= Time.deltaTime;
		if(timePerMovement <= 0) {
			ChangeDirection();
		}
		
		GetComponent<Rigidbody>().velocity = transform.up * 10;
    }
	
	void ChangeDirection() {
		float angle = Random.Range(0f, 360f);
		Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
		Vector3 newUp = quat * Vector3.up;
		newUp.z = 0;
		newUp.Normalize();
		transform.up = newUp;
		timePerMovement = 4.0f;
	}
}
