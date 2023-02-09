namespace QuizMaker_RM
{
    public class UI
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Our Quiz Maker!");
            Console.WriteLine("This Software allows you to make your own quiz!");
        }
        public static string ReadAnswer()
        {
            string input;

            do
            {
                Console.WriteLine($"Enter Your Answer");


                input = Console.ReadLine();

                if (input == string.Empty || input == null)
                {
                    Console.WriteLine("You have to type an answer.");
                }


            }
            while (input == string.Empty || input == null);

            return input;
        }
        public static int ReadAmountOfAnswers()
        {

            int amountOfAnswers;
            bool didItParse;

            do
            {    // takes answers
                Console.WriteLine("Input your amount of answers");

                didItParse = int.TryParse(Console.ReadLine(), out amountOfAnswers);

                if (amountOfAnswers < Constants.MIN_ANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"You have to put {Constants.MIN_ANSWERS} or more answers for a question");
                }

                if (amountOfAnswers > Constants.MAX_ANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"Too many answers. needs to be less then {Constants.MAX_ANSWERS}");
                }

            }
            while (didItParse == false);

            return amountOfAnswers;
        }

        public static string ReadNewQuestion()
        {
            string input;
            do
            {
                Console.WriteLine("Enter Your Quiz-Question:");
                input = Console.ReadLine();

                if (input == string.Empty)
                {
                    Console.WriteLine("You have to type a question.");
                }

            }
            while (input == string.Empty);

            return input;
        }

        public static int ReadCorrectAnswerAndParse(Quiz newQuiz)
        {
            int answer;
            bool isParsable;
            do
            {
                string input;

                UI.PrintAnswers(newQuiz);

                Console.WriteLine("Enter Your Correct Answer by number:");

                input = Console.ReadLine();

                isParsable = int.TryParse(input, out answer);

                if (answer > newQuiz.Answers.Count)
                {
                    Console.WriteLine("That answer doesnt exist. try again");
                }

                if (isParsable == false)
                {
                    Console.WriteLine("That isnt a number. try again");
                }

            }
            while (answer > newQuiz.Answers.Count || isParsable == false);

            answer--;
            return answer;
        }

        public static void PrintAnswers(Quiz newQuiz)
        {
            for (int answers = 0; answers < newQuiz.Answers.Count(); answers++)
            {
                Console.WriteLine($"{answers + 1}. {newQuiz.Answers[answers]}");
            }

        }

        public static string ReadMenuChoice()
        {
            string choice = Console.ReadLine();

            return choice;
        }

        public static void PrintQuizList(List<Quiz> quizList)
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

        public static int ReadMenuInput()
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

                if (choice > Constants.MAX_MENU_CHOICE)
                {
                    Console.WriteLine("Incorrect Choice");
                    didItParse = false;
                }

            }
            while (didItParse == false);

            return choice;

        }

        public static void PrintCurrentQuizObject(Quiz currentQuizObject)
        {
            Console.WriteLine(currentQuizObject.ToString());
        }

        public static List<int> ParseAnswers(Quiz currentQuiz, string[] StringArray)
        {
            List<int> parsedandWithinBoundsIntegerIndexList = new();

            foreach (string AnswerToParse in StringArray)
            {
                bool isParsable = int.TryParse(AnswerToParse, out int parsedNumber);

                // if we managed to parse it
                if (isParsable)
                {
                    if (parsedNumber > 0)
                    {
                        parsedNumber--;
                    }

                    // and our number doesnt exceed the count of currentquiz.answers
                    if (parsedNumber < currentQuiz.Answers.Count)
                    {
                        // and our answer is matched to a indexposition in answers

                        if (currentQuiz.Answers.IndexOf(currentQuiz.Answers[parsedNumber]) == parsedNumber)
                        {
                            if (!parsedandWithinBoundsIntegerIndexList.Contains(parsedNumber))
                            {
                                parsedandWithinBoundsIntegerIndexList.Add(parsedNumber);
                            }
                            else
                            {
                                Console.WriteLine("Duplicate entries are not allowed.");
                            }

                        }

                    }

                }
                else
                {
                    Console.WriteLine($"your input of {AnswerToParse} is not parsable or of an invalid value and will be discarded");
                }

            }

            return parsedandWithinBoundsIntegerIndexList;
        }

        public static string[] ReadAnswer(Quiz currentQuiz)
        {
            string[] stringArray;

            Console.WriteLine("Pick your answer by index");

            string multichoiceAnswer = Console.ReadLine();

            stringArray = multichoiceAnswer.Split(",");

            return stringArray;
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Menu:\n1.Add a New Quiz! \n2.Play A round of Quiz \n3.Print All questions \n4.Exit Software");
        }

        public static void PrintThatIsCorrect()
        {
            Console.WriteLine("That is Correct!");
        }

        public static void PrintOnePointToWin()
        {
            Console.WriteLine("Each Correct guess is worth 1 point");
        }

        public static void PrintThatIsNotCorrect()
        {
            Console.WriteLine("That is incorrect! No point!");
        }

        public static void PrintAlreadyMarkedAsCorrect()
        {
            Console.WriteLine("This answer was already marked as the correct one");
        }

        public static void PrintAddAnotherAnswer()
        {
            Console.WriteLine("Would you like to add another correct answer?\n if so enter y");
        }

        public static void PrintMarkedasCorrectAnswer()
        {
            Console.WriteLine("Your answer has been marked as the correct one.");
        }

        public static void PrintInputTooLong()
        {
            Console.WriteLine("your input is too long. cant be more answers then the amount of answers minus one");
        }

        public static void PrintNotAllowed()
        {
            Console.WriteLine("Input of 0 is not allowed.");
        }
    }
}