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
					Quiz newQuiz = UI.AddNewQuiz();

					UI.AddCorrectAnswer(newQuiz);
					quizList.Add(newQuiz);
				}

				else if (choice == 1) // play quiz
				{
					UI.OnePointPrint();

					List<int> ourrandomquestions = new();

					// decides how many questions we should be picking
					int counter = 5;

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

						bool wasTheAnswerCorrect = GameLogic.CheckIfAnswerIsCorrect(quizList[currentquestion], UI.ParseAnswer(Constants.MAXANSWERS));

						if (wasTheAnswerCorrect)
						{
							UI.ThatIsCorrectPrint();
							GameLogic.currentScore += Constants.ADDPOINTS;
						}
						else
						{
							UI.ThatisNotCorrectPrint();
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