using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaGame.Questions;

namespace TriviaQuestionTest
{
    [TestClass]
    public class TriviaQuestion_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBoolean()
        {
            //Arrange
            TriviaQuestion question = new TriviaQuestion();
            TriviaQuestion_Repo repository = new TriviaQuestion_Repo();
            
            //Act
            bool addResult = repository.AddQuestionToList(question);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetQuestions_ShouldReturnCorrectCollection()
        {
            //Arrange
            TriviaQuestion question = new TriviaQuestion();
            TriviaQuestion_Repo repo = new TriviaQuestion_Repo();
            
            repo.AddQuestionToList(question);

            //Act
            List<TriviaQuestion> questions = repo.GetQuestions();

            bool directoryHasQuestions = questions.Contains(question);

            //Assert
            Assert.IsTrue(directoryHasQuestions);
        }

        [TestMethod]
        public void GetByID_ShouldReturnCorrectQuestion()
        {
            //Arrange
            TriviaQuestion_Repo repo = new TriviaQuestion_Repo();
            TriviaQuestion newQuestion = new TriviaQuestion(001, "What is a lowercase A?", "a", "b", "c", "d", TriviaCategory.General);
            repo.AddQuestionToList(newQuestion);
            int ID = 001;

            //Act
            TriviaQuestion searchResult = repo.GetQuestionById(ID);
            //Assert
            Assert.AreEqual(searchResult.QuestionID, ID);
        }

        [TestMethod]
        public void UpdateExistingQuestion_ShouldReturnTrue()
        {
            //Arrange
            TriviaQuestion_Repo repo = new TriviaQuestion_Repo();
            TriviaQuestion oldQuestion = new TriviaQuestion(001, "What is a lowercase A?", "a", "b", "c", "d", TriviaCategory.General);
            repo.AddQuestionToList(oldQuestion);

            TriviaQuestion newQuestion = new TriviaQuestion(001, "What is a lowercase A?", "a", "b", "c", "d", TriviaCategory.Science);

            //Act
            bool updateResult = repo.UpdateExistingQuestion(oldQuestion.QuestionID, newQuestion);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContant_ShouldReturnTrue()
        {
            //Arrange
            TriviaQuestion_Repo repo = new TriviaQuestion_Repo();
            TriviaQuestion oldQuestion = new TriviaQuestion(001, "What is a lowercase A?", "a", "b", "c", "d", TriviaCategory.General);
            repo.AddQuestionToList(oldQuestion);

            //Act
            TriviaQuestion oldContent = repo.GetQuestionById(001);

            bool removeResult = repo.DeleteExistingQuestion(oldContent);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
