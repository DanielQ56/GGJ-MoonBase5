using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFamiliarity : MonoBehaviour
{
    [SerializeField] int pointPerInteract;
    [SerializeField] int maxPoints;
    [SerializeField] GameObject player;

    int totalNumPoints = 0;
    static int allRoomPoints = 0; // Points across all rooms

    WallFamiliarity[] wallFam;
    // Start is called before the first frame update
    void Start()
    {
        wallFam = GetComponentsInChildren<WallFamiliarity>();
    }

    // Update is called once per frame
    void Update()
    {
        addRoomColor();
    }

    public void addPoints(int numPoints)
    {
        totalNumPoints += numPoints;
        player.GetComponent<playerFamiliarity>().addToFamiliarity(numPoints);
        allRoomPoints += numPoints;
        Debug.Log(totalNumPoints);
    }

    public void addRoomColor()
    {
        if(totalNumPoints % pointPerInteract == 0)
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
}
