using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame.Questions
{
    public enum TriviaCategory
    {
        General,
        PopCulture,
        Science,
        History,
        Geography
    }

    public class TriviaQuestion
    {
        public int QuestionID { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }

        public TriviaCategory TriviaCategory { get; set; }
        
        public TriviaQuestion() { }

        public TriviaQuestion(int questionID, string question, string correctAnswer, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, TriviaCategory category)
        {
            QuestionID = questionID;
            Question = question;
            CorrectAnswer = correctAnswer;
            WrongAnswer1 = wrongAnswer1;
            WrongAnswer2 = wrongAnswer2;
            WrongAnswer3 = wrongAnswer3;
            TriviaCategory = category;
        }

    }




}

