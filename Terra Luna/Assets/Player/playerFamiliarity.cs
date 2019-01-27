using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFamiliarity : MonoBehaviour
{
    // Referring to familiarity as "points" in this script

    public float startingPoints = 0;
    public float maxPoints = 100;
    public float minPoints = 0;

    float currentPoints;

    void Start()
    {
        currentPoints = startingPoints;
    }

    // Update is called once per frame
    void Update()
    {
        //testChangingFamiliarity();
    }

    public float currentFamiliarity()
    {
        return currentPoints;
    }

    public void addToFamiliarity(float pointsToAdd)
    // Make pointsToAdd negative if you want to remove
    {
        Debug.Log("Points to add: " + pointsToAdd);
        Debug.Log("Before" + currentPoints);
        if (pointsToAdd > (maxPoints - currentPoints)){
            currentPoints = maxPoints;
        } else {
            currentPoints += pointsToAdd;
        }
        Debug.Log("After" + currentPoints);
    }


    void testChangingFamiliarity()
    {
        if (Input.GetKey("k")){
            addToFamiliarity(-1);
        } else if (Input.GetKey("i")){
            addToFamiliarity(1);
        }
    }
}
