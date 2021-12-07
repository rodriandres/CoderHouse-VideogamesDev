using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    [SerializeField] private InputField inputPlayerName;
    [SerializeField] private GameObject panelPlayerName;
    [SerializeField] private Button playButton;
    [SerializeField] private Toggle toggleShowPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        toggleShowPlayerName.enabled = false;
        playButton.enabled = false;
        panelPlayerName.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangePanelPlayerName();
    }

    public void OnEditInputPlayerName()
    {
        if (inputPlayerName.text == null || inputPlayerName.text == "")
        {
            Debug.LogError("ERROR: nombre de usuario no disponible");
        }
        else
        {
            ProfileManager.instance.SetPlayerName(inputPlayerName.text);
            Debug.Log("Nuevo nombre de usuario: " + ProfileManager.instance.GetPlayerName());
            toggleShowPlayerName.enabled = true;
            playButton.enabled = true;
        }
        
    }

    public void OnChangeToggleShowName(bool showNameState)
    {
        if (ProfileManager.instance.GetPlayerName() == null || ProfileManager.instance.GetPlayerName() == "")
        {
            Debug.LogError("ERROR: nombre de usuario no disponible");
        }
        else
        {
            panelPlayerName.SetActive(showNameState);
        }
        
    }

    public void ChangePanelPlayerName()
    {
        panelPlayerName.GetComponentInChildren<Text>().text = "Player: " + ProfileManager.instance.GetPlayerName();
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("Level01");
    }
    public void onScenaChange()
    {
        Debug.Log("Congratulations you win level one! Here is the neext level");
        SceneManager.LoadScene("Level02");
    }
}
