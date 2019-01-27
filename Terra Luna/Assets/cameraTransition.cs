using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraTransition : MonoBehaviour
{
    AxisState cameraYAxis;
    // Start is called before the first frame update
    void Start()
    {
        cameraYAxis = GetComponent<CinemachineFreeLook>().m_YAxis;
    }

    // Update is called once per frame
    void Update()
    {
        testCamera();
    }

    void testCamera()
    {
        if (Input.GetKeyDown("j")){
            Debug.Log("Going down");
            transitionDown();
        } else if (Input.GetKeyDown("u")){
            transitionUp();
            Debug.Log("Going up");
        }
    }

    public void transitionDown()
    {
        //GetComponent<CinemachineFreeLook>().m_YAxis.Value = (float)Mathf.Lerp((float)0.1,(float)0.5,Time.deltaTime);
        GetComponent<CinemachineFreeLook>().m_YAxis.Value = (float)0.1;
    }

    public void transitionUp()
    {
        //GetComponent<CinemachineFreeLook>().m_YAxis.Value = Mathf.Lerp((float)0.1, (float)0.5, 1);
        GetComponent<CinemachineFreeLook>().m_YAxis.Value = (float)0.5;
    }
}
