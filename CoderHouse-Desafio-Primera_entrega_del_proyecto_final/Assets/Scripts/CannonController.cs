using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float distanceRay;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject ballPrefab;
    private bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastCeiling();
    }


    private void RaycastCeiling()
    {
        RaycastHit hit;

        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.down), out hit, distanceRay) && !fire)
        {
            fire = true;
            Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
            Debug.Log("FIREEEE!");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.down) * distanceRay);
    }
}
