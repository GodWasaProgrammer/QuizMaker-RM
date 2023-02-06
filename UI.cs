namespace QuizMaker_RM
{
    public class UI
    {
        static readonly List<string> listOfSuffixForPrint = new()
                {
                    "First",
                    "Second",
                    "Third",
                    "Fourth",
                    "Fifth"
                };

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Our Quiz Maker!");
            Console.WriteLine("This Software allows you to make your own quiz!");
        }

        public static Quiz AddNewQuiz()
        {
            Quiz newQuiz = new();

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

            int amountOfAnswers;
            bool didItParse;
            do
            {    // checks so our amount of answers is acceptable (< 5)
                 // bool didItParse;

                Console.WriteLine("Input your amount of answers");
                didItParse = int.TryParse(Console.ReadLine(), out amountOfAnswers);
                if (amountOfAnswers < GameLogic.MINANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"You have to put {GameLogic.MINANSWERS} or more answers for a question");
                }

                if (amountOfAnswers > GameLogic.MAXANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"Too many answers. needs to be less then {GameLogic.MAXANSWERS}");
                }

            }
            while (didItParse == false);

            //// registers our inputs
            ///
            int numberOfSuffixToPrint = 0;
            do
            {
                Console.WriteLine($"Enter Your {listOfSuffixForPrint[numberOfSuffixToPrint]} Answer");

                numberOfSuffixToPrint++;

                string input = Console.ReadLine();

                if (input == string.Empty || input == null)
                {
                    numberOfSuffixToPrint--;
                    Console.WriteLine("You have to type an answer.");
                }
                else
                {
                    newQuiz.Answers.Add(input);
                }

            }
            while (newQuiz.Answers.Count < amountOfAnswers);

            return newQuiz;
        }

        public static void AddCorrectAnswer(Quiz newQuiz)
        {
            int correctAnswerByIndex = 0;
            List<int> splitInts = new();
            do
            {
                UI.PrintAnswers(newQuiz);

                string[] answerArray = UI.SplitAnswers();
                GameLogic.WriteSplitIntsToAnswers(splitInts, answerArray);

                for (int i = 0; i < splitInts.Count; i++)
                {
                    var IndexOfANswer = splitInts[i];
                    IndexOfANswer--;
                    newQuiz.Answers[IndexOfANswer] += "*";
                }

            }
            while (!newQuiz.Answers[correctAnswerByIndex].Contains('*'));
        }

        public static void PrintAnswers(Quiz newQuiz)
        {
            for (int answers = 0; answers < newQuiz.Answers.Count(); answers++)
            {
                int indexToPrintForList = answers + 1;
                Console.WriteLine($"{indexToPrintForList}. {newQuiz.Answers[answers]}");
            }

        }

        public static string[] SplitAnswers()
        {
            string[] answerArray;
            do
            {
                Console.WriteLine("Enter Your Correct Answer by number:");
                Console.WriteLine("If multiple choices are correct, just input them like this: 1,2,3,4,5");
                string stringToSplit;


                answerArray = stringToSplit.Split(",");

                if (answerArray.Count() > GameLogic.MAXANSWERS)
                {
                    Console.WriteLine("Too many inputs, try again");
                }

            }
            while (answerArray.Count() > GameLogic.MAXANSWERS);

            return answerArray;
        }

        //public static void PlayQuiz(List<Quiz> quizList)
        //{
        //    Console.WriteLine("Each Correct guess is worth 1 point");

        //    Random OurRandom = new();
        //    List<int> ourrandomquestions = new();

        //    // decides how many questions we should be picking
        //    int counter = 5;

        //    // make a list of 5 ints to decide which questions we will ask, this represents the indexposition of that question.
        //    do
        //    {
        //        counter--;
        //        ourrandomquestions.Add(OurRandom.Next(quizList.Count));
        //    }
        //    while (counter > 0);

        //    foreach (int currentquestion in ourrandomquestions)
        //    {
        //        Console.WriteLine(quizList[currentquestion].ToString());
        //        GameLogic.CheckIfAnswerIsCorrect(quizList, currentquestion);

        //        PrintCurrentScore(GameLogic.currentScore);
        //    }

        //}

        public static void PrintOurQuizList(List<Quiz> quizList)
        {
            // Prints what quizzes we have so far
            foreach (var item in quizList)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public static void PrintCurrentScore(int currentScore)
        {
            Console.WriteLine($"Your Current Score is:{currentScore}");
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

        public static void InputWasntParsable()
        {
            Console.WriteLine("one of your input wasnt parsable.");
        }

    }
}