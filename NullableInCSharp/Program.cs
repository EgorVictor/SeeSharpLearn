using System;

namespace NullableInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SurveyRun surveyRun = new();

            surveyRun.AddQuestion(SurveyQuestion.QuestionType.YesNo, "你的代码有遇到过空指针异常吗？");
            surveyRun.AddQuestion(new SurveyQuestion(SurveyQuestion.QuestionType.Number, "遇到过多少次，都发生了什么事情？"));
            surveyRun.AddQuestion(SurveyQuestion.QuestionType.Text, "你最喜欢的颜色是什么");

            //surveyRun.AddQuestion(SurveyQuestion.QuestionType.Text,default);

            surveyRun.PerformSurvey(50);

            foreach (var participant in surveyRun.AllParticipants)
            {
                Console.WriteLine($"参与者Id: {participant.Id}:");
                if (participant.AnsweredSurvey)
                {
                    for (int i = 0; i < surveyRun.Questions.Count; i++)
                    {
                        var answer = participant.Answer(i);
                        Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}");
                    }
                }
                else
                {
                    Console.WriteLine("\t无应答");
                }
            }
        }
    }
}
