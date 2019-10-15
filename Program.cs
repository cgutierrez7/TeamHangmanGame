using System;
using System.Linq;

namespace HangmanProject
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Non-Player please enter a word: ");
            string userIn = Console.ReadLine();
            char[] array = userIn.ToCharArray();
            char[] resultArray = new char[array.Length]; // making a new array with the same size as the words
            Console.Clear();

            Display display = new Display();

            // this was inspired by https://www.sanfoundry.com/csharp-programs-gaming-hangman/

            while (true) // loops until win or loss condition is met
            {
                Console.Write($"Please enter a letter:\t\t"); //Changed this to Write from WriteLine
                display.UpdateBlanks(resultArray);
                Console.WriteLine();
                Console.Write("\t\t\t\t");
                display.AllPlayerGuesses();

                if (!char.TryParse(Console.ReadLine(), out char playerGuess)) // makes the player reenter a char if it doesn't parse to a char
                {
                    Console.WriteLine("\n");
                    Console.Clear();
                }
                else
                {
                    for (int j = 0; j < array.Length; j++) // checks user input against the mystery word
                    {
                        if (playerGuess == array[j]) // sets the corresponding array space to the letter if they match
                        {
                            resultArray[j] = playerGuess;
                        }
                    }
                    display.UpdateBlanks(resultArray);
                    display.AllPlayerGuesses(playerGuess);

                    if (array.SequenceEqual(resultArray))
                    {
                        Console.Clear();
                        display.UpdateBlanks(resultArray);
                        display.AllPlayerGuesses(playerGuess);
                        Console.ReadLine();
                        break;
                    }
                    Console.Clear();
                }
            }
        }
    }

    class Display
    {
        string PlayerGuesses = "";
        //Displays Previous Guesses
        public void AllPlayerGuesses()
        {
            Console.Write("Your Guesses: " + PlayerGuesses);
        }
        //Updates Previous Guesses
        public void AllPlayerGuesses(char playerGuess)
        {
            PlayerGuesses += playerGuess + " ";
            Console.Write("Your Guesses: " + playerGuess);
        }
        //Reads and displays resultArray with correctly guessed letters
        public void UpdateBlanks(char[] resultArray)
        {
            foreach (char letter in resultArray)
            {
                if (letter == '\0') //If array index is default char value
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write(letter + " "); //Place letter in position of correctly guess letter
                }
            }
        }

        public void DisplayHangman(int incorrectGuesses)
        {
            switch (incorrectGuesses)
            {
                case 0:
                    break;

                case 1:
                    displayHanger();
                    break;

                case 2:
                    displayHanger();
                    displayHead();
                    break;

                case 3:
                    displayHanger();
                    displayHead();
                    displayBody();
                    break;

                case 4:
                    displayHanger();
                    displayHead();
                    displayBody();
                    displayLeftArm();
                    break;

                case 5:
                    displayHanger();
                    displayHead();
                    displayBody();
                    displayLeftArm();
                    displayRightArm();
                    break;

                case 6:
                    displayHanger();
                    displayHead();
                    displayBody();
                    displayLeftArm();
                    displayRightArm();
                    displayLeftLeg();
                    break;

                case 7:
                    displayHanger();
                    displayHead();
                    displayBody();
                    displayLeftArm();
                    displayRightArm();
                    displayLeftLeg();
                    displayRightLeg();
                    break;
            }
        }

        public void displayHanger()
        {
            WriteAt("O", 1, 3);
            WriteAt("O", 1, 4);
            WriteAt("O", 1, 5);
            WriteAt("O", 1, 6);
            WriteAt("O", 1, 7);
            WriteAt("O", 1, 8);
            WriteAt("O", 1, 9);
            WriteAt("O", 1, 10);
            WriteAt("O", 1, 11);
            WriteAt("O", 1, 12);
            WriteAt("O", 1, 13);
            WriteAt("O", 1, 14);
            WriteAt("O", 1, 15);
            WriteAt("O", 1, 16);
            WriteAt("O", 1, 17);
            WriteAt("O", 1, 18);
            WriteAt("O", 1, 19);
            WriteAt("O", 1, 20);
            WriteAt("O", 1, 21);
            WriteAt("O", 1, 22);
            WriteAt("O", 1, 23);
            WriteAt("O", 1, 24);
            WriteAt("O", 1, 25);
            WriteAt("O", 1, 26);
            //base
            WriteAt("O", 0, 26);
            WriteAt("O", 2, 26);
            //top thingy
            WriteAt("O", 2, 3);
            WriteAt("O", 3, 3);
            WriteAt("O", 4, 3);
            WriteAt("O", 5, 3);
            WriteAt("O", 6, 3);
            WriteAt("O", 6, 3);
        }

        public void displayHead()
        {
            WriteAt("O", 5, 4);
            WriteAt("O", 5, 5);
            WriteAt("O", 5, 6);
            WriteAt("O", 6, 4);
            WriteAt("O", 6, 5);
            WriteAt("O", 6, 6);
            WriteAt("O", 7, 4);
            WriteAt("O", 7, 5);
            WriteAt("O", 7, 6);
        }

        public void displayBody()
        {
            WriteAt("O", 6, 7);
            WriteAt("O", 6, 8);
            WriteAt("O", 6, 9);
            WriteAt("O", 6, 10);
            WriteAt("O", 6, 11);
            WriteAt("O", 6, 12);
            WriteAt("O", 6, 13);
            WriteAt("O", 6, 14);
            WriteAt("O", 6, 15);
            WriteAt("O", 6, 16);
        }

        public void displayLeftArm()
        {
            WriteAt("O", 5, 10);
            WriteAt("O", 4, 10);

        }

        public void displayRightArm()
        {
            WriteAt("O", 7, 10);
            WriteAt("O", 8, 10);
        }

        public void displayLeftLeg()
        {
            WriteAt("O", 5, 17);
            WriteAt("O", 5, 18);
            WriteAt("O", 5, 19);
            WriteAt("O", 5, 20);
        }

        public void displayRightLeg()
        {
            WriteAt("O", 7, 17);
            WriteAt("O", 7, 18);
            WriteAt("O", 7, 19);
            WriteAt("O", 7, 20);
        }

        protected static int origRow;
        protected static int origCol;

        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }

    class BooleanWin
    {
        public static void WinOrLose(char[] secretWord, char[] guessedLetters)
        {
            if (secretWord == guessedLetters)
            {
                Console.WriteLine("WIN");
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }
    }
}
