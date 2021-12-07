using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        PlayerController.onDeath += GameOver; ;
    }


    private void GameOver()
    {
        Debug.Log("GM: El juego termino");
    }

    public void onScenaChange()
    {
        Debug.Log("Congratulations you win level one! Here is the neext level");
        SceneManager.LoadScene("Level02");
    }

}
