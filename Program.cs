using game.Utilities;

while (true) {
    DisplayWelcomeMessage();
    Utility.PrintCommandMessage("Please select difficulty level: ");

    Utility.PrintNumberMessage("1. Easy (10 chances)");
    Utility.PrintNumberMessage("2. Medium (5 chances)");
    Utility.PrintNumberMessage("3. Hard (3 chances)");

    while (true) {
        Random randamu = new Random();
        int answer = randamu.Next(1, 101);

        Console.WriteLine("\nEnter your difficulty level: ");
        string? level = Console.ReadLine();
        int chances = 0;

        if (level == "quit")
            break;
        if (!int.TryParse(level, out int levelAsInt)) {
            Utility.PrintErrorMessage("Wrong input detected. Please enter difficulty level from 1 to 3.");
            continue;
        }

        string levelSelected = whatLevelSelected(level);

        if (levelSelected != null && !string.IsNullOrEmpty(levelSelected)) {
            chances = chancesGot(levelSelected);
            Utility.PrintInfoMessage($"You selected {levelSelected} mode with {chances} chances to guess the number.");
            Utility.PrintErrorMessage("Good luck :)");
            Task.Delay(5000).Wait();
            Console.Clear();
        } else {
            Utility.PrintErrorMessage("Wrong input detected. Please enter difficulty level from 1 to 3.");
            continue;
        }

        Utility.PrintNumberMessage("Let's start the game.");
        Utility.PrintInfoMessage("The number is between 1 and 100.");

        int tries = 0;
        bool kattaka = false;

        while (tries < chances) {
            int nokoruTyansu = chances - tries;
            string nanbanme = imaNanbanme(tries + 1);

            Utility.PrintCommandMessage($"\nChances left: {nokoruTyansu}");
            Console.WriteLine($"\nPlease enter your {nanbanme} guess: ");

            string? guess = Console.ReadLine();

            if (guess == "quit") {
                kattaka = true;
                break;
            }
                
            if (!int.TryParse(guess, out int guessAsInt)) {
                Utility.PrintErrorMessage("Wrong input detected. Please enter a valid number.");
                continue;
            }

            Console.Clear();

            if (guessAsInt == answer) {
                Utility.PrintCongratulatoryMessage("**************************************");
                Utility.PrintCongratulatoryMessage("*                                    *");
                Utility.PrintCongratulatoryMessage("*          CONGRATULATIONS           *");
                Utility.PrintCongratulatoryMessage("*    You guessed the right number!   *");
                Utility.PrintCongratulatoryMessage("*                                    *");
                Utility.PrintCongratulatoryMessage("**************************************");
                kattaka = true;
                break;
            } else 
                matigattaBai(guessAsInt, answer);

            tries++;
        }

        if (!kattaka)
            gameoverBai(answer);
 
        break;
    }
    
    break;
}


#region helper methods

void DisplayWelcomeMessage() {
    Utility.PrintInfoMessage("Welcome to the Number Guessing Game!");
}

string whatLevelSelected(string m) {
    switch (m) {
        case "1":
            return "Easy";
        case "2":
            return "Medium";
        case "3":
            return "Hard";
        default:
            return string.Empty;
    }
}

int chancesGot(string m) {
    switch (m) {
        case "Easy":
            return 10;
        case "Medium":
            return 5;
        case "Hard":
            return 3;
        default:
            return 0;
    }
}

static string imaNanbanme(int i) {
    switch (i) {
        case 1:
            return "First";
        case 2:
            return "Second";
        case 3:
            return "Third";
        case 4:
            return "Fourth";
        case 5:
            return "Fifth";
        case 6:
            return "Sixth";
        case 7:
            return "Seventh";
        case 8:
            return "Eighth";
        case 9:
            return "Ninth";
        case 10:
            return "Tenth";
        default:
            return "Number out of range (1-10)";
    }
}

void matigattaBai(int i, int answer) {
    if (i < answer) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*             WRONG ANSWER             *");
        Console.WriteLine("*           Please try again           *");
        Console.WriteLine($"*  Hint: The number is greater than {i} *");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
    }

    if (i > answer) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*             WRONG ANSWER             *");
        Console.WriteLine("*           Please try again           *");
        Console.WriteLine($"*  Hint: The number is smaller than {i} *");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
    }
}

void gameoverBai(int answer) {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("****************************************");
    Console.WriteLine("*                                      *");
    Console.WriteLine("*             GAME OVER!               *");
    Console.WriteLine("*                                      *");
    Console.WriteLine("*      You've run out of chances.      *");
    Console.WriteLine($"*      The correct number was {answer}.      *");
    Console.WriteLine("*                                      *");
    Console.WriteLine("*                                      *");
    Console.WriteLine("****************************************");
    Console.ResetColor();
}
#endregion