using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private GameObject player;
    private float enemySpeed = 5.0f;
    private float speedToLook = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RotateToPlayer();

    }

    private void RotateToPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation((player.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);
    }
}
