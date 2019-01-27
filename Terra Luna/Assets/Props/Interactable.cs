using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] int amountOfPoints;
    GameObject player;

    bool interacted = false;
    WallFamiliarity wallFamiliarity;
    // Start is called before the first frame update
    void Start()
    {
        wallFamiliarity = GetComponentInParent<WallFamiliarity>();
        player = GameObject.FindWithTag("Player");
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
                    player.GetComponent<playerFamiliarity>().addToFamiliarity(amountOfPoints);
                    Debug.Log("Player familiarity: " + player.GetComponent<playerFamiliarity>().currentFamiliarity());
                    interacted = true;
                    gameObject.tag = "Untagged";
                    break;
            }
        }
    }
}
