using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedMessages : MonoBehaviour
{
    [SerializeField] string[] messages;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string getCurrentMessage()
    {
        string s = messages[counter];
        counter += 1;
        return s; 
    }

    
}
