using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exitDoor;

    int numOfSwitches = 0;

    [SerializeField]
    Text switchCount;

    void Start()
    {
        GetNumOfSwitches();
    }

    public int GetNumOfSwitches()
    {
        int x = 0;
        
        for(int i =0; i < switches.Length; i++)
        {
            if(switches[i].GetComponent<Interaction>().IsOn == false)
            {
                x++;
            }
            else if(switches[i].GetComponent<Interaction>().IsOn == true)
            {
                numOfSwitches--;
            }
        }

        numOfSwitches = x;

        return numOfSwitches;
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
