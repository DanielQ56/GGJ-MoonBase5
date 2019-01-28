using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadMessages : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    string messageToRead;
    GameObject camera;
    bool doneReading = true;
    bool addingLetter = false;
    string fullMessage = "";
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
            if(!addingLetter)
            {
                StartCoroutine(addLetter());
            }
            messageText.text = fullMessage;
        }
        else
        {
            if(!doneReading && Input.GetKeyDown(KeyCode.Space))
            {
                messageText.text = "";
                messageText.enabled = false;
                doneReading = true;
            }
        }
    }

    IEnumerator addLetter()
    {
        addingLetter = true;
        while(messageToRead.Length > 0)
        {
            fullMessage += messageToRead[0];
            messageToRead = messageToRead.Substring(1);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    

    public void ReadMessage(string message)
    {
        messageToRead = message;
        doneReading = false;
        messageText.enabled = true;

    }

    public bool doneReadingMessage()
    {
        return doneReading;
    }
}
