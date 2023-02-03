using System.Linq;
using System.Text;

namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();

        public override string ToString()
        {
            char[] asterisk = { '*' };
            string joinedStrings = "";
            
            //foreach (string answer in Answers)
            //{
            //    string trimmedString = answer.Trim(asterisk);
            //    int indexPositionOfanswer = Answers.IndexOf(answer);
            //    indexPositionOfanswer++;
            //    joinedStrings += indexPositionOfanswer + ". " + trimmedString + ",";
            //}
            
            for (int answersIndex = 0; answersIndex < Answers.Count(); answersIndex++)
            {
                string trimmedString = Answers[answersIndex].Trim(asterisk);

                int prettyListPrintIndex = answersIndex;
                prettyListPrintIndex++;
                joinedStrings += prettyListPrintIndex + ". " + trimmedString + ",";
            }
            return $"{quizQuestion} Answers:{joinedStrings}";
        }
    }

}