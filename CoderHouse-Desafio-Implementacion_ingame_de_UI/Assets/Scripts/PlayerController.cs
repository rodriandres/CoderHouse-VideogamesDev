using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 3f;
    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private InventoryManager mgInventory;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        mgInventory = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementPlayer();

        if (Input.GetKeyUp(KeyCode.G))
        {
            UseItem();
        }
    }

    void MovementPlayer()
    {
        float horizontalaxis = Input.GetAxis("Horizontal");
        float verticalaxis = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime);
        rbPlayer.AddForce(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime, ForceMode.Impulse);


        //transform.position += transform.right * horizontalaxis * Time.deltaTime;
        //transform.position += transform.forward * verticalaxis * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            //Destroy(other.gameObject);
            GameObject point = other.gameObject;
            point.SetActive(false);
            mgInventory.AddInventoryOne(point);
            mgInventory.CountPoint(point);
            
        }
    }

    private void UseItem()
    {
        GameObject point = mgInventory.GetInventoryOne();
        point.SetActive(true);
        point.transform.position = transform.position + new Vector3(0.5f, 0.5f, 0.5f);

        
    }

}
