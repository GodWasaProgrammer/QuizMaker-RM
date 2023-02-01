namespace QuizMaker_RM
{
    public class Quiz
    {
        public string quizQuestion;
        public List<string> Answers = new List<string>();

        public string PrintAnswerWithoutAsterisk()
        {
            Console.WriteLine(quizQuestion);
            int iterator = 0;
            foreach (string answer in Answers)
            {
                iterator++;
                Console.Write($"{iterator}. {answer.Trim(new char[] { '*' })} ");
            }

            return "";
        }

        public override string ToString()
        {
            return $"{PrintAnswerWithoutAsterisk()}";
        }
    }

}