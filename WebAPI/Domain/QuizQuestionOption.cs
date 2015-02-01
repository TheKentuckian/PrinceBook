using System;

namespace PrinceBookWebAPI.Models
{
    public class QuizQuestionOption
    {
        public Guid ID;
        public Guid QuizQuestionID;
        public int DisplayOrder;
        public string AnswerText;
        public bool IsCorrectAnswer = false;
    }
}