using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filterController : MonoBehaviour
{
    public int firstLevelMinimum = 25;
    public int secondLevelMinimum = 50;
    public int maxLevelMinimum = 76;

    public double minOpacity = 1;
    public double firstLevelOpacity = 0.66;
    public double secondLevelOpacity = 0.33;
    public double maxOpacity = 0;

    Material thisMaterial;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateShaderOpacity(float current)
    {
        if (current < firstLevelMinimum)
        {
            setAlpha(minOpacity);
        }
        else if (current < secondLevelMinimum)
        {
            setAlpha(firstLevelOpacity);
        }
        else if (current < maxLevelMinimum)
        {
            setAlpha(secondLevelOpacity);
        }
        else
        {
            setAlpha(maxOpacity);
        }

    }

    void setAlpha(double newAlpha)
    {
        Color newColor = thisMaterial.color;
        newColor.a = (float)newAlpha;
        thisMaterial.color = newColor;
    }
}
