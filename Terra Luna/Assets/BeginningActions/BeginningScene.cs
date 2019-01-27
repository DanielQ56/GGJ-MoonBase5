using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform stopPos;
    [SerializeField] GameObject computer;
    [SerializeField] float initialWaitTime;
    [SerializeField] Camera camera;
    [SerializeField] TextMeshPro text;

    Rigidbody m_Body;
    bool movingToComputer;
    Vector3 c_Pos;
    ThirdPersonCharacter tpc;
    bool reading = false;
    bool doneReading = false;
    // Start is called before the first frame update
    void Start()
    {
        tpc = GetComponent<ThirdPersonCharacter>();
        c_Pos = new Vector3(stopPos.position.x, 0, stopPos.position.z);
        m_Body = GetComponent<Rigidbody>();
        StartCoroutine(moveToComputer());
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Read();
    }

    void Read()
    {
        if (!doneReading)
        {
            if (!reading)
            {
               ReadMessage(computer.GetComponent<ReceivedMessages>().getCurrentMessage());
                reading = true;
            }
            else
            {
                if(reading)
                {

                }
            }
        }
    }

    void ReadMessage(string message)
    {

    }

    void Move()
    {
        if (movingToComputer)
        {
            if (transform.position == c_Pos)
            {
                tpc.Move(Vector3.zero);
                movingToComputer = false;
                read = true;
            }
            tpc.Move(transform.forward);
        }
    }

    void BeginningSequence()
    {
        StartCoroutine(moveToComputer());
    }

    IEnumerator moveToComputer()
    {
        yield return new WaitForSeconds(initialWaitTime);
        movingToComputer = true;
    } 

    IEnumerator ReadMessage()
    {
        yield return new WaitForSeconds(1f);
    }


}
