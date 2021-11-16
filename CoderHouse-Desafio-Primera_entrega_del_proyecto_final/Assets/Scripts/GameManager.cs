using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMesh timerText;
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private TextMesh comboText;

    int initialTime;
    float timeScale = -1f;
    float timeOfFramWithTimeScale = 1f;
    float timeOfFramWithTimeScalePaused = 1f;
    float timeOfFramWithTimeScaleInitial = 1f;
    float timeInSecondsToShow = 0f;
    float tiempo = 0.0f;
    bool gameHasEnded;

    bool gameNeedRestart;
    int Score;
    Color color1;
    Color color2;
    enum Pause { isPause = 1, notPause };
    [SerializeField] private Pause pause;


    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ball = GameObject.FindGameObjectWithTag("Ball");
        pause = Pause.notPause;

        timeOfFramWithTimeScaleInitial = timeScale;
        timeInSecondsToShow = initialTime;

        TimeUpdate(initialTime);


        ColorUtility.TryParseHtmlString("#00FF27", out color1);
        ColorUtility.TryParseHtmlString("#FF2100", out color2);
        comboText.color = color1;

        InitialiteTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseTheGame();
        }

        gameNeedRestart = ball.GetComponent<BallController>().GetGameState();
        if (!gameNeedRestart)
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

    void TimeUpdate(float timeInSeconds)
    {
        int min = 0;
        int seconds = 0;
        string textOfTimer;

        if (timeInSeconds < 0)
        {
            timeInSeconds = 0;
        }

        min = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        textOfTimer = min.ToString("00") + ":" + seconds.ToString("00");

        timerText.text = textOfTimer;

    }

    void InitialiteTimer()
    {

    }

    void PauseTheGame()
    {
        switch (pause)
        {
            case Pause.isPause:
                Time.timeScale = 1;
                pause = Pause.notPause;
                break;
            case Pause.notPause:
                Time.timeScale = 0;
                pause = Pause.isPause;
                break;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("level01");
        Debug.Log("Sorry, GAME OVER DUDE!");
    }
}
