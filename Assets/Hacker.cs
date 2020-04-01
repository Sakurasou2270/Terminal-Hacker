using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Member Variable
    int level;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What Would You Like To Hack Into??");
        Terminal.WriteLine("Press \"1\" For The Local Library");
        Terminal.WriteLine("Press \"2\" For The Police Station");
        Terminal.WriteLine("Press \"3\" For The Space Station");
        Terminal.WriteLine("Enter Your Selection");
    }

    void OnUserInput(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                StartGame(level);
                break;
            case "2":
                level = 2;
                StartGame(level);
                break;
            case "3":
                Terminal.WriteLine("You Have Chosen Level 3");
                break;
            case "main":
                ShowMainMenu();
                break;
            default:
                Terminal.WriteLine("Please Chose A Invalid Level");

                break;
        }
    }

    private void StartGame(int Level)
    {
        Terminal.WriteLine("You Have Chosen " + Level);
    }
}
