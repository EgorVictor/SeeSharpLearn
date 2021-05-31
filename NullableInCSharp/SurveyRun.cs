using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableInCSharp
{
    internal class SurveyRun
    {
        private List<SurveyQuestion> surveyQuestions = new();

        internal void AddQuestion(SurveyQuestion.QuestionType type, string question) =>
            surveyQuestions.Add(new SurveyQuestion(type, question));

        internal void AddQuestion(SurveyQuestion question) => surveyQuestions.Add(question);

        private List<SurveyResponse>? respondents;
        public void PerformSurvey(int numberOfRespondents)
        {
            int respondentsConsenting = 0;
            respondents = new List<SurveyResponse>();
            while (respondentsConsenting < numberOfRespondents)
            {
                var respondent = SurveyResponse.GetRandomId();
                if (respondent.AnswerSurvey(surveyQuestions))
                    respondentsConsenting++;
                respondents.Add(respondent);
            }
        }

        public IEnumerable<SurveyResponse> AllParticipants => respondents ?? Enumerable.Empty<SurveyResponse>();
        public ICollection<SurveyQuestion> Questions => surveyQuestions;
        public SurveyQuestion GetQuestion(int index) => surveyQuestions[index];
    }
}
