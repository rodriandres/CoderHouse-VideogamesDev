using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 orginalScale;
    public int comboHits = 0;
    bool gameNeedRestart = false;
    bool isCombo = false;
    float i;
    // Start is called before the first frame update
    void Start()
    {
        orginalScale = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ---------------- MY METHODS -------------------------------------------------------
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            comboHits += 1;
            isCombo = true;   
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            comboHits = 0;
            isCombo = false;    
        }

        if (isCombo)
        {
            IncreaseScale();
        }
        else
        {
            DecreaseScale();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            i += Time.deltaTime;
            if (i >= 5f)
            {
                gameNeedRestart = true;
                i = 0;
            }
        }    
    }

    private void IncreaseScale()
    {
        player.transform.localScale = player.transform.localScale + new Vector3(5 * Time.deltaTime, 5 * Time.deltaTime, 5 * Time.deltaTime);
        Debug.Log("Great Combo!");
    }

    private void DecreaseScale()
    {
        player.transform.localScale = orginalScale;
        Debug.Log("You loose your combos :c");
    }

    public bool GetGameState()
    {
        return gameNeedRestart;
    }

    public int GetCombo()
    {
        return comboHits;
    }

    
}
