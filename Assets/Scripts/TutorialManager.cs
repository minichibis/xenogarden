using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private Manager manager;
    public GameObject[] popUps;
    private int popUpIndex;
    public bool tutorialActive;

    private void Start()
    {
        tutorialActive = true;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0 || popUpIndex == 2 || popUpIndex == 3 || popUpIndex == 5 || popUpIndex == 6 || popUpIndex == 7 || popUpIndex == 9)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (manager.resources[3] >= 15)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }
    }
}
