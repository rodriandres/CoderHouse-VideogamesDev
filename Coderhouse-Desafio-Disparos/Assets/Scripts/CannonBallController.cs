using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{

    private GameObject cannonBallPrefab;
    public float speedBall = 5.0f;
    public Vector3 direction = Vector3.forward;
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Fire!!!");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 45f)
        {
            MoveBall(direction);
        }
        
    }

    private void MoveBall(Vector3 direction)
    {
        transform.Translate(speedBall * Time.deltaTime * direction);
    }
}
