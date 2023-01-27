namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();

        public override string ToString()
        {
            return $"{quizQuestion}\n 1. {Answers[0].Trim(new char[] { '*' })}, 2. {Answers[1].Trim(new char[] { '*' })}, 3. {Answers[2].Trim(new char[] { '*' })}";
        }

    }

}