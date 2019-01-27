using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFamiliarity : MonoBehaviour
{

    filterController[] filters;
    RoomFamiliarity room;
    // Start is called before the first frame update
    int propCount;

    void Start()
    {
        filters = GetComponentsInChildren<filterController>();
        room = GetComponentInParent<RoomFamiliarity>();

        propCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void colorWalls(float current)
    {
        foreach(filterController filter in filters)
        {
            filter.updateShaderOpacity(current);
        }
    }

    public void addPoints(int numPoints)
    {
        room.addPoints(numPoints);
    }

    public void addRoomPoints()
    {
        room.addRoomPoints();
    }

    public int getPropCount(){
        /*
        propCount = 0;
        foreach(Transform child in transform){
            propCount++;
        }
        Debug.Log("Count: " + propCount);
        */
        return transform.childCount;
    }
}
