using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame.Questions
{
    public class TriviaQuestion_Repo
    {
        private List<TriviaQuestion> _questions = new List<TriviaQuestion>();


        //Create
        public bool AddQuestionToList(TriviaQuestion question)
        {
            int StartingCount = _questions.Count;

            _questions.Add(question);
            bool wasAdded = (_questions.Count > StartingCount) ? true : false;
            return wasAdded;
        }

        // Read
        public List<TriviaQuestion> GetQuestions()
        {
            return _questions;
        }

        public TriviaQuestion GetQuestionById(int id)
        {
            foreach (TriviaQuestion question in _questions)
            {
                if(question.QuestionID == id)
                {
                    return question;
                }
            }
            return null;
        }

        // Update
        public bool UpdateExistingQuestion(int id, TriviaQuestion newQuestion)
        {
            TriviaQuestion oldQuestion = GetQuestionById(int id);
            if (oldQuestion != null)
            {

                oldQuestion.QuestionID = newQuestion.questionID;
                oldQuestion.Question = newQuestion.question;
                oldQuestion.CorrectAnswer = newQuestion.correctAnswer;
                oldQuestion.WrongAnswer1 = newQuestion.wrongAnswer1;
                WrongAnswer2 = wrongAnswer2;
                WrongAnswer3 = wrongAnswer3;
                TriviaCategory = category;
            }






        // Delete
    }
}
