using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaGame.Questions;

namespace TriviaUI
{
    public class ProgramUI
    {
        //Fields


        private TriviaQuestion_Repo _repo = new TriviaQuestion_Repo();
        private int PlayerOneScore = 0;
        private int PlayerTwoScore = 0;
        private bool keepPlaying = true;

        public void Run()
        {
            // Set file path to wherever you have the MasterList.csv saved on your computer
            ImportQuestions(@"C:/Users/joshh/source/repos/Trivia/MasterList.csv");
            //SeedQuestions();
            SplashScreen();
            while (keepPlaying)
            {
                Menu();
            }
        }

        public void SplashScreen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                     ████████╗██████╗ ██╗██╗   ██╗██╗ █████╗ ");
            Console.WriteLine("                     ╚══██╔══╝██╔══██╗██║██║   ██║██║██╔══██╗");
            Console.WriteLine("                        ██║   ██████╔╝██║██║   ██║██║███████║");
            Console.WriteLine("                        ██║   ██╔══██╗██║╚██╗ ██╔╝██║██╔══██║");
            Console.WriteLine("                        ██║   ██║  ██║██║ ╚████╔╝ ██║██║  ██║");
            Console.WriteLine("                        ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝╚═╝  ╚═╝");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                             Lets Play Trivia!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey();
        }

        public void Menu()
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1> Classic Game");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("        (10 Questions, All Categories)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     2> Single Category Game");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("        (10 Questions, One Category)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     3> Two Player Game");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("        (10 Questions Each, All Categories)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     4> Exit");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   ");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What would you like to do?\n Enter a number.");
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    SinglePlayerBestofTen();
                    break;
                case "2":
                    CategoryBestOfTen();
                    break;
                case "3":
                    TwoPlayerGame();
                    break;
                case "4":
                    keepPlaying = false;
                    break;
                default:
                    break;
            }
        }

        public void SinglePlayerBestofTen()
        {
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 1);
            Console.Clear();
            Header();
            GameOver();
            Console.WriteLine("                  You got " + PlayerOneScore + " out of 10 questions correct!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        public void CategoryBestOfTen()
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----Choose A Category----");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1> General");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2> Geography");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3> History");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4> Science");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("5> Pop Culture");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------");
            Console.WriteLine("Which category do you choose?\n Enter a number.");
            string selectCategory = Console.ReadLine();
            TriviaCategory category;
            switch (selectCategory)
            {
                case "1":
                    category = TriviaCategory.General;
                    break;
                case "2":
                    category = TriviaCategory.Geography;
                    break;
                case "3":
                    category = TriviaCategory.History;
                    break;
                case "4":
                    category = TriviaCategory.Science;
                    break;
                case "5":
                    category = TriviaCategory.PopCulture;
                    break;
                default:
                    return;
                   
            }
            Console.Clear();
            AskQuestionByID(PickAQuestion_Category(category),1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            AskQuestionByID(PickAQuestion_Category(category), 1);
            Console.Clear();
            Header();
            GameOver();
            Console.WriteLine("                         You got " + PlayerOneScore + " out of 10 questions correct!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public void TwoPlayerGame()
        {
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            AskQuestionByID(PickAQuestion(), 1);
            AskQuestionByID(PickAQuestion(), 2);
            Console.Clear();
            Header();
            GameOver();
            if (PlayerOneScore > PlayerTwoScore)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    Player One Wins! Player One had " + PlayerOneScore + " out of 10 questions correct!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                    Player Two's Score was " + PlayerTwoScore + " out of 10 questions correct.");
            }
            else if (PlayerOneScore == PlayerTwoScore)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    Player One and Player Two TIED!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    Player Two Wins! Player Two had " + PlayerTwoScore + " out of 10 questions correct!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                    Player One's Score was " + PlayerOneScore + " out of 10 questions correct.");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }


        public int PickAQuestion()
        {
            // Randomly select a question that hasn't been asked previously
            int totalQuestions = _repo.GetQuestionCount();
            Random randy = new Random();
            int questionToAsk = randy.Next(1, totalQuestions + 1);
            int counter = 0;


            while (_repo.HasItBeenAsked(questionToAsk) != false)
            {
                questionToAsk = randy.Next(1, totalQuestions + 1);
                
                if (counter >= 102)
                {
                    Console.WriteLine("No More available Questions. Try Reloading the game.");
                    keepPlaying = false;
                    break;
                }
                counter++;
            }

            return questionToAsk;
        }

        public int PickAQuestion_Category(TriviaCategory category)
        {
            //get a list of questions
            int totalQuestions = _repo.GetQuestionCount();
            Random randy = new Random();
            int questionToAsk = randy.Next(1, totalQuestions + 1);
            int counter = 0;

            while (_repo.HasItBeenAsked(questionToAsk) || _repo.GetQuestionById(questionToAsk).TriviaCategory != category)
            {
                questionToAsk = randy.Next(1, totalQuestions + 1);
                if (counter >= 102)
                {
                    break;
                }
                counter++;
            }

            return questionToAsk;
        }

        public bool AskQuestionByID(int id, int playerNumber)
        {
            Console.Clear();
            Header();
            TriviaQuestion question = _repo.GetQuestionById(id);
            if (playerNumber == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("====== Player #1 =======");
            }
            else if (playerNumber == 2)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("====== Player #2 =======");
            }
            Console.ResetColor();
            switch (question.TriviaCategory)
            {
                case TriviaCategory.General:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        General Trivia");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ResetColor();

                    break;
                case TriviaCategory.History:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("        History Trivia");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ResetColor();


                    break;
                case TriviaCategory.PopCulture:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("        Pop Culture Trivia");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------------------------------------");
                    Console.ResetColor();
                    break;
                case TriviaCategory.Geography:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-----------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("        Geography Trivia");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                    break;
                case TriviaCategory.Science:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("        Science Trivia");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------");
                    Console.ResetColor();
                    break;

            }



            Console.WriteLine(question.Question);
            Console.WriteLine("");

            // Randomly order the answers presented to user
            Random randy = new Random();
            int order = randy.Next(1, 11);
            string correct = "1";
            // Order of questions assigned one of 10 ways
            switch (order)
            {
                case 1:
                    Console.WriteLine("1> " + question.CorrectAnswer);
                    Console.WriteLine("2> " + question.WrongAnswer1);
                    Console.WriteLine("3> " + question.WrongAnswer2);
                    Console.WriteLine("4> " + question.WrongAnswer3);
                    correct = "1";
                    break;
                case 2:
                    Console.WriteLine("1> " + question.WrongAnswer1);
                    Console.WriteLine("2> " + question.CorrectAnswer);
                    Console.WriteLine("3> " + question.WrongAnswer2);
                    Console.WriteLine("4> " + question.WrongAnswer3);
                    correct = "2";
                    break;

                case 3:
                    Console.WriteLine("1> " + question.WrongAnswer1);
                    Console.WriteLine("2> " + question.WrongAnswer2);
                    Console.WriteLine("3> " + question.CorrectAnswer);
                    Console.WriteLine("4> " + question.WrongAnswer3);
                    correct = "3";
                    break;

                case 4:
                    Console.WriteLine("1> " + question.WrongAnswer1);
                    Console.WriteLine("2> " + question.WrongAnswer2);
                    Console.WriteLine("3> " + question.WrongAnswer3);
                    Console.WriteLine("4> " + question.CorrectAnswer);
                    correct = "4";
                    break;
                case 5:
                    Console.WriteLine("1> " + question.WrongAnswer2);
                    Console.WriteLine("2> " + question.CorrectAnswer);
                    Console.WriteLine("3> " + question.WrongAnswer3);
                    Console.WriteLine("4> " + question.WrongAnswer1);
                    correct = "2";
                    break;
                case 6:
                    Console.WriteLine("1> " + question.WrongAnswer3);
                    Console.WriteLine("2> " + question.CorrectAnswer);
                    Console.WriteLine("3> " + question.WrongAnswer2);
                    Console.WriteLine("4> " + question.WrongAnswer1);
                    correct = "2";
                    break;
                case 7:
                    Console.WriteLine("1> " + question.WrongAnswer3);
                    Console.WriteLine("2> " + question.CorrectAnswer);
                    Console.WriteLine("3> " + question.WrongAnswer1);
                    Console.WriteLine("4> " + question.WrongAnswer2);
                    correct = "2";
                    break;
                case 8:
                    Console.WriteLine("1> " + question.WrongAnswer3);
                    Console.WriteLine("2> " + question.WrongAnswer1);
                    Console.WriteLine("3> " + question.WrongAnswer2);
                    Console.WriteLine("4> " + question.CorrectAnswer);
                    correct = "4";
                    break;
                case 9:
                    Console.WriteLine("1> " + question.WrongAnswer2);
                    Console.WriteLine("2> " + question.WrongAnswer1);
                    Console.WriteLine("3> " + question.WrongAnswer3);
                    Console.WriteLine("4> " + question.CorrectAnswer);
                    correct = "4";
                    break;
                case 10:
                    Console.WriteLine("1> " + question.WrongAnswer3);
                    Console.WriteLine("2> " + question.WrongAnswer2);
                    Console.WriteLine("3> " + question.CorrectAnswer);
                    Console.WriteLine("4> " + question.WrongAnswer1);
                    correct = "3";
                    break;
            }
            _repo.UpdatedQuestionAsked(id);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            Console.WriteLine("Enter the number for the correct answer:");
            string key = Console.ReadLine();
            if (key == correct)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Thats Correct!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key for the next question");
                Console.ReadKey();
                if (playerNumber == 1)
                {
                    PlayerOneScore++;
                }
                else if (playerNumber == 2)
                {
                    PlayerTwoScore++;
                }
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"YOU'RE WRONG! Its actually: { question.CorrectAnswer}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key for the next question");
                Console.ReadKey();
                return false;
            }


        }

        public void Header()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("8888888 8888888888 8 888888888o.    8 8888 `8.`888b           ,8'  8 8888          .8.          ");
            Console.WriteLine("      8 8888       8 8888    `88.   8 8888  `8.`888b         ,8'   8 8888         .888.         ");
            Console.WriteLine("      8 8888       8 8888     `88   8 8888   `8.`888b       ,8'    8 8888        :88888.        ");
            Console.WriteLine("      8 8888       8 8888     ,88   8 8888    `8.`888b     ,8'     8 8888       . `88888.       ");
            Console.WriteLine("      8 8888       8 8888.   ,88'   8 8888     `8.`888b   ,8'      8 8888      .8. `88888.");
            Console.WriteLine("      8 8888       8 888888888P'    8 8888      `8.`888b ,8'       8 8888     .8`8. `88888.");
            Console.WriteLine("      8 8888       8 8888`8b        8 8888       `8.`888b8'        8 8888    .8' `8. `88888.");
            Console.WriteLine("      8 8888       8 8888 `8b.      8 8888        `8.`888'         8 8888   .8'   `8. `88888.");
            Console.WriteLine("      8 8888       8 8888   `8b.    8 8888         `8.`8'          8 8888  .888888888. `88888.  ");
            Console.WriteLine("      8 8888       8 8888     `88.  8 8888          `8.`           8 8888 .8'       `8. `88888. ");
            Console.WriteLine();
        }
        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                          ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼                          ");
            Console.WriteLine("                          ███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀                          ");
            Console.WriteLine("                          ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼                          ");
            Console.WriteLine("                          ██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀                          ");
            Console.WriteLine("                          ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼                          ");
            Console.WriteLine("                          ███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄                          ");
            Console.WriteLine("                          ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼                          ");
            Console.WriteLine("                          ███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼                          ");
            Console.WriteLine("                          ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼                          ");
            Console.WriteLine("                          ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼                          ");
            Console.WriteLine("                          ██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼                          ");
            Console.WriteLine("                          ███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄                          ");
            Console.WriteLine("                          ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼                          ");
            Console.WriteLine("                                                                                        ");
            Console.ResetColor();
        }
        public void ImportQuestions(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                int id = Convert.ToInt32(columns[0]);
                string question = columns[1];
                string rightAnswer = columns[2];
                string wrong1 = columns[3];
                string wrong2 = columns[4];
                string wrong3 = columns[5];
                TriviaCategory category;
                switch (columns[6])
                {
                    case "General":
                        category = TriviaCategory.General;
                        break;
                    case "History":
                        category = TriviaCategory.History;
                        break;
                    case "Geography":
                        category = TriviaCategory.Geography;
                        break;
                    case "Pop Culture":
                        category = TriviaCategory.PopCulture;
                        break;
                    case "Science":
                        category = TriviaCategory.Science;
                        break;
                    default:
                        category = TriviaCategory.General;
                        break;
                }


                TriviaQuestion question1 = new TriviaQuestion(id, question, rightAnswer, wrong1, wrong2, wrong3, category);
                _repo.AddQuestionToList(question1);

            }

        }
        private void SeedQuestions()
        {
            //Seed Questions for testing if not using the .csv files
            TriviaQuestion question1 = new TriviaQuestion(
                001, "What vegetable has varieties known as Bell Tower, Orobelle, and Jupiter?", "Pepper", "Squash", "Onion", "Corn", TriviaCategory.General);
            TriviaQuestion question2 = new TriviaQuestion(
                002, "What was the name of Michael J Fox's character in the television sitcom Family Ties?", "Alex Keaton", "Marty McFly", "Stuart Little", "Mike Flaherty", TriviaCategory.PopCulture);
            TriviaQuestion question3 = new TriviaQuestion(
                003, "How many Federal Holidays are there in the United States?", "10", "7", "13", "18", TriviaCategory.General);
            TriviaQuestion question4 = new TriviaQuestion(
                004, "What is the name of the world's longest river?", "Nile", "Amazon", "Mississippi", "Wabash", TriviaCategory.Geography);
            TriviaQuestion question5 = new TriviaQuestion(
                005, "Who is considered the father of the World Wide Web?", "Tim Berners-Lee", "Steve Jobs", "Bill Gates", "Jeff Bezos", TriviaCategory.History);

            _repo.AddQuestionToList(question1);
            _repo.AddQuestionToList(question2);
            _repo.AddQuestionToList(question3);
            _repo.AddQuestionToList(question4);
            _repo.AddQuestionToList(question5);

        }
        public void PrintTheWholeRepo()
        {
            List<TriviaQuestion> listOfQuestions = _repo.GetQuestions();
            foreach (TriviaQuestion question in listOfQuestions)
            {
                Console.WriteLine("QuestionID: " + question.QuestionID);
                Console.WriteLine("Question: " + question.Question);
                Console.WriteLine("Right Answer: " + question.CorrectAnswer);
                Console.WriteLine("Wrong 1: " + question.WrongAnswer1);
                Console.WriteLine("Wrong 2: " + question.WrongAnswer2);
                Console.WriteLine("Wrong 3: " + question.WrongAnswer3);
                Console.WriteLine("Category: " + question.TriviaCategory);

            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
