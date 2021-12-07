using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLives;

    private PlayerController player;

    Color greenColor;
    Color redColor;

    private void Awake()
    {
        PlayerController.onUpdateHP += onModifyHpHandler;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Paladin").GetComponent<PlayerController>();
        PlayerController.onDeath += OnDeadHandler;

        ColorUtility.TryParseHtmlString("#00FF27", out greenColor);
        ColorUtility.TryParseHtmlString("#FF2100", out redColor);
        textLives.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.onUpdateHP += onModifyHpHandler;
    }

    private void onModifyHpHandler(int hp)
    {
        textLives.text = "Lives: " + hp;
    }
    private void OnDeadHandler()
    {
        textLives.color = redColor;
        textLives.text = "Game over";
    }

    public void setFinishGame()
    {
        int hp = player.getPlayerHp();
        if (hp > 0)
        {
            textLives.color = greenColor;
            textLives.text = "YOU WIN THE GAME";
            Debug.Log("Has ganado El juego");
        }
        
    }
}
