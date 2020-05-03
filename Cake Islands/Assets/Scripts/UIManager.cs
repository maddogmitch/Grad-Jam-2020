using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Turns it into an instance
    private static UIManager instance = null;
    public static UIManager inst { get { return instance; } }

    public GameObject SettingsPanel;
    public GameObject CreditsPanel;
    public GameObject StartPanel;
    public GameObject StartButton;
    public GameManager gm;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }

    public void LoadPanel(GameObject panel)
    {
        ClosePanel();
        panel.SetActive(true);
        StartPanel.SetActive(false);
    }

    public void ClosePanel()
    {
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void StartGame()
    {
        gm.nextLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
