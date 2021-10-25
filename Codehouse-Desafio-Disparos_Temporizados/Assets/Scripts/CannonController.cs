using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public float timeInterval = 1.5f;
    public float speedCannon = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InitiateCannonBallPrefab();
        InvokeRepeating("InitiateCannonBallPrefab", 1, timeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCannon();     
    }

    private void InitiateCannonBallPrefab()
    {
        Instantiate(cannonBallPrefab, transform.position, Quaternion.identity);
    }
    private void MoveCannon()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            MoveCannonInDirection(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            MoveCannonInDirection(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            MoveCannonInDirection(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {
            MoveCannonInDirection(Vector3.back);
        }
    }

    private void MoveCannonInDirection(Vector3 direction)
    {
        transform.Translate(speedCannon * direction * Time.deltaTime);
    }

}
