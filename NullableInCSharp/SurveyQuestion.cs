using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableInCSharp
{
    public class SurveyQuestion
    {

        public enum QuestionType
        {
            YesNo,
            Number,
            Text
        }

        public SurveyQuestion(QuestionType typeOfQuestion, string text) =>
            (QuestionText, TypeOfQuestion) = (text, typeOfQuestion);


        public string QuestionText { get; }
        public QuestionType TypeOfQuestion { get; }
    }
}
