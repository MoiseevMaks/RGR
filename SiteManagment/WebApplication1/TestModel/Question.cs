using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models.TestModel
{
    public class Question
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<Answer> Answers { get; set; }
    }
    public enum QuestionType
    {
        WrittenAnswer,
        OneAnswer,
        MultipleAnswers
    }
}