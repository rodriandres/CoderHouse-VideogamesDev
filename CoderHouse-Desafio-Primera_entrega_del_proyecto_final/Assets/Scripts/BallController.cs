using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int comboHits = 0;
    bool gameHasEnded = false;
    bool isCombo = false;
    float i;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ---------------- MY METHODS -------------------------------------------------------
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger: " + other.gameObject.name);
        //Debug.Log("Update Combo: " + comboHits);
        if (contador < 1)
        {
            if (other.gameObject.tag == "Player"/* && !isCombo*/)
            {
                Debug.Log("Combo!: " + comboHits);
                comboHits ++;
                //isCombo = true;
                contador++;
            }
           /* else if(other.gameObject.layer == 7 && isCombo)
            {
                Debug.Log("Combo!: " + comboHits);
                comboHits++;
                contador++;
            }*/
            else if (other.gameObject.tag == "Floor"/* && !isCombo*/)
            {
                Debug.Log("You haven´t doing combos yet :c");
                comboHits = 0;
                //isCombo = false;
                contador++;
            }
            /*else if (other.gameObject.layer == 8 && isCombo)
            {
                Debug.Log("NO! You loose your combos :c");
                comboHits = 0;
                isCombo = false;
                contador++;
            }*/

        }
        else
        {
            contador = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            i += Time.deltaTime;
            if (i >= 5f)
            {
                gameHasEnded = true;
                i = 0;
            }
        }    
    }

    public bool GetGameState()
    {
        return gameHasEnded;
    }

    public int GetCombo()
    {
        return comboHits;
    }

    
}
