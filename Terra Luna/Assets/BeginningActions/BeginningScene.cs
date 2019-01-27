using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeginningScene : MonoBehaviour
{
    [SerializeField] Transform stopPos;
    [SerializeField] GameObject computer;
    [SerializeField] float initialWaitTime;

    Rigidbody m_Body;
    bool movingToComputer;
    Vector3 c_Pos;
    ThirdPersonCharacter tpc;
    ReadMessages r;
    bool shouldRead = false;
    bool reading = false;
    bool doneReading = false;
    // Start is called before the first frame update
    void Start()
    {
        tpc = GetComponent<ThirdPersonCharacter>();
        c_Pos = new Vector3(stopPos.position.x, 0, stopPos.position.z);
        m_Body = GetComponent<Rigidbody>();
        BeginningSequence();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Read();
    }

    void Read()
    {
        if (shouldRead)
        {
            if(!reading)
            {
                r.ReadMessage(computer.GetComponent<ReceivedMessages>().getCurrentMessage());
                reading = true;
            }
            else if(r.doneReadingMessage())
            {
                allowPlayerToMove();
            }
        }
       
    }


    void Move()
    {
        if (movingToComputer)
        {
            if (transform.position == c_Pos)
            {
                tpc.Move(Vector3.zero);
                movingToComputer = false;
                
            }
            tpc.Move(transform.forward);
        }
    }

    void BeginningSequence()
    {
        if(!movingToComputer)
            StartCoroutine(moveToComputer());
    }

    IEnumerator moveToComputer()
    {
        yield return new WaitForSeconds(initialWaitTime);
        movingToComputer = true;
    } 
    

    void allowPlayerToMove()
    {
        ThirdPersonUserControl.canMove = true;
    }


}
