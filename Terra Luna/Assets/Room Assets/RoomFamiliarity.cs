using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFamiliarity : MonoBehaviour
{
     int pointsPerInteract;
    [SerializeField] int maxPoints;
    [SerializeField] GameObject player;
    [SerializeField] GameObject propManager;

    int totalNumPoints = 0;
    static int allRoomPoints = 0; // Points across all rooms
    int propAmount;
    //[SerializeField] int propAmount2;

    WallFamiliarity[] wallFam;
    Interactable[] props;
    // Start is called before the first frame update
    void Start()
    {
        wallFam = GetComponentsInChildren<WallFamiliarity>();
        propAmount = propManager.GetComponent<WallFamiliarity>().getPropCount();
    }

    // Update is called once per frame
    void Update()
    {
        addRoomColor();
    }

    public void addPoints(int numPoints)
    {
        totalNumPoints += numPoints;
        Debug.Log(gameObject.name + " Familiarity: " + numPoints);
        player.GetComponent<playerFamiliarity>().addToFamiliarity(numPoints);
        allRoomPoints += numPoints;
        Debug.Log(totalNumPoints);
    }

    public void addRoomPoints()
    {
        totalNumPoints += pointsPerInteract;
        Debug.Log(gameObject.name + " Familiarity: " + pointsPerInteract);
        player.GetComponent<playerFamiliarity>().addToFamiliarity(pointsPerInteract);
        allRoomPoints += pointsPerInteract;
        Debug.Log(totalNumPoints);
    }

    public void addRoomColor()
    {
        pointsPerInteract = maxPoints / propAmount;
        if(totalNumPoints % pointsPerInteract == 0)
        {
            foreach(WallFamiliarity wall in wallFam)
            {
                wall.colorWalls(((float)totalNumPoints / (float)maxPoints) * 100);
            }
        }
    }
    public int getAllRoomPoints()
    {
        return allRoomPoints;
    }

    public int getMaxPoints()
    {
        return maxPoints;
    }
}
