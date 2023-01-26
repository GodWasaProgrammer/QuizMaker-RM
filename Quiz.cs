namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();
        public string correctAnswer;

        public override string ToString()
        {
            return $"{quizQuestion}\n {Answers[0]}, {Answers[1]}, {Answers[2]}";
        }

    }

}