using System.Timers;

namespace OutGuess
{
    internal class Program
    {
        static void Main(string[] args) {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OutGuess");
            Console.WriteLine("Rules: You Have Up To 10 Tries to Guess the Number That's In The Range Of 1 - 100. Let's Play!!");
            Console.ResetColor();

            Console.WriteLine("------------------");

            //Variables & Input  

            double cashBalance     = 0;
            double cashDifference  = 0;
            double cashIn          = InputDouble("Please the Cash Amount You Want In The Game: $");
            double userTries       = InputDouble("Please Enter How Many Tries You Would Like To Use (MAX. Up To 10):");
            double wager           = InputDouble("Please Enter The Amount You Want To Wager But It Can Not Be More Than You're Cash In Amount: ");
            double winnings        = 0;
            double wagerMultiplier = Multiplier(userTries);
            double winCount        = 0;
            double playCount       = 0;
            double winPercentage   = 0;

            if (userTries > 10 || wager > cashIn) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Either Have Too Many Tries Enter Or You are Over Your Cash In Amount. Please Try Again.");
                Console.ResetColor();
                Console.WriteLine("-------------");
                userTries = InputInt("Please Enter How Many Tries You Would Like To Use (MAX. Up To 10):");
                wager = InputInt("Please Enter The Amount You Want To Wager But It Can Not Be More Than You're Cash In Amount: ");

            }//end if 

            
            int number       = 0;
            Random randNum   = new Random();
            number           = randNum.Next(1, 101);
            double maxTries  = userTries;
            int userNumber   = InputInt("Please Enter A Number From The Range Of 1 - 100: ");
            bool playAgain   = false;

           

            for (maxTries = userTries - 1 ; maxTries >= 1; maxTries--) {

                
                
              if (userNumber > number) {

                    
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"The Number Entered Was Too High. You Have {maxTries} Tries Remaining.");
                    Console.ResetColor();
                    userNumber = InputInt("Please Enter A Number From The Range Of 1 - 100: ");
                   
              }else if (userNumber < number) {
                    
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"The Number Entered Was Too Low. You Have {maxTries} Tries Remaining.");
                    Console.ResetColor();
                    userNumber = InputInt("Please Enter A Number From The Range Of 1 - 100: ");
              
              }//end if



            }//end for

            

            if (userNumber == number)
            {

                cashDifference = cashIn - wager;
                winnings = wager * Multiplier(userTries);
                cashBalance = winnings + cashDifference;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"CONGRATULATIONS!! YOU WON THE GAMES!! You're Winnings For This Games Is {winnings:C}.");
                Console.WriteLine($"Your New Cash Balance is {cashBalance:C}");
                Console.ResetColor();
                maxTries = 0;

                playCount++;
                winCount++;




                playAgain = Input($"You Have {cashBalance:C} Remaining. Would You Like To Play Again? (y/n):").ToUpper() == "Y";

                if (playAgain == false)
                {
                    winPercentage = winCount / playCount;
                    Console.WriteLine($"Thank You For Playing! You're Win Percentage Is {winPercentage:P}. You're Cash Balance Is {cashBalance:C}.");


                }//end if


            }else if (maxTries == 0)
            {

                cashBalance = cashIn - wager;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Sorry, You Ran Out Of Tries. The Correct Number Was {number}.");
                Console.WriteLine($"The Wager Has Been Forfeited. You Now Have {cashBalance:C} Left. ");
                Console.ResetColor();
                playCount++;

                if (cashBalance <= 0)
                {

                    winPercentage = winCount / playCount;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Sorry, You're Out Of Money. Game Over!");
                    Console.ResetColor();

                }
                else
                {

                    playAgain = Input($"You Have {cashBalance:C} Remaining. Would You Like To Play Again? (y/n):").ToUpper() == "Y";

                    if (playAgain == false)
                    {
                        Console.WriteLine("---------------------------------");
                        winPercentage = winCount / playCount;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Thank You For Playing! You're Win Percentage Is {winPercentage:P}. You're Cash Balance Is {cashBalance:C}.");
                        Console.ResetColor();
                    }//end if



                }//end if

            }//end if







            while (playAgain && cashBalance > 0)
            {

                userTries = InputInt("Please Enter How Many Tries You Would Like To Use (MAX. Up To 10):");
                wager = InputInt("Please Enter The Amount You Want To Wager But It Can Not Be More Than You're Cash In Amount: ");


                if (userTries > 10 || wager > cashBalance)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Either Have Too Many Tries Enter Or You are Over Your Cash In Amount. Please Try Again.");
                    Console.ResetColor();
                    Console.WriteLine("------------");
                    userTries = InputInt("Please Enter How Many Tries You Would Like To Use (MAX. Up To 10):");
                    wager = InputInt("Please Enter The Amount You Want To Wager But It Can Not Be More Than You're Cash In Amount: ");

                }//end if

                userNumber = InputInt("Please Enter A Number From The Range Of 1 - 100: ");

                for (maxTries = userTries - 1; maxTries >= 1; maxTries--)
                {


                    if (userNumber > number)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The Number Entered Was Too High. You Have {maxTries} Tries Remaining.");
                        Console.ResetColor();
                        userNumber = InputInt("Please Enter A Number From The Range Of 1 - 100: ");

                    }
                    else if (userNumber < number)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The Number Entered Was Too Low. You Have {maxTries} Tries Remaining.");
                        Console.ResetColor();
                        userNumber = InputInt("Please Enter A Number From The Range Of 1 - 100: ");

                    }
                    

                }//end for

               


                if (userNumber == number)
                {

                    cashDifference = cashBalance - wager;
                    winnings = wager * Multiplier(userTries);
                    cashBalance = winnings + cashDifference;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"CONGRATULATIONS!! YOU WON THE GAMES!! You're Winnings For This Games Is {winnings:C}.");
                    Console.WriteLine($"Your New Cash Balance is {cashBalance:C}");
                    Console.ResetColor();
                    maxTries = 0;

                    playCount++;
                    winCount++;




                    playAgain = Input($"You Have {cashBalance:C} Remaining. Would You Like To Play Again? (y/n):").ToUpper() == "Y";

                    if (playAgain == false)
                    {

                        winPercentage = winCount / playCount;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Thank You For Playing! You're Win Percentage Is {winPercentage:P}. You're Cash Balance Is {cashBalance:C}.");
                        Console.ResetColor();

                    }//end if

                }else if (maxTries == 0) {

                    cashBalance = cashBalance - wager;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry, You Ran Out Of Tries. The Correct Number Was {number}.");
                    Console.WriteLine($"The Wager Has Been Forfeited. You Now Have {cashBalance:C} Left. ");
                    Console.ResetColor();
                    playCount++;

                    if (cashBalance <= 0)
                    {

                        winPercentage = winCount / playCount;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Sorry, You're Out Of Money. Game Over!");
                        Console.ResetColor();

                    }
                    else
                    {

                        playAgain = Input($"You Have {cashBalance:C} Remaining. Would You Like To Play Again? (y/n):").ToUpper() == "Y";

                        if (playAgain == false)
                        {
                            Console.WriteLine("---------------------------------");
                            winPercentage = winCount / playCount;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Thank You For Playing! You're Win Percentage Is {winPercentage:P}. You're Cash Balance Is {cashBalance:C}.");
                            Console.ResetColor();
                        }//end if



                    }//end if

                }//end if 



            }//end while
                

        

               
  
        }//end main

        static double Multiplier(double number) {

            double multiplier = 0;

            multiplier = 11 - number;

            return multiplier;
        
        }//end function


          #region HELPER FUNCTIONS
        static string Input(string message)
        {

            Console.Write(message);
            string value = Console.ReadLine();
            return value;

        }//end function

        static decimal InputDecimal(string message)
        {
            string value = Input(message);
            return decimal.Parse(value);
        }//end function

        static double InputDouble(string message)
        {
            string value = Input(message);
            return double.Parse(value);
        }//end function

        static int InputInt(string message)
        {
            string value = Input(message);
            return int.Parse(value);
        }//end function
        #endregion

    }//end class


}//end namespace