using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    
    private Stack inventoryOne;

    [SerializeField] private int[] pointQuantity = { 0, 0, 0 };


    // Start is called before the first frame update
    void Start()
    {
        inventoryOne = new Stack();
    }

    public int [] GetPointQuantity()
    {
        return pointQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryOne(GameObject item)
    {
        inventoryOne.Push(item);
    }

    public GameObject GetInventoryOne()
    {
        return inventoryOne.Pop() as GameObject;
    }

    public void CountPoint (GameObject point)
    {
        CoinController p = point.GetComponent<CoinController>();


        switch (p.GetTypesPoints())
        {
            case GameManager.typesPoints.Yellow:
                pointQuantity[0]++;
                break;
            case GameManager.typesPoints.Red:
                pointQuantity[1]++;
                break;
            default:
                Debug.Log("No se puede contar");
                break;
        }
    }

}
