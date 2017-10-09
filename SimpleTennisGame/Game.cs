using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTennisGame
{
    class Game
    {
        private int playerAInput, playerBInput;

        public Game(int playerAInput, int playerBInput)
        {
            this.playerAInput = playerAInput;
            this.playerBInput = playerBInput;
        }
        public string GetCurrentStatus()
        {
            string result = String.Empty;

            if (Check4PointsAndOver2(out result)) return result;

            if (CheckDeuce(out result)) return result;

            if (CheckAdvantage(out result)) return result;

            if (playerAInput < 0 || playerBInput < 0) result = "Bad inputs!";
            else result = "The match result is: Player1 -> " + GetPlayerEnum(this.playerAInput) + " VS Player2 -> " + GetPlayerEnum(this.playerBInput) + "!";

            return result;
        }

        private string GetPlayerEnum(int playerEnum)
        {
            string result = String.Empty;
            switch (playerEnum) { 
                case (int)GameStatus.Love:
                    result = GameStatus.Love.ToString();
                    break;
                case (int)GameStatus.Fifteen:
                    result = GameStatus.Fifteen.ToString();
                    break;
                case (int)GameStatus.Forty:
                    result = GameStatus.Forty.ToString();
                    break;
                case (int)GameStatus.Thirty:
                    result = GameStatus.Thirty.ToString();
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        private bool CheckAdvantage(out string result)
        {
            bool checkResult = false;
            String resultStr = String.Empty;

            if (playerAInput == playerBInput - 1 && playerBInput > (int)GameStatus.Forty)
            {
                resultStr = "The match result is: Advantage for Player 2!";
                checkResult = true;
            }

            if (playerBInput == playerAInput - 1 && playerAInput > (int)GameStatus.Forty)
            {
                resultStr = "The match result is: Advantage for Player 1!";
                checkResult = true;
            }

            result = resultStr;
            return checkResult;
        }

        private bool CheckDeuce(out string result)
        {
            bool checkResult = false;
            String resultStr = String.Empty;

            if (playerAInput == playerBInput && playerAInput >= (int)GameStatus.Forty)
            {
                resultStr = "The match result is: Deuce!";
                checkResult = true;
            }

            result = resultStr;
            return checkResult;
        }

        //primo controllo, vedo se il primo input è vincente sul secondo in base alla prima regola
        private bool Check4PointsAndOver2(out string result)
        {
            bool checkResult = false;
            String resultStr = String.Empty;

            if (playerAInput > 3 && playerAInput - 1 > playerBInput)
            {
                resultStr = "Player1 Win!";
                checkResult = true;
            }

            if (playerBInput > 3 && playerBInput - 1 > playerAInput)
            {
                resultStr = "Player2 Win!";
                checkResult = true;
            }

            result = resultStr;
            return checkResult;
        }
    }
}
