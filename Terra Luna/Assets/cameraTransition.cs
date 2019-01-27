using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraTransition : MonoBehaviour
{
    AxisState cameraYAxis;
    [SerializeField] float downAngle = 0.1f;
    [SerializeField] float upAngle = 0.5f;
    public GameObject treeLookPoint;
    [SerializeField] GameObject playerLookPoint;
    // Start is called before the first frame update
    void Start()
    {
        cameraYAxis = GetComponent<CinemachineFreeLook>().m_YAxis;
    }

    // Update is called once per frame
    void Update()
    {
        //testCamera();
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
        if (GetComponent<CinemachineFreeLook>().LookAt != playerLookPoint.transform){
            GetComponent<CinemachineFreeLook>().LookAt = playerLookPoint.transform;
        }
        changeCameraYAngle(downAngle);
    }

    public void transitionUp()
    {
        //GetComponent<CinemachineFreeLook>().m_YAxis.Value = Mathf.Lerp((float)0.1, (float)0.5, 1);
        if (GetComponent<CinemachineFreeLook>().LookAt != playerLookPoint.transform){
            GetComponent<CinemachineFreeLook>().LookAt = playerLookPoint.transform;
        }
        changeCameraYAngle(upAngle);
    }

    public void treeTransition()
    {
        changeCameraYAngle(downAngle);
        GetComponent<CinemachineFreeLook>().LookAt = treeLookPoint.transform;
    }

    public void changeCameraYAngle(float newAngle){
        GetComponent<CinemachineFreeLook>().m_YAxis.Value = newAngle;
    }
}
