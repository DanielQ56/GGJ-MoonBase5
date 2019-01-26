using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFamiliarity : MonoBehaviour
{

    filterController[] filters;
    RoomFamiliarity room;
    // Start is called before the first frame update
    void Start()
    {
        filters = GetComponentsInChildren<filterController>();
        room = GetComponentInParent<RoomFamiliarity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void colorWalls(float current)
    {
        foreach(filterController filter in filters)
        {
            Debug.Log(current);
            filter.updateShaderOpacity(current);
        }
    }

    public void addPoints(int numPoints)
    {
        room.addPoints(numPoints);
    }
}
