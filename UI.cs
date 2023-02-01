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

                List<string> oneTwoThree = new()
                {
                    "First",
                    "Second",
                    "Third"
                };

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

                int correctAnswerByIndex;
                do
                {
                    iterator = 0;
                    foreach (string item in newQuiz.Answers)
                    {
                        iterator++;
                        Console.WriteLine($"{iterator}.{item}");
                    }

                    Console.WriteLine("Enter Your Correct Answer by number:");

                    _ = Int32.TryParse(Console.ReadLine(), out correctAnswerByIndex);
                    correctAnswerByIndex--;

                    if (correctAnswerByIndex < 0 || correctAnswerByIndex > 2)
                    {
                        Console.WriteLine("You need to input a valid indexposition");
                    }
                    else
                    {
                        newQuiz.Answers[correctAnswerByIndex] = newQuiz.Answers[correctAnswerByIndex] + "*";
                    }

                }
                while (!newQuiz.Answers[correctAnswerByIndex].Contains('*'));

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

        public static int ParseAnswer()
        {
            int answerByIndex;
            bool didItParse;
            do
            {
                PickAnswerByIndexPrint();

                didItParse = Int32.TryParse(Console.ReadLine(), out answerByIndex);
                answerByIndex--;
                GameLogic.CheckIfParseSuccess(answerByIndex, didItParse);

            }
            while (answerByIndex > 2 || didItParse == false);

            return answerByIndex;
        }

        public static void PrintCurrentScore(int currentScore)
        {
            Console.WriteLine($"Your Current Score is:{currentScore}");
        }

        public static void PrintOurFiveQuestions(List<Quiz> quizList)
        {
            List<int> ourfivequestions = GameLogic.PickFiveQuestions(quizList);
            foreach (int currentquestion in ourfivequestions)
            {
                Console.WriteLine(quizList[currentquestion].PrintAnswerWithoutAsterisk());
                GameLogic.CheckIfAnswerIsCorrect(quizList, currentquestion);

                PrintCurrentScore(GameLogic.currentScore);
            }

        }
        public static int TakeInput()
        {
            bool didItParse;
            int choice;
            do
            {
                didItParse = int.TryParse(Console.ReadLine(), out choice);
                choice--;

                if (didItParse == false)
                {
                    Console.WriteLine("Could not Parse your input.");
                }

                if (choice > 3)
                {
                    Console.WriteLine("Incorrect Choice");
                    didItParse = false;
                }

            } while (didItParse == false);

            return choice;

        }

        public static void MenuPrint()
        {
            Console.WriteLine("Menu:\n1.Add a New Quiz! \n2.Play A round of Quiz \n3.Print All questions \n4.Exit Software");
        }

        public static void NotAbleToParsePrint()
        {
            Console.WriteLine("Was not able to parse your input, try a number between 1 and 3");
        }

        public static void CanOnlyPickBetweenOneAndThreePrint()
        {
            Console.WriteLine("You can only pick 1-3, any other option is not acceptable.");
        }

        public static void PickAnswerByIndexPrint()
        {
            Console.WriteLine("Pick your answer by index");
        }

        public static void ThatIsCorrectPrint()
        {
            Console.WriteLine("That is Correct!");
        }

        public static void ThatisNotCorrectPrint()
        {
            Console.WriteLine("That is not correct...");
        }

    }
}