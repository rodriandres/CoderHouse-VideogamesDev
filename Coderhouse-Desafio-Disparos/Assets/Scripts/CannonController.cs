using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallSpawner;
    public float speedCannon = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cannonBallSpawner, transform.position, cannonBallSpawner.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            MoveCannon(Vector3.forward);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            MoveCannon(Vector3.right);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            MoveCannon(Vector3.left);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S.");
            MoveCannon(Vector3.back);
        }
    }

    private void MoveCannon(Vector3 direction)
    {
        transform.Rotate(speedCannon * direction * Time.deltaTime);
    }
}
