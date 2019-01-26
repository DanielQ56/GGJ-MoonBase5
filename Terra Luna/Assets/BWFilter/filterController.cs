using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filterController : MonoBehaviour
{
    public int firstLevelMinimum = 25;
    public int secondLevelMinimum = 50;
    public int maxLevelMinimum = 75;

    public double minOpacity = 0;
    public double firstLevelOpacity = 0.33;
    public double secondLevelOpacity = 0.66;
    public double maxOpacity = 1;

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
        //manageOpacity();
        updateShaderOpacity();
    }

    void updateShaderOpacity()
    {
        float current = player.GetComponent<playerFamiliarity>().currentFamiliarity();

        if (current > maxLevelMinimum){
            setAlpha(maxOpacity);
        } else if (current > secondLevelMinimum){
            setAlpha(secondLevelOpacity);
        } else if (current > firstLevelMinimum){
            setAlpha(firstLevelOpacity);
        } else if (current < firstLevelMinimum){
            setAlpha(minOpacity);
        }

        if (current < 25){
            setAlpha(0);
        } else if (current < 50){
            setAlpha((float)0.25);
        } else if (current < 75){
            setAlpha((float)0.75);
        } else if (current <= 100){
            setAlpha((float)1);
        }

    }

    void setAlpha(double newAlpha)
    {
        Color newColor = thisMaterial.color;
        newColor.a = (float)newAlpha;
        thisMaterial.color = newColor;
    }
}
