using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaGame.Questions;

namespace TriviaQuestionTest
{
    [TestClass]
    public class TriviaQuestionTest
    {
        [TestMethod]
        public void SetQuestionID_ShouldReturnCorrectID()
        {
            //Arrange
            TriviaQuestion question = new TriviaQuestion();

            //Act
            question.QuestionID = 001;


            //Assert
            Assert.AreEqual(question.QuestionID, 001);

        }

     
    }
}
