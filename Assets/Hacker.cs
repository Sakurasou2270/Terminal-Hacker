using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Member Variable
    // Game Configurations
    const string menuHint = "You Can Type \"menu\" To Go Back";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game State
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please Chose A Invalid Level");
            Terminal.WriteLine(menuHint);
        }
    }

     void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter Your Password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You Have Crazy Knowledge!");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\
 //________.|.________\\
`----------`-'----------'
                ");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("You Have Broken In!");
                Terminal.WriteLine(@"
  _ __   ___ | (_) ___ ___ 
 | '_ \ / _ \| | |/ __/ _ \
 | |_) | (_) | | | (_|  __/
 | .__/ \___/|_|_|\___\___|
 |_|                       

                ");
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine("Your A Rocket Scientist!");
                Terminal.WriteLine(@"
   __
   \ \_____
###[==_____>
   /_/

                ");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Error Level Not Included");
                break;
        }
    }
}
