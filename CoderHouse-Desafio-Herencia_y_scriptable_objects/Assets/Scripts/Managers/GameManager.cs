using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject[] arrowGeneratorPrefab;

    bool disabledTraps;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void setActiveTraps(bool trapsState)
    {
        instance.disabledTraps = trapsState;
        for (int i = 0; i < arrowGeneratorPrefab.Length; i++)
        {
            arrowGeneratorPrefab[i].SetActive(disabledTraps);
        }
    }


}
