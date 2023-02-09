using System.Xml.Serialization;

namespace QuizMaker_RM
{
	public static class GameLogic
	{
		public const string PATH = "../../../QuizSheet.xml";
		static XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
        public static int currentScore = 0;
		
        public static void WriteToXML(List<Quiz> quizList)
		{
			// writes our written quiz to our xml QuizSheet.xml
			using (FileStream file = File.OpenWrite(PATH))
			{
				serializer.Serialize(file, quizList);
			}

		}

		public static List<Quiz> ReadFromXML(List<Quiz> quizList)
		{
			using (FileStream file = File.OpenRead(PATH))
			{
				quizList = serializer.Deserialize(file) as List<Quiz>;
			}

			return quizList;
		}
		// supports multiple answers as correct
		public static bool CheckIfAnswerIsCorrect(Quiz quiz, int currentAnswerToCheckIfCorrect)
		{
            bool wasTheAnswerCorrect = false;
			
			// should always pass first if
            if (currentAnswerToCheckIfCorrect < Constants.MAXIMUMACCEPTABLEANSWERCHOICE)
			{ 
				int answerByIndex = currentAnswerToCheckIfCorrect;
				if (answerByIndex != 0)
				{ 
				answerByIndex--;
                }
                if (quiz.Answers[answerByIndex].Contains('*'))
				{
					wasTheAnswerCorrect = true;
				}
				else
				{
					wasTheAnswerCorrect = false;
				}

            }
			else
			{
				throw new ArgumentOutOfRangeException("Parameter is out of range.");
			}

            return wasTheAnswerCorrect;
		}

        public static void AddPoints()
		{
            currentScore += Constants.ADDPOINTS;
        }
		public static List<int> EvaluateIfInputIsValid(Quiz currentQuiz , string[] stringArray)
		{
			bool isParsable = false;
            List<int> answersByIndex = new();

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
                    }

                }

            }

			return answersByIndex;
        }
	}
}