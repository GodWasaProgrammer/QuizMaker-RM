using System.Runtime.InteropServices;

namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers;
        public string optionAnswer1;
        public string optionAnswer2;
        public string optionAnswer3;
        public string correctAnswer;

        public override string ToString()
        {
            return $"{quizQuestion}\n, {optionAnswer1}, {optionAnswer2}, {optionAnswer3}";
        }

    }

}