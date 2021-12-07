using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;
    [SerializeField] private string playerName;
    // Start is called before the first frame update

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string newName)
    {
        instance.playerName = newName;
        Debug.Log("Se cambio el nombre de usuario a: " + newName);
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
