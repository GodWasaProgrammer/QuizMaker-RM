using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
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
