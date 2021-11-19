using System;

namespace TicTacToeGameConsole
{
    class Program               
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] gamenum = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Console.WriteLine("Welcome to Tic Tac Toe Game!");

                Console.WriteLine("Player 1: X");
                Console.WriteLine("Player 2: 0");
                Console.WriteLine();
            do
            {
                currentPlayer = GetNextPlayer(currentPlayer);
                HeadsUpDisplay(currentPlayer);
                GameEngine(gamenum, currentPlayer);
                gameStatus = checking(gamenum);
                DrawGameboard(gamenum);

            } while (gameStatus.Equals(0));
     
            HeadsUpDisplay(currentPlayer);
            DrawGameboard(gamenum);


            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"Game over !!");
            }
         
        }

        private static int checking(char[] gameMarkers)
        {
           
            if (IsGameDraw(gameMarkers))
            {
                return 1;
            }

            return 0;
        }

        private static bool IsGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';
        }

        private static bool gamefinito(char[] gameMarkers)
        {
            return false;
        }

        private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }
  

        private static void GameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = gameMarkers[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                        HeadsUpDisplay(currentPlayer);
                        
                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void HeadsUpDisplay(int PlayerNumber)
        {
       
            Console.WriteLine();
            Console.Write($"Player {PlayerNumber}'s move  >  ");
            Console.Write("");

        }

        static void DrawGameboard(char[] gameMarkers)
        {
       
            Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}