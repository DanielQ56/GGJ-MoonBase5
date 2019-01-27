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
            string tag = gameObject.name;
            switch(tag)
            {
                case "Moon Dog":
                    GetComponent<MoonDogBehavior>().act();
                    break;
                default:
                    wallFamiliarity.addPoints(amountOfPoints);
                    interacted = true;
                    break;
            }
        }
    }
}
