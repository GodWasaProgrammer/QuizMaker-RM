using System.Xml.Serialization;

namespace QuizMaker_RM
{
	public class Program
	{
		public static void Main()
		{
			List<Quiz> quizList = new List<Quiz>();

			// repopulates our quizlist from quizsheet.xml on program start
			quizList = GameLogic.ReadFromXML(quizList);

			// Welcome message
			UI.WelcomeMessage();

			do
			{
				// Menu Options
				UI.MenuPrint();

				// takes our input,parses it, returns a correct value
				int choice = UI.TakeMenuInput();

				if (choice == 0) // new quiz
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
							UI.AlreadyMarkedAsCorrectPrint();
						}

						if (newQuiz.Answers.Count + 1 > disAllowMoreCorrectAnswersThenAllButOne)
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
				}

				else if (choice == 1) // play quiz
				{
					UI.IfYouWinItsOnePointPrint();

					List<int> ourrandomquestions = new();

					// decides how many questions we should be picking
					int counter = Constants.NUMBEROFQUESTIONSTOBEASKED;

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
								Console.WriteLine("your input is too long. cant be more answers then the amount of answers minus one");
							}

						}
						while (answersToCheckIfCorrect.Length > quizList[currentquestion].Answers.Count - 1);

						List<int> parsedandWithinBoundsInt;

						foreach (string answerToParseAndEvaluate in answersToCheckIfCorrect)
						{
							parsedandWithinBoundsInt = UI.ParseAnswers(quizList[currentquestion], answersToCheckIfCorrect);
							bool wasTheAnswerCorrect;

							{
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

							}

						}

						UI.CurrentScorePrint(GameLogic.currentScore);
					}

				}

				else if (choice == 2)
				{
					UI.PrintOurQuizList(quizList);
				}

				else if (choice == 3)
				{
					// writes our questions into the XML
					GameLogic.WriteToXML(quizList);
					// exits
					Environment.Exit(0);
				}

			}
			while (true);

		}

	}

}