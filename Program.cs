using System;
using System.Collections.Generic;

namespace GuessingGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a random integer from 1 to 100
            Random randomInt = new Random();
            int randomNumber = randomInt.Next(1, 101);
            int userGuess = -1; // Initialize userGuess to avoid CS0165
            // List of all guesses
            List<Guess> guesses = new List<Guess>();

            Console.WriteLine("Try to guess the number from 1 and 100!");

            do
            {
                Console.Write("Enter your guess: ");

                // Making userInput nullable to handle possible null values
                string? userInput = Console.ReadLine(); 
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number from 1 and 100.");
                    continue;
                }

                // Try-catch block to ensure the user input is an integer
                try
                {
                    userGuess = int.Parse(userInput);

                    // Ensure the guess is within the valid range (1 to 100)
                    if (userGuess < 1 || userGuess > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a number from 1 and 100.");
                        continue;
                    }

                    Guess newGuess = new Guess(userGuess);

                    // Checking to see if the guess was used before or not
                    bool isGuessFound = false;
                    for (int i = 0; i < guesses.Count; i++)
                    {
                        if (guesses[i].UserGuess == userGuess)
                        {
                            int turnsAgo = guesses.Count - i;
                            Console.WriteLine($"You already guessed this number {turnsAgo} turns ago!");
                            isGuessFound = true;
                            break;
                        }
                    }

                    if (!isGuessFound)
                    {
                        guesses.Add(newGuess);

                        if (userGuess < randomNumber)
                        {
                            Console.WriteLine("Your guess is to low! Try again.");
                        }
                        else if (userGuess > randomNumber)
                        {
                            Console.WriteLine("Your guess is to high! Try again.");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number from 1 and 100.");
                }
            } while (userGuess != randomNumber);

            Console.WriteLine($"You Won! The answer was {randomNumber}.");
        }
    }

    
}
