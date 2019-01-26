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
        
    }

    public float currentFamiliarity()
    {
        return currentPoints;
    }

    public void addFamiliarity(float pointsToAdd)
    {
        if (pointsToAdd > (maxPoints - currentPoints)){
            currentPoints = maxPoints;
        } else {
            currentPoints += pointsToAdd;
        }
    }

    public void removeFamiliarity(float pointsToRemove)
    {
        if (pointsToRemove > (currentPoints - minPoints)){
            currentPoints = minPoints;
        } else {
            currentPoints -= minPoints;
        }
    }
}
