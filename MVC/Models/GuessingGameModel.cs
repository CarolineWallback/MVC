using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Models
{
    public class GuessingGameModel
    {
        private Random random = new Random();
        private string Message { get; set; } = string.Empty;
        public bool CorrectGuess { get; set; } = false;

        public static int Counter { get; set; }

        public int counter
        {
            get { return Counter; }
        }
        
        public int SetSecretNumber()
        {
            Counter = 0;
            int secretNumber = random.Next(1, 101);
            return secretNumber;
        }

        public string UserGuessResult(int guess, int? secretNumber)
        {
            if(guess < 101 && guess > 0)
                Counter++;
            else
                Message = "That is not a valid guess";

            if (guess == secretNumber)
            {
                CorrectGuess = true;
                Message = $"Congratulations, you guessed right! The number was {secretNumber}";
            }
            else if (guess > secretNumber && guess < 101)
                Message = $"{guess} is too high.";
            else if (guess < secretNumber && guess > 0)
                Message = $"{guess} is too low.";
     

            return Message;
        }
    }
}
