using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 0;

    [SerializeField]
    GameObject exitDoor;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("level");
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

  
}
