using System.Net.NetworkInformation;

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
            /// here to control how many answers we want for our questions
            int amountOfAnswers;
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

                do
                {
                    Console.WriteLine("Input your amount of answers");
                    bool didItParse = int.TryParse(Console.ReadLine(), out amountOfAnswers);

                    if (amountOfAnswers < 2)
                    {
                        if (didItParse == false)
                        {
                            Console.WriteLine("You have to put 2 or more answers for a question.");
                        }

                    }

                    if (didItParse == false)
                    {
                        Console.WriteLine("Cant parse. try again");
                    }
                }
                while (amountOfAnswers < GameLogic.MINANSWERS && amountOfAnswers < GameLogic.MAXANSWERS);

                List<string> oneTwoThree = new()
                {
                    "First",
                    "Second",
                    "Third",
                    "Fourth",
                    "Fifth"
                };

                int iterator = -1;

                // registers our inputs
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
                while (newQuiz.Answers.Count < amountOfAnswers);

                int correctAnswerByIndex = 0;
                List<int> splitInts = new();
                do
                {
                    iterator = 0;
                    foreach (string item in newQuiz.Answers)
                    {
                        iterator++;
                        Console.WriteLine($"{iterator}.{item}");
                    }

                    bool isParsable = false;
                    do
                    {
                        string[] answerArray;
                        do
                        {
                            Console.WriteLine("Enter Your Correct Answer by number:");
                            Console.WriteLine("If multiple choices are correct, just input them like this: 1,2,3,4,5");

                            string stringToSplit = Console.ReadLine();

                            answerArray = stringToSplit.Split(",");

                            if (answerArray.Count() > GameLogic.MAXANSWERS)
                            {
                                Console.WriteLine("Too many inputs, try again");
                            }

                        }
                        while (answerArray.Count() > GameLogic.MAXANSWERS);

                        int splittedStringToIntToList;
                        foreach (string answer in answerArray)
                        {
                            isParsable = int.TryParse(answer, out splittedStringToIntToList);
                            if (isParsable)
                            {
                                splitInts.Add(splittedStringToIntToList);
                            }
                            else
                            {
                                Console.WriteLine("one of your input wasnt parsable.");
                            }

                        }

                    }
                    while (isParsable == false);

                    for (int i = 0; i < splitInts.Count; i++)
                    {
                        var IndexOfANswer = splitInts[i];
                        IndexOfANswer--;
                        newQuiz.Answers[IndexOfANswer] += "*";

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
                Console.WriteLine(item.ToString());
            }

        }

        public static List<int> ParseAnswer()
        {
            List<int> answersByIndex = new();

            PickAnswerByIndexPrint();

            string multichoiceAnswer = Console.ReadLine();
            string[] stringArray;
            stringArray = multichoiceAnswer.Split(",");

            foreach (string answerIndex in stringArray)
            {
                answersByIndex.Add(int.Parse(answerIndex));

            }

            return answersByIndex;
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
                Console.WriteLine(quizList[currentquestion].ToString());
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

            }
            while (didItParse == false);

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