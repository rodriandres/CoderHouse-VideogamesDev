using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 90.0f;
    float cameraAxis;
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
        transform.Translate(new Vector3( 0, 0, vAxis) * speed * Time.deltaTime);
    }

    private void RotatePLayer()
    {
        /*cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler( 0, cameraAxis, 0 );
        transform.localRotation = angulo;*/
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
    }
}
