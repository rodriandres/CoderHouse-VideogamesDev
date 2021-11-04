using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 90.0f;
    float cameraAxis;
    private bool crossPortal;
    float i;
    public GameObject[] spawnPoints; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotatePLayer();
        MovePlayer();
    }

    private void MovePlayer()
    {
        float vAxis = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, vAxis) * speed * Time.deltaTime);

    }

    private void RotatePLayer()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with object: " + collision.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Trigger: " + other.gameObject.name);
            i += Time.deltaTime;

            if (i >= 2f)
            {
                MoveWall(other);
                i = 0;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Portal") && crossPortal)
        {
            Debug.Log("Trigger: " + other.gameObject.name);
            transform.localScale = transform.localScale / 2;
            crossPortal = false;
        }
        else if (other.gameObject.CompareTag("Portal") && !crossPortal)
        {
            Debug.Log("Trigger: " + other.gameObject.name);
            transform.localScale = transform.localScale * 2;
            crossPortal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Portal") && crossPortal)
        {
            Debug.Log("Trigger: " + other.gameObject.name);
            transform.localScale = transform.localScale / 2;
            crossPortal = false;
        }
        else if (other.gameObject.CompareTag("Portal") && !crossPortal)
        {
            Debug.Log("Trigger: " + other.gameObject.name);
            transform.localScale = transform.localScale * 2;
            crossPortal = true;
        }
    }

    private void MoveWall(Collider other)
    {
        int random = Random.Range(0, 4);
        Debug.Log(spawnPoints[random].transform.position);
        other.gameObject.transform.position = spawnPoints[random].transform.position;
        other.gameObject.transform.rotation = spawnPoints[random].transform.rotation;
    }
        
}
