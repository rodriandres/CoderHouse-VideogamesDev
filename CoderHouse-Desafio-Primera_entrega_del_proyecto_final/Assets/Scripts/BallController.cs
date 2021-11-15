using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 orginalScale;
    public int comboHits = 0;
    bool gameHasEnded = false;
    bool isCombo = false;
    bool scaleModified = false;
    float i;
    // Start is called before the first frame update
    void Start()
    {
        orginalScale = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCombo)
        {
            Debug.Log(scaleModified);
            IncreaseScale();
        }
        else
        {
            Debug.Log(scaleModified);
            DecreaseScale();
        }
    }

    // ---------------- MY METHODS -------------------------------------------------------
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Combo!: " + comboHits);
            comboHits += 1;
            isCombo = true;   
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("NOO");
            comboHits = 0;
            isCombo = false;    
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            i += Time.deltaTime;
            if (i >= 5f)
            {
                gameHasEnded = true;
                i = 0;
            }
        }    
    }

    private void IncreaseScale()
    {
        player.transform.localScale = player.transform.localScale + new Vector3(1 * Time.deltaTime, 1 * Time.deltaTime, 1 * Time.deltaTime);
        Debug.Log("Great Combo!");
        scaleModified = false;
    }

    private void DecreaseScale()
    {
        player.transform.localScale = orginalScale;
        Debug.Log("You loose your combos :c");
        scaleModified = true;
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
