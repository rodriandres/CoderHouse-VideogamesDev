using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject[] cannonBallPrefab;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCannonBall", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCannonBall()
    {
        int cannonBallIndex = Random.Range(0, cannonBallPrefab.Length);
        Instantiate(cannonBallPrefab[cannonBallIndex], transform.position, cannonBallPrefab[cannonBallIndex].transform.rotation);
    }
}
