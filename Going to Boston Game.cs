using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Myles Leslie - 15614035
// Going To Boston Dice Game

namespace assessment3
{
    //the game class which holds the main menu
    class Game
    {
        static void Main(string[] args)
        {
            //variables for choosing a gamemode/ menu
            string response;
            string choice;
            bool Gamemode = false;
            //do while loop for navigating the menus 
            do
            {
                while (Gamemode == false)
                {
                    //choosing between the different modes and rules
                    Console.WriteLine("The Going to Boston Dice Game");
                    Console.WriteLine();
                    Console.WriteLine("Press 1 for 'Match' play\nPress 2 for 'Score' play \nPress 3 for Againest the Computer \nPress 4 for Rules");
                    choice = Console.ReadLine();

                    //switch statement to make a choice
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Begin match play!");
                            Gamemode = true;
                            Die.MatchPlay(false);
                            break;
                        case "2":
                            Console.WriteLine("Begin score play!");
                            Gamemode = true;
                            Die.ScorePlay(false);
                            break;
                        case "3":
                            Console.WriteLine("Begin playing with the computer!");
                            Die.ComputerPlay();
                            Gamemode = true;
                            break;
                        case "4":
                            Console.WriteLine();
                            Console.WriteLine("Rules");
                            Console.WriteLine("Roll the three dice and take the highest number from each roll.\nEach time you roll you lose a die.\nSo the first roll is going to be with three dice, the second with two, and the third with a single die. \nTotal up the three dice, the player with the highest value wins that round. ");
                            Console.WriteLine();
                            Console.WriteLine("Match Play -  Players win a point each round. The first to 5 wins the game.");
                            Console.WriteLine();
                            Console.WriteLine("Score Play -  Players add up their total after each round. \nThe player with the highest score after 5 rounds wins the game. ");
                            Console.WriteLine();

                            break;
                        default:
                            Console.WriteLine("Please Enter a valid input");
                            Console.WriteLine();
                            break;
                    }
                }
                //once the game ends, lets the player choose to play again and brings them back to the menu
                Console.WriteLine("Would you like to play again? Y/N");
                response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    Gamemode = false;
                }
            } while (response == "Y");
            //if the response is no the program closes
        }
    }
    //the dice and game mode class
    class Die
    {
        //Match play gamemode including the ability to play againest the computer
        public static void MatchPlay(bool iscomputer)
        {
            //declaring dice and player variables for the mode
            Random rnd = new Random();
            Player Player1 = new Player();
            Player Player2 = new Player();
            int randomnum;
            int maxnum = 0;
            int a = 3;
            int c = 3;
            int e = 1;
            string rival;

            //if the computer gamemode is chosen, match play changes to be just 1 player againest the AI
            if (iscomputer == true)
            {
                rival = "Computer";
            }
            else
            {
                rival = "Player 2";
            }

            //while loop for match play so that it ends once someone reaches 5 wins
            //also connects the player 1 and 2 to the wins of the player class
            while (Player1.Wins < 5 && Player2.Wins < 5)
            {
                //beginning of a new round
                Console.WriteLine("------------- Round " + e + " -------------");
                //for loop to make sure the player takes three turns per round
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Player 1");
                    //for loop for the dice to roll random numbers, find the max number of each roll and add it to the overall player total
                    for (int b = 0; b < c; b++)
                    {
                        randomnum = rnd.Next(1, 7);
                        Console.WriteLine(a + " Die:" + randomnum);
                        if (randomnum > maxnum)
                            maxnum = randomnum;
                        a--;
                    }
                    //counts down the dice, the dice display number, adds to the players total and resets the max roll after player 1's turn
                    c--;
                    a = c;
                    Player1.Score += maxnum;
                    maxnum = 0;

                    Console.WriteLine("Press Enter For the Next Roll");
                    Console.ReadLine();
                }
                //displays the total of the three highest dice that player 1 rolls
                Console.WriteLine("Total for Player 1:" + Player1.Score);
                Console.ReadLine();

                //reset the variables values
                a = 3;
                c = 3;

                //for loop to make sure the player or AI takes three turns per round
                for (int i = 0; i < 3; i++)
                {
                    //for loop for the dice to roll random numbers, find the max number of each roll and add it to the overall player or AI's total
                    Console.WriteLine(rival);
                    for (int b = 0; b < c; b++)
                    {
                        randomnum = rnd.Next(1, 7);
                        Console.WriteLine(a + " Die:" + randomnum);
                        if (randomnum > maxnum)
                            maxnum = randomnum;
                        a--;
                    }
                    //counts down the dice, the dice display number, adds to the players total and resets the max roll after player 2 or the AI's turn
                    c--;
                    a = c;
                    Player2.Score += maxnum;
                    maxnum = 0;

                    //allows the second player to continue or if it's an AI playing it automatically continues
                    if (iscomputer == false)
                    {
                        Console.WriteLine("Press Enter For the Next Roll");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
                //displays the total of the three highest dice that player 2 or the AI's rolls
                Console.WriteLine("Total for " + rival + ": " + Player2.Score);
                Console.ReadLine();

                //compares both of the players scores and gives a win to one of the players total wins
                //player 1 wins
                if (Player1.Score > Player2.Score)
                {
                    Console.WriteLine("Player 1 Wins This Round");
                    Player1.Wins++;
                }
                //player 2 wins
                else if (Player2.Score > Player1.Score)
                {
                    Console.WriteLine(rival + " Wins This Round");
                    Player2.Wins++;
                }
                //nobody scores a point this round
                else if (Player1.Score == Player2.Score)
                {
                    Console.WriteLine("Draw, Everybody Loses!");
                }

                //displays the total number of wins for both players
                Console.WriteLine("Player 1 Win(s): " + Player1.Wins);
                Console.WriteLine(rival + " Win(s): " + Player2.Wins);
                Console.ReadLine();

                //resets the dice and score variables
                Player1.Score = 0;
                Player2.Score = 0;
                a = 3;
                c = 3;

                e++;
            }

            //displays which player or AI wins the overall game 
            if (Player1.Wins > Player2.Wins)
            {
                Console.WriteLine("Player 1 Wins");
            }
            else if (Player2.Wins > Player1.Wins)
            {
                Console.WriteLine(rival + " Wins");
            }
            Console.ReadLine();
        }

        //start of the Score play gamemode which allows for an AI player
        public static void ScorePlay(bool iscomputer)
        {
            //declaring dice and player variables for the mode
            Random rnd = new Random();
            Player Player1 = new Player();
            Player Player2 = new Player();
            int randomnum;
            int maxnum = 0;
            int a = 3;
            int c = 3;
            string rival;

            //if the computer gamemode is chosen, match play changes to be just 1 player againest the AI
            if (iscomputer == true)
            {
                rival = "Computer";
            }
            else
            {
                rival = "Player 2";
            }

            //for loop that loops the game to 5 rounds
            for (int d = 1; d < 6; d++)
            {
                //displays rounds and a for loop for the player rolling the dice 3 times a round
                Console.WriteLine("------------- Round " + d + " -------------");
                for (int i = 0; i < 3; i++)
                {
                    //displays player 1 and a for loop for the dice to roll random numbers, find the max number of each roll and add it to the overall player total
                    Console.WriteLine("Player 1");
                    for (int b = 0; b < c; b++)
                    {
                        randomnum = rnd.Next(1, 7);
                        Console.WriteLine(a + " Die:" + randomnum);
                        if (randomnum > maxnum)
                            maxnum = randomnum;
                        a--;
                    }
                    //counts down the dice, the dice display number, adds to the players total and resets the max roll after player 1's turn
                    c--;
                    a = c;
                    Player1.Score += maxnum;
                    maxnum = 0;

                    Console.WriteLine("Press Enter For the Next Roll");
                    Console.ReadLine();
                }
                //displays the total of all the highest dice for player 1
                Console.WriteLine("Total for Player 1:" + Player1.Score);
                Console.ReadLine();

                //resets dice variables
                a = 3;
                c = 3;

                //for loop for the player or AI rolling the dice 3 times a round
                for (int i = 0; i < 3; i++)
                {
                    //displays player 2 or the AI and a for loop for the dice to roll random numbers, find the max number of each roll and add it to the overall player total
                    Console.WriteLine(rival);
                    for (int b = 0; b < c; b++)
                    {
                        randomnum = rnd.Next(1, 7);
                        Console.WriteLine(a + " Die:" + randomnum);
                        if (randomnum > maxnum)
                            maxnum = randomnum;
                        a--;
                    }
                    //counts down the dice, the dice display number, adds to the players total and resets the max roll after player 2's or the AI's turn
                    c--;
                    a = c;
                    Player2.Score += maxnum;
                    maxnum = 0;

                    //allows the player to contine or if it's an AI continue automatically
                    if (iscomputer == false)
                    {
                        Console.WriteLine("Press Enter For the Next Roll");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
                //displays the total of the highest dice for player 2 or the AI
                Console.WriteLine("Total for " + rival + ":" + Player2.Score);
                Console.ReadLine();

                //resets dice variables
                a = 3;
                c = 3;
            }

            //shows the current number of points that the players or AI have after each round and at the end of the game
            Console.WriteLine("Player 1 Points: " + Player1.Score);
            Console.WriteLine(rival + " Points: " + Player2.Score);
            Console.WriteLine();

            //compares both of the players scores and gives a win to one of the players total wins
            //player 1 wins
            if (Player1.Score > Player2.Score)
            {
                Console.WriteLine("Player 1 Wins");
            }
            //player 2 or AI wins
            else if (Player2.Score > Player1.Score)
            {
                Console.WriteLine(rival + " Wins");
            }
            //nobody wins the mode
            else if (Player1.Score == Player2.Score)
            {
                Console.WriteLine("Draw, Everybody Loses!");
            }
            Console.ReadLine();
        }

        //holds the functions to allow AI play
        public static void ComputerPlay()
        {
            //declares variables for AI
            string choice;
            bool Gamemode = false;
            bool iscomputer = true;

            //while loop for if the computer play is chosen in the main menu
            while (Gamemode == false)
            {
                //choosing between the two AI game modes
                Console.WriteLine("Press 1 for 'Match' play or 2 for 'Score' play");
                choice = Console.ReadLine();

                //switch statement to choose between the two game modes
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Begin match play!");
                        Gamemode = true;
                        Die.MatchPlay(iscomputer);
                        break;
                    case "2":
                        Console.WriteLine("Begin score play!");
                        Gamemode = true;
                        Die.ScorePlay(iscomputer);
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid input");
                        Console.WriteLine();
                        break;
                }
            }

        }

        //the player class
        class Player
        {
            //stores the wins of the players and the scores of the players
            public int Wins;
            public int Score;
        }

    }
}
