using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryController : MonoBehaviour
{
    private Stack inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Stack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItemToInventory(GameObject item)
    {
        inventory.Push(item);
    }

    public GameObject GetInventory()
    {
        return inventory.Pop() as GameObject;
    }

}
