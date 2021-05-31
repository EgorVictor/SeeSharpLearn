using System;
using System.Collections.Generic;

namespace NullableInCSharp
{
    public class SurveyResponse
    {
        private static readonly Random randomGenerator = new();

        private Dictionary<int, string>? surveyResponses;
        private static int index = 0;

        public SurveyResponse(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public bool AnsweredSurvey => surveyResponses != null;

        public static SurveyResponse GetRandomId()
        {
            return new(++index);
        }

        public bool AnswerSurvey(IEnumerable<SurveyQuestion> questions)
        {
            if (ConsentToSurvey())
            {
                surveyResponses = new Dictionary<int, string>();
                var index = 0;
                foreach (var question in questions)
                {
                    var answer = GenerateAnswer(question);
                    if (answer != null) surveyResponses.Add(index, answer);
                    index++;
                }
            }

            return surveyResponses != null;
        }

        private bool ConsentToSurvey()
        {
            return randomGenerator.Next(0, 2) == 1;
        }

        private string? GenerateAnswer(SurveyQuestion question)
        {
            switch (question.TypeOfQuestion)
            {
                case SurveyQuestion.QuestionType.YesNo:
                    var n = randomGenerator.Next(-1, 2);
                    return n == -1 ? default : n == 0 ? "No" : "Yes";
                case SurveyQuestion.QuestionType.Number:
                    n = randomGenerator.Next(-30, 101);
                    return n < 0 ? default : n.ToString();
                case SurveyQuestion.QuestionType.Text:
                default:
                    switch (randomGenerator.Next(0, 5))
                    {
                        case 0:
                            return default;
                        case 1:
                            return "红";
                        case 2:
                            return "绿";
                        case 3:
                            return "蓝";
                    }

                    return "Red. No, Green. Wait.. Blue... AAARGGGGGHHH!";
            }
        }

        public string Answer(int index)
        {
            return surveyResponses?.GetValueOrDefault(index) ?? "无应答";
        }
    }
}