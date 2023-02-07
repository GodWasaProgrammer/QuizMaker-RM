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

			//// registers our inputs
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
			List<int> splitInts = new();

			string[] answerArray;
			do
			{
				UI.PrintAnswers(newQuiz);
				Console.WriteLine("Enter Your Correct Answer by number:");
				Console.WriteLine("If multiple choices are correct, just input them like this: 1,2,3,4,5");
				string stringToSplit = Console.ReadLine();

				answerArray = stringToSplit.Split(",");

				if (answerArray.Count() > Constants.MAXANSWERS)
				{
					Console.WriteLine("Too many inputs, try again");
				}

				int splittedStringToIntToList;

				foreach (string answer in answerArray)
				{
					bool isParsable = int.TryParse(answer, out splittedStringToIntToList);

					if (isParsable)
					{
						if (newQuiz.Answers.Contains(answer))
						{
							splitInts.Add(splittedStringToIntToList);
						}
						else
						{
							Console.WriteLine("That answer is not an option.");
							splitInts.Clear();
						}

					}
					else
					{
						UI.InputWasntParsablePrint();
						splitInts.Clear();
					}

				}

			}
			while (answerArray.Length != splitInts.Count);

			for (int i = 0; i < splitInts.Count; i++)
			{
				var IndexOfANswer = splitInts[i];
				IndexOfANswer--;
				newQuiz.Answers[IndexOfANswer] += "*";
			}

		}

		public static void PrintAnswers(Quiz newQuiz)
		{
			for (int answers = 0; answers < newQuiz.Answers.Count(); answers++)
			{
				int indexToPrintForList = answers + 1;
				Console.WriteLine($"{indexToPrintForList}. {newQuiz.Answers[answers]}");
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

		public static List<int> ParseAnswer(int MAXANSWER)
		{
			List<int> answersByIndex = new();

			PickAnswerByIndexPrint();

			string[] stringArray;

			bool isParsable = false;

			do
			{
				string multichoiceAnswer = Console.ReadLine();

				stringArray = multichoiceAnswer.Split(",");

				if (stringArray.Length > MAXANSWER)
				{
					Console.WriteLine("Sorry thats too many");
				}

				int parsecounter = stringArray.Length;

				foreach (string answerIndex in stringArray)
				{
					isParsable = int.TryParse(answerIndex, out int parsedNumber);

					if (isParsable)
					{
						answersByIndex.Add(parsedNumber);
						parsecounter--;
					}
					else
					{
						Console.WriteLine("Something wasnt parsable. try again.");
						isParsable = false;
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

		public static void OnePointPrint()
		{
			Console.WriteLine("Each Correct guess is worth 1 point");
		}

		public static void ThatisNotCorrectPrint()
		{
			Console.WriteLine("That is incorrect! No point!");
		}
	}
}