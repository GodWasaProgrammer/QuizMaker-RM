namespace QuizMaker_RM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myQuestions  = new List<string>();

            var myAnswers = new List<string>();
            string correctAnswer;
            Console.WriteLine("Input your new question.");
            myQuestions.Add(Console.ReadLine());
            File.AppendAllLines("Questions.txt", myQuestions);

            Console.WriteLine("Input your different answers");
            while(myAnswers.Count < 3) 
            { 
                myAnswers.Add(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Type the correct answer:");
                correctAnswer = Console.ReadLine();
            } while (!myAnswers.Contains(correctAnswer));

            File.AppendAllLines("Answers.txt", myAnswers);
            
            Console.WriteLine(myQuestions[0]);

            Console.WriteLine("Pick your answer:");
            foreach (string answer in myAnswers)
            {
                Console.WriteLine(answer);
            }

            string myGuess = Console.ReadLine();

            int myGuessAsInt = myAnswers.IndexOf(myGuess);

            if (myGuess == myAnswers[myGuessAsInt])
            {
                Console.WriteLine("That is Correct");
            }

            else
            {
                Console.WriteLine("That is not correct");
            }

        }
    }
}