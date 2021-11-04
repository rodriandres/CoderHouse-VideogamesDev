using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rbPortal;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rbPortal = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
