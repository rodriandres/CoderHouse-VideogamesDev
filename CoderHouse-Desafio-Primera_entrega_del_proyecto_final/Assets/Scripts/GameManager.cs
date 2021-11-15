using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private TextMesh comboText;
    bool gameHasEnded;
    int Score;
    Color color1;
    Color color2;

    

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ball = GameObject.FindGameObjectWithTag("Ball");

        ColorUtility.TryParseHtmlString("#00FF27", out color1);
        ColorUtility.TryParseHtmlString("#FF2100", out color2);
        comboText.color = color1;
    }

    // Update is called once per frame
    void Update()
    {
        gameHasEnded = ball.GetComponent<BallController>().GetGameState();
        if (!gameHasEnded)
        {
            comboCalculated();
        }
        else
        {
            Restart();
        }
        
    }

    void comboCalculated()
    {
        Score = ball.GetComponent<BallController>().GetCombo();
        if (Score > 0) {
            comboText.text = ("Combo: " + Score);
            comboText.color = color1;
        }
        else
        {
            comboText.text = ("Combo: " + Score);
            comboText.color = color2;
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene("level01");
        Debug.Log("Sorry, GAME OVER DUDE!");
    }
}
