using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarations:
            int player1Wins = 0;
            int player2Wins = 0;

            Game game100 = new Game();
            game100.Fight();
            player1Wins = game100.NumPlayerOneWins;
            player2Wins = game100.NumPlayerTwoWins;
            int draws = 100 - (player1Wins + player2Wins);

            //Show player1 wins
            Console.WriteLine("Player One won {0} times", player1Wins.ToString());
            Console.WriteLine("Player Two won {0} times", player2Wins.ToString());
            Console.WriteLine("The players reached a draw {0} times", draws.ToString());

            Console.ReadLine();

            //prompt user to choose weapon
            //Console.WriteLine("Select your weapon: rock, paper, scissors");
            //read user's choice & clean up string
            //string playerOneWeapon = Console.ReadLine().ToLower().Trim();
                                    
        }
    }
    class Player
    {

        //public Player(string _otherWeapon)
        //{
        //    //Put otherWeapon in here
        //    string OtherWeapon = _otherWeapon;
        //}

        public string OtherWeapon { get; set; }

        
    }

    internal class PlayerRock : Player
    {
        //public PlayerRock(string _otherWeapon):base(_otherWeapon) { }

        //Have access to the base class OtherWeapon property

        public bool Act(string OtherWeapon)
        {
            bool win = true;

            if (OtherWeapon == "scissors") {
                win = true;
            }
            else {
                win = false;
            }
            return win;
        }
    }

    class PlayerScissors : Player
    {
        //public PlayerScissors(string _otherWeapon) : base(_otherWeapon) { }
        public bool Act(string OtherWeapon)
        {
            bool win = true;

            if (OtherWeapon == "paper") {
                win = true;
            }
            else {
                win = false;
            }
            return win;
        }

    }

    class PlayerPaper : Player
    {
        //public PlayerPaper(string _otherWeapon) : base(_otherWeapon) { }
        public bool Act(string OtherWeapon)
        {
            bool win = true;

            if (OtherWeapon == "rock") {
                win = true;
            }
            else {
                win = false;
            }
            return win;
        }

    }

    class Game
    {
        public int NumPlayerOneWins { get; set; }
        public int NumPlayerTwoWins { get; set; }

        public void Fight()

        {
            //Array of weapons
            string[] weapons = new string[3] { "rock", "paper", "scissors" };

            //instance of random class
            Random rnd = new Random();

            //Set flags for an individual win, or not
            bool playerOneWin = false;
            bool playerTwoWin = false;

            //Variables to hold weapon name for each player
            string playerOneWeapon = "";
            string playerTwoWeapon = "";

            //Counters for player wins
            int playerOneCounter = 0;
            int playerTwoCounter = 0;

            //Instantiate Player classes for playerOne
            PlayerRock playerOneRock = new PlayerRock();
            PlayerPaper playerOnePaper = new PlayerPaper();
            PlayerScissors playerOneScissors = new PlayerScissors();
            //Instantiate Player classes for playerTwo
            PlayerRock playerTwoRock = new PlayerRock();
            PlayerPaper playerTwoPaper = new PlayerPaper();
            PlayerScissors playerTwoScissors = new PlayerScissors();

            for (int i = 1; i <= 100; i++)
            {
                //playerOne gets their weapon
                int weaponId1 = rnd.Next(0, 2);
                playerOneWeapon = weapons[weaponId1];

                //playerTwo gets their weapon
                int weaponId2 = rnd.Next(0, 2);
                playerTwoWeapon = weapons[weaponId2];

                //Play each combination & return win status
                playerOneWin = WhichClass(playerOneWeapon, playerTwoWeapon);
                playerTwoWin = WhichClass(playerTwoWeapon, playerOneWeapon);               

                if (playerOneWin)
                {
                    playerOneCounter++;
                }
                else if (playerTwoWin)
                {
                    playerTwoCounter++;
                }               

            }//for

            NumPlayerOneWins = playerOneCounter;
            NumPlayerTwoWins = playerTwoCounter;
                   
        }//Fight()

        private bool WhichClass(string playerWeapon, string otherWeapon)
        {
            //set the playerWin here
            bool playerWin = false;

            switch (playerWeapon)
            {
                case "rock":
                    PlayerRock playerGameR = new PlayerRock();
                    playerWin = playerGameR.Act(otherWeapon);
                    break;
                case "paper":
                    PlayerPaper playerGameP = new PlayerPaper();
                    playerWin = playerGameP.Act(otherWeapon);
                    break;
                case "scissors":
                    PlayerScissors playerGameS = new PlayerScissors();
                    playerWin = playerGameS.Act(otherWeapon);
                    break;
                default:
                    break;
            }

            return playerWin;

        }//WhichClass()

    }//Game{}

}//namespace
