namespace QuizMaker_RM
{
    public class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Our Quiz Maker!");
            Console.WriteLine("This Software allows you to make your own quiz!");
        }
        public static string ReturnOneAnswer()
        {
            //// registers our inputs
            int numberOfSuffixToPrint = 0;
            string input;
            do
            {
                Console.WriteLine($"Enter Your Answer");


                input = Console.ReadLine();

                if (input == string.Empty || input == null)
                {
                    numberOfSuffixToPrint--;
                    Console.WriteLine("You have to type an answer.");
                }


            }
            while (input == string.Empty || input == null);

            return input;
        }
        public static int AmountOfAnswers()
        {

            int amountOfAnswers;
            bool didItParse;

            do
            {    // takes answers
                Console.WriteLine("Input your amount of answers");

                didItParse = int.TryParse(Console.ReadLine(), out amountOfAnswers);

                if (amountOfAnswers < Constants.MINANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"You have to put {Constants.MINANSWERS} or more answers for a question");
                }

                if (amountOfAnswers > Constants.MAXANSWERS)
                {
                    didItParse = false;
                    Console.WriteLine($"Too many answers. needs to be less then {Constants.MAXANSWERS}");
                }

            }
            while (didItParse == false);

            return amountOfAnswers;
        }

        public static string AddNewQuestion()
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

        public static int TakeOneCorrectAnswerAndParse(Quiz newQuiz)
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

            return answer;
        }

        public static void PrintAnswers(Quiz newQuiz)
        {
            for (int answers = 0; answers < newQuiz.Answers.Count(); answers++)
            {
                Console.WriteLine($"{answers+1}. {newQuiz.Answers[answers]}");
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

        public static void CurrentScorePrint(int currentScore)
        {
            Console.WriteLine($"Your Current Score is:{currentScore}");
        }

        public static int TakeMenuInput()
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

                if (choice > Constants.MAXMENUCHOICE)
                {
                    Console.WriteLine("Incorrect Choice");
                    didItParse = false;
                }

            }
            while (didItParse == false);

            return choice;

        }

        public static List<int> ParseAnswer(Quiz currentQuiz)
        {
            List<int> answersByIndex = new();

            PickAnswerByIndexPrint();

            string[] stringArray;

            bool isParsable = false;

            do
            {
                string multichoiceAnswer = Console.ReadLine();

                stringArray = multichoiceAnswer.Split(",");

                if (stringArray.Length >= currentQuiz.Answers.Count)
                {
                    Console.WriteLine("Sorry thats too many"); // bool too many?
                }

                if (stringArray.Length < currentQuiz.Answers.Count)
                {
                    int parsecounter = stringArray.Length;
                    foreach (string answerIndex in stringArray)
                    {
                        isParsable = int.TryParse(answerIndex, out int parsedNumber);

                        if (isParsable)
                        {
                            if (parsedNumber < currentQuiz.Answers.Count)
                            {
                                answersByIndex.Add(parsedNumber);
                                parsecounter--;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid choice. your input will be disregarded.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Something wasnt parsable. try again.");
                            isParsable = false;
                        }

                    }

                }
            }
            while (isParsable == false);

            return answersByIndex;
        }

        public static void MenuPrint()
        {
            Console.WriteLine("Menu:\n1.Add a New Quiz! \n2.Play A round of Quiz \n3.Print All questions \n4.Exit Software");
        }

        public static void PickAnswerByIndexPrint()
        {
            Console.WriteLine("Pick your answer by index");
        }

        public static void ThatIsCorrectPrint()
        {
            Console.WriteLine("That is Correct!");
        }
        public static void InputWasntParsablePrint()
        {
            Console.WriteLine("one of your input wasnt parsable.");
        }

        public static void IfYouWinItsOnePointPrint()
        {
            Console.WriteLine("Each Correct guess is worth 1 point");
        }

        public static void ThatisNotCorrectPrint()
        {
            Console.WriteLine("That is incorrect! No point!");
        }

        public static void AlreadyMarkedAsCorrectPrint()
        {
            Console.WriteLine("This answer was already marked as the correct one");
        }

        public static void AddAnotherAnswerPrint()
        {
            Console.WriteLine("Would you like to add another correct answer?\n if so enter y");
        }
    }
}