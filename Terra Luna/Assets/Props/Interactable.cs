using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] int amountOfPoints;

    bool interacted = false;
    WallFamiliarity wallFamiliarity;
    // Start is called before the first frame update
    void Start()
    {
        wallFamiliarity = GetComponentInParent<WallFamiliarity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void interact()
    {
        
        if (!interacted)
        {
            Debug.Log("Interacted");
            wallFamiliarity.addPoints(amountOfPoints);
            interacted = true;
        }
    }
}
