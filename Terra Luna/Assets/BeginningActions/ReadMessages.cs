using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadMessages : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    string messageToRead;
    GameObject camera;
    bool doneReading = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        messageToRead = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(messageToRead.Length > 0)
        {

        }
        else
        {
            doneReading = true;
        }
    }

    public void ReadMessage(string message)
    {
        messageToRead = message;
        doneReading = false;
    }

    public bool doneReadingMessage()
    {
        return doneReading;
    }
}
