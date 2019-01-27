using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDogBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float minDistanceAway;
    [SerializeField] float maxDistanceAway;
    [SerializeField] float moveSpeed;
    

    bool following = false;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(following)
            followPlayer();
    }

    public void act()
    {
        if(!following)
        {
            Debug.Log("Following!");
            following = true;
        }
        else
        {
            following = false;
        }
    }

    void followPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.eulerAngles += new Vector3(0, 180, 0);
        if (distanceAway() > maxDistanceAway)
        {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), moveSpeed * Time.deltaTime);
            
        }

    }

    float distanceAway()
    {
        return Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.z - transform.position.z, 2));
    }
}
