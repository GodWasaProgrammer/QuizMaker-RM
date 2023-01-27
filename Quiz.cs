namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();

        public override string ToString()
        {
            return $"{quizQuestion}\n {Answers[0].Trim(new char[] {'*'})}, {Answers[1].Trim(new char[] {'*'})}, {Answers[2].Trim(new char[] { '*' })}";
        }

    }

}