using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{

    private GameObject cannonBallPrefab;
    public float speedBall = 5.0f;
    public Vector3 direction = Vector3.forward;
    public int damage = 5;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    public float bulletLifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Charge..");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 45f)
        {
            MoveBall(direction);
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("ENORMIBUUSS!");
            IncreaseScale();
        }

        Destroy(gameObject, bulletLifeTime);


    }

    private void MoveBall(Vector3 direction)
    {
        transform.Translate(speedBall * Time.deltaTime * direction);
    }

    private void IncreaseScale()
    {
        transform.localScale = transform.localScale * 2;
    }
}
