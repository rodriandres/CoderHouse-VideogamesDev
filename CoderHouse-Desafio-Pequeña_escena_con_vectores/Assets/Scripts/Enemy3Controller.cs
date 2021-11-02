using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    private GameObject player;
    private float enemySpeed = 2.0f;
    private float speedToLook = 5.0f;
    enum ChasingType { JustLooking = 1, GetOverHere}
    [SerializeField] private ChasingType chasingType;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (chasingType)
        {
            case ChasingType.JustLooking:
                RotateToPlayer();
                break;
            case ChasingType.GetOverHere:
                MoveTowards();
                break;
            default:
                Debug.Log("ERROR: Trying to make something crazy!!!");
                break;
        }
    }

    private void MoveTowards()
    {
        Vector3 direction = player.transform.position - transform.position - new Vector3(1f,0,1f);
        transform.Translate(enemySpeed * direction.normalized * Time.deltaTime);
    }

    private void RotateToPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation((player.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);
    }
}
