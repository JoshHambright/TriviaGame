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

        public int GetQuestionCount()
        {
            return _questions.Count();
        }

        public bool HasItBeenAsked(int id)
        {
            TriviaQuestion question = GetQuestionById(id);
            
            return question.HasBeenAsked;
        }

        // Update
        public bool UpdateExistingQuestion(int id, TriviaQuestion newQuestion)
        {
            TriviaQuestion oldQuestion = GetQuestionById(id);
            
            if (oldQuestion != null)
            {

                oldQuestion.QuestionID = newQuestion.QuestionID;
                oldQuestion.Question = newQuestion.Question;
                oldQuestion.CorrectAnswer = newQuestion.CorrectAnswer;
                oldQuestion.WrongAnswer1 = newQuestion.WrongAnswer1;
                oldQuestion.WrongAnswer2 = newQuestion.WrongAnswer2;
                oldQuestion.WrongAnswer3 = newQuestion.WrongAnswer3;
                oldQuestion.TriviaCategory = newQuestion.TriviaCategory;
                return true;
            }
            else
            {
                return false;
            } 
        }     

        public bool UpdatedQuestionAsked(int id)
        {
            TriviaQuestion oldQuestion = GetQuestionById(id);

            if (oldQuestion != null)
            {

                oldQuestion.HasBeenAsked = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool DeleteExistingQuestion(TriviaQuestion existingQuestion)
        {
            bool deleteQuestion = _questions.Remove(existingQuestion);
            return deleteQuestion;
        }

    }
}
