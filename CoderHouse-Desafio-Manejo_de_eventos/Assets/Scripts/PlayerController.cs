using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerHp = 5;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 90.0f;


    Vector3 jump;
    [SerializeField] private float jumpForce = 2.0f;
    bool isGrounded;
    bool isIddle;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator playerAnimator;

    private InventaryController inventory;

    // EVENTS
    public static event Action<int> onUpdateHP;
    public static event Action onDeath;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inventory = GetComponent<InventaryController>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        onUpdateHP?.Invoke(playerHp);

        playerAnimator.SetBool("IsRun", false );
        playerAnimator.SetBool("IsGrounded", true);
        playerAnimator.SetBool("IsIddle", true);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePLayer();
        Jump();
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.G))
        {
            UseItem();
        }
    }

    private void MovePlayer()
    {
        float vAxis = Input.GetAxis("Vertical");
        
        if (vAxis != 0)
        {
            playerAnimator.SetBool("IsRun", true);
            transform.Translate(new Vector3(0, 0, vAxis) * speed * Time.deltaTime);
        }
        else
        {
            playerAnimator.SetBool("IsRun", false);
        }
    }

    private void RotatePLayer()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                playerAnimator.SetBool("IsGrounded", true);
                playerAnimator.SetBool("IsIddle", true);
                isGrounded = false;
                isIddle = false;
                
                
            }
        }
        else
        {
            playerAnimator.SetBool("IsGrounded", false);
            playerAnimator.SetBool("IsIddle", false);
            isGrounded = true;
            isIddle = true;
        }


    }

    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
        isIddle = true;
    }

    void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.CompareTag("Enemy") || otherCollision.gameObject.CompareTag("Arrow"))
        {
            if (playerHp > 0)
            {
                playerHp--;
                onUpdateHP?.Invoke(playerHp);
                if (playerHp == 0) {
                    onDeath?.Invoke();
                }
            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            GameObject newItem = other.gameObject;
            newItem.SetActive(false);
            inventory.addItemToInventory(newItem);
        }
    }

    private void UseItem()
    {
        GameObject item = inventory.GetInventory();
        item.SetActive(true);
        item.transform.position = transform.position + new Vector3(1f, 1f, 1f);
    }

    public int getPlayerHp()
    {
        return playerHp;
    }

}
