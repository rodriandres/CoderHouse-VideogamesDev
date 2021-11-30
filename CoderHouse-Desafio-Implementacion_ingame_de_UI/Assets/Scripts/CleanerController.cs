using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChasingPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Spawner"))
        {
            Destroy(other.gameObject);
        }
    }

    //Vector3 GetPlayerDistance()
    //{
    //    return player.transform.position - transform.position;
    //}

    void ChasingPlayer ()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z - offset);
    }
}
