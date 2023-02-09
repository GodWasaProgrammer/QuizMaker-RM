namespace QuizMaker_RM
{
    public class Program
    {
        public static void Main()
        {
            // repopulates our quizlist from quizsheet.xml on program start
            List<Quiz> quizList = GameLogic.ReadFromXML();

            // Welcome message
            UI.WelcomeMessage();
            do
            {
                // Menu Options
                UI.MenuPrint();

                // takes our input,parses it, returns a correct value
                int choice = UI.TakeMenuInput();

                switch (choice)
                {
                    case 0:
                        {
                            Quiz newQuiz = new();

                            // add our question to quiz object
                            newQuiz.quizQuestion = UI.AddNewQuestion();

                            // returns how many answers we have chosen
                            int amountOfAnswers = UI.AmountOfAnswers();

                            // loops to fill our answers
                            for (int answer = 0; answer < amountOfAnswers; answer++)
                            {
                                newQuiz.Answers.Add(UI.ReturnOneAnswer());
                            }

                            int disAllowMoreCorrectAnswersThenAllButOne = newQuiz.Answers.Count;

                            do
                            {
                                int correctAnswerChosen = UI.TakeOneCorrectAnswerAndParse(newQuiz);
                                correctAnswerChosen--;

                                if (!newQuiz.Answers[correctAnswerChosen].Contains("*"))
                                {
                                    newQuiz.Answers[correctAnswerChosen] += "*";
                                    UI.MarkedasCorrectAnswerPrint();
                                }
                                else
                                {
                                    UI.AlreadyMarkedAsCorrectPrint();
                                }

                                // disallows more correct answers then answers count minus one, so all can be correct but one
                                if (newQuiz.Answers.Count - 1 < disAllowMoreCorrectAnswersThenAllButOne)
                                {
                                    break;
                                }
                                else
                                {
                                    UI.AddAnotherAnswerPrint();
                                }

                            }
                            while (Console.ReadLine() == "y");

                            quizList.Add(newQuiz);

                            // writes our questions into the XML
                            GameLogic.WriteToXML(quizList);

                            break;
                        }
                    case 1:
                        {
                            UI.IfYouWinItsOnePointPrint();

                            List<int> ourrandomquestions = new();

                            // decides how many questions we should be picking
                            int counter = Constants.QUESTION_COUNT;

                            // make a list of 5 ints to decide which questions we will ask, this represents the indexposition of that question.
                            do
                            {
                                Random OurRandom = new();

                                int ourIntForList = OurRandom.Next(quizList.Count);
                                // if randomed int isnt in the list already, do this
                                if (!ourrandomquestions.Contains(ourIntForList))
                                {
                                    ourrandomquestions.Add(ourIntForList);
                                    counter--;
                                }

                            }
                            while (counter > 0);

                            foreach (int currentquestion in ourrandomquestions)
                            {
                                Console.WriteLine(quizList[currentquestion].ToString());
                                string[] answersToCheckIfCorrect;
                                do
                                {
                                    answersToCheckIfCorrect = UI.ReadAnswer(quizList[currentquestion]);

                                    if (answersToCheckIfCorrect.Length > quizList[currentquestion].Answers.Count - 1)
                                    {
                                        UI.InputTooLongPrint();
                                    }

                                    if (answersToCheckIfCorrect.Contains(Constants.MIN_GUESS_STRING))
                                    {
                                        UI.InputofZeroNotAllowed();
                                    }

                                } // disallows answers of 0, and also multistring answers who is more then amount of answers, and also sets max answers to amount of answers minus one
                                while (answersToCheckIfCorrect.Length > quizList[currentquestion].Answers.Count - 1 || answersToCheckIfCorrect.Contains(Constants.MIN_GUESS_STRING));

                                List<int> parsedandWithinBoundsInt = null;

                                parsedandWithinBoundsInt = UI.ParseAnswers(quizList[currentquestion], answersToCheckIfCorrect);
                                // parse, point and evaluation to check if your answer is correct

                                bool wasTheAnswerCorrect;

                                wasTheAnswerCorrect = GameLogic.CheckIfAnswerIsCorrect(quizList[currentquestion], parsedandWithinBoundsInt);

                                if (wasTheAnswerCorrect)
                                {
                                    UI.ThatIsCorrectPrint();
                                    GameLogic.AddPoints();
                                }
                                else
                                {
                                    UI.ThatisNotCorrectPrint();
                                }

                                parsedandWithinBoundsInt.Clear();
                                UI.CurrentScorePrint(GameLogic.currentScore);

                            }
                            break;

                        }
                    case 2:
                        {
                            UI.PrintOurQuizList(quizList);
                            break;
                        }
                    case 3:
                        {
                            // exits
                            return;
                        }
                }
            } while (true);
        }
    }
}



