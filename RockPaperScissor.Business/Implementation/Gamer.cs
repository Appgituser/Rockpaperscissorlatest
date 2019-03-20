using RockPaperScissor.Business.Interfaces;
using System;
using System.Linq;
using System.Web;

namespace RockPaperScissor.Business.Implementation
{
    /// <summary>
    /// Class contains methods for Gamer interface.
    /// </summary>
    public class Gamer : IGamer
    {

        /// <summary>
        /// Methid display the final result.
        /// </summary>
        /// <param name="userCount"></param>
        /// <param name="computerCount"></param>
        /// <returns></returns>
        public string DisplayResult(int userCount, int computerCount)
        {
            string result = string.Empty;
            if (HttpContext.Current.Session["TotalScore"] != null)
            {
                if (Convert.ToUInt32(HttpContext.Current.Session["TotalScore"]) == 3)
                {
                    if (userCount > computerCount)
                    {

                        result = "Final Winner is User";
                    }
                    else if (computerCount > userCount)
                    {

                        result = "Final Winner is Computer";
                    }
                    if (new[] { userCount, computerCount }.All(x => x == 0))
                    {

                        result = "Draw the Game";
                    }
                }
            }

            return result;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GameSelection(int input)
        {
            //Random number for Computer choice.
            Random rnd = new Random(DateTime.Now.Millisecond);
            int comChoice;
            comChoice = rnd.Next(1, 4);


            int flagNum = 0;
            string computerSelected = string.Empty;
            switch (comChoice)
            {
                case 1:
                    computerSelected = "Computer Selected ROCK";
                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 3;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 1;
                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 2;
                    }
                    break;
                case 2:
                    computerSelected = "Computer Selected PAPER";

                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 2;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 3;

                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 1;
                    }
                    break;
                case 3:
                    computerSelected = "Computer Selected SCISSOR";

                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 1;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 2;
                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 3;
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            string result = GameResult(flagNum);
            return result + ":" + computerSelected;
        }

      /// <summary>
      /// Method return current game winner.
      /// </summary>
      /// <param name="flagNum"></param>
      /// <returns></returns>
        public string GameResult(int flagNum)
        {

            int userScore;
            int comScore;
            int totalScore;
            string result = string.Empty;

            userScore = HttpContext.Current.Session["userount"] != null ?
                userScore = Convert.ToInt32(HttpContext.Current.Session["userount"]) : 0;

            comScore = HttpContext.Current.Session["Count"] != null ?
                Convert.ToInt32(HttpContext.Current.Session["Count"]) : 0;

            totalScore = HttpContext.Current.Session["TotalScore"] != null ?
                Convert.ToInt32(HttpContext.Current.Session["TotalScore"]) : 0;

            switch (flagNum)
            {
                case 1:
                    result = "User Win !!";
                    userScore++;
                    HttpContext.Current.Session["userount"] = userScore;
                    totalScore++;
                    HttpContext.Current.Session["TotalScore"] = totalScore;
                    break;
                case 2:
                    result = "Computer Win !!";
                    comScore++;
                    HttpContext.Current.Session["Count"] = comScore;
                    totalScore++;
                    HttpContext.Current.Session["TotalScore"] = totalScore;
                    break;
                case 3:
                    result = "Draw !!";
                    break;
                default:
                    break;
            }
            return result;

        }
    }
}
