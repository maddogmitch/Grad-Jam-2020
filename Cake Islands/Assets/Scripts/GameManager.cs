using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 0;
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exitDoor;

    int numOfSwitches = 0;

    [SerializeField]
    Text switchCount;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("level");
    }

    void Start()
    {
        GetNumOfSwitches();
    }

    public int GetNumOfSwitches()
    {
        int x = 0;

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<Interaction>().IsOn == false)
            {
                x++;
            }
            else if (switches[i].GetComponent<Interaction>().IsOn == true)
            {
                numOfSwitches--;
            }
        }

        numOfSwitches = x;

        return numOfSwitches;
    }

    public void nextLevel()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        if (level == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if(level == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (level == 4)
        {
            SceneManager.LoadScene("Level4");
        }
        else if (level == 5)
        {
            SceneManager.LoadScene("Level5");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void GetDoorState()
    {
        if(numOfSwitches <= 0)
        {
            exitDoor.GetComponent<Interaction>().Open();
        }
    }

    void Update()
    {
        switchCount.text = GetNumOfSwitches().ToString();

        GetDoorState();
    }
}
