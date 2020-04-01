using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Member Variable
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What Would You Like To Hack Into??");
        Terminal.WriteLine("Press \"1\" For The Local Library");
        Terminal.WriteLine("Press \"2\" For The Police Station");
        Terminal.WriteLine("Press \"3\" For The Space Station");
        Terminal.WriteLine("Enter Your Selection");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                password = "Text";
                StartGame();
                break;
            case "2":
                level = 2;
                password = "Planet";
                StartGame();
                break;
            case "3":
                Terminal.WriteLine("You Have Chosen Level 3");
                break;
            case "menu":
                break;
            default:
                Terminal.WriteLine("Please Chose A Invalid Level");
                break;
        }
    }

     void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You Have Chosen");
        Terminal.WriteLine("Please Enter Your Password");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("You Win");
        }
        else
        {
            Terminal.WriteLine("Guess Again");
        }
    }
}
