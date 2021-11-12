using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 90.0f;
    float cameraAxis;

    Vector3 jump;
    [SerializeField] private float jumpForce = 2.0f;
    bool isGrounded;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        playerAnimator.SetBool("isRun", false );
    }

    // Update is called once per frame
    void Update()
    {
        RotatePLayer();
        Jump();
        MovePlayer();
    }

    private void MovePlayer()
    {
        float vAxis = Input.GetAxis("Vertical");
        
        if (vAxis != 0)
        {
            playerAnimator.SetBool("isRun", true);
            transform.Translate(new Vector3(0, 0, vAxis) * speed * Time.deltaTime);
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }
    }

    private void RotatePLayer()
    {
        /*cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler( 0, cameraAxis, 0 );
        transform.localRotation = angulo;*/
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetBool("isGrounded", true);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else
        {
            playerAnimator.SetBool("isGrounded", false);
        }

        
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
