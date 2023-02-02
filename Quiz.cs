using System.Linq;
using System.Text;

namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();

        //public string PrintAnswerWithoutAsterisk()
        //{
        //    Console.WriteLine(quizQuestion);
        //    int iterator = 0;
        //    foreach (string answer in Answers)
        //    {
        //        iterator++;
        //        Console.Write($"{iterator}. {answer.Trim(new char[] { '*' })} ");
        //    }

        //    return "";
        //}

        public override string ToString()
        {
            char[] asterisk = { '*' };
            string joinedStrings = "";
            
            foreach (string answer in Answers)
            {
                string trimmedString = answer.Trim(asterisk);
                int indexPositionOfanswer = Answers.IndexOf(answer);
                indexPositionOfanswer++;
                joinedStrings += indexPositionOfanswer + ". " + trimmedString + ",";

            }
            
            return $"{quizQuestion} Answers:{joinedStrings}";
        }
    }

}