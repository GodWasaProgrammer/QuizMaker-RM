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

		public static List<Quiz> ReadFromXML()
		{
			List<Quiz> quizList = new();

			using (FileStream file = File.OpenRead(PATH))
			{
				quizList = serializer.Deserialize(file) as List<Quiz>;
			}

			return quizList;
		}
		// supports multiple answers as correct
		public static bool CheckIfAnswerIsCorrect(Quiz quiz, List<int> currentAnswerToCheckIfCorrect)
		{
            bool wasTheAnswerCorrect = false;
			
			foreach (int answer in currentAnswerToCheckIfCorrect)
			{
				if (answer < quiz.Answers.Count)
				{
					int answerByIndex = answer;

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
			}

			// should always pass first if
            

            return wasTheAnswerCorrect;
		}

        public static void AddPoints()
		{
            currentScore += Constants.ADD_POINTS;
        }
		
	}
}