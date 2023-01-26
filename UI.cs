namespace QuizMaker_RM
{
    public class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Our Quiz Maker!");
            Console.WriteLine("This Software allows you to make your own quiz!");
        }

        public static void AddNewQuiz(List<Quiz> quizList)
        {
            Quiz newQuiz = new();

            do
            {
                do
                {
                    Console.WriteLine("Enter Your Quiz-Question:");
                    newQuiz.quizQuestion = Console.ReadLine();

                    if (newQuiz.quizQuestion == string.Empty)
                    {
                        Console.WriteLine("You have to type a question.");
                    }
                }
                while (newQuiz.quizQuestion == string.Empty);

                List<string> oneTwoThree = new List<string>();
                oneTwoThree.Add("First");
                oneTwoThree.Add("Second");
                oneTwoThree.Add("Third");
                int iterator = -1;
                do
                {
                    iterator++;
                    Console.WriteLine($"Enter Your {oneTwoThree[iterator]} Answer");
                    
                    string input = Console.ReadLine();

                    if (input == string.Empty || input == null)
                    {
                        iterator--;
                        Console.WriteLine("You have to type an answer.");
                    }
                    else 
                    { 
                    newQuiz.Answers.Add(input);
                    }

                }
                while (newQuiz.Answers.Count < 3);

                do
                {
                    Console.WriteLine("Enter Your Correct Answer:");
                    newQuiz.correctAnswer = Console.ReadLine();
                }
                while (!newQuiz.Answers.Contains(newQuiz.correctAnswer));

                    quizList.Add(newQuiz);
                
                Console.WriteLine("Do you want to add more? if so press y");
            } 

            while (Console.ReadLine().ToLower() == "y");

        }

        public static void DoYouWishToPlay(List<Quiz> quizList)
        {
            Console.WriteLine("Do you wish to play our Quiz?");
            Console.WriteLine("If so, 5 randomly selected questions will be selected and presented to you");
            Console.WriteLine("Each Correct guess is worth 1 point");
            Console.WriteLine("enter y to play");

            if (Console.ReadLine().ToLower() == "y")
            {
                PrintOurFiveQuestions(quizList);
            }
            else
            {
                Console.WriteLine("You Chose not to play!");
            }

        }

        public static void PrintOurQuizList(List<Quiz> quizList)
        {
            // Prints what quizzes we have so far
            foreach (var item in quizList)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintCurrentScore(int currentScore)
        {
            Console.WriteLine($"Your Current Score is:{currentScore}");
        }

        public static void PrintOurFiveQuestions(List<Quiz> quizList)
        {
            List<int> ourfivequestions = new List<int>();
            ourfivequestions = GameLogic.PickFiveQuestions(quizList);

            foreach (int currentquestion in ourfivequestions)
            {
                Console.WriteLine(quizList[currentquestion].ToString());

                GameLogic.CheckIfAnswerIsCorrect(quizList, currentquestion);

                UI.PrintCurrentScore(Program.currentScore);
            }

        }

    }
}