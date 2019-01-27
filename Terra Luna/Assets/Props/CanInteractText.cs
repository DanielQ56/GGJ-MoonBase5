using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanInteractText : MonoBehaviour
{
    [SerializeField] TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUp()
    {
        text.enabled = true;
    }

    public void OutOfView()
    {
        text.enabled = false;
    }
}
