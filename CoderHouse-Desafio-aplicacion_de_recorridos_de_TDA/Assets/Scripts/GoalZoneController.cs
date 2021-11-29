using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneController : MonoBehaviour
{
    float stayTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        stayTime += Time.deltaTime;
        if (stayTime >= 2f)
        {
            GameManager.instance.setActiveTraps(false);
            Debug.Log("Traps Disabled!");
            stayTime = 0;
        }
        
    }
}
