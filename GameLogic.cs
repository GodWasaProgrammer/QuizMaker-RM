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
		
		public static bool CheckIfAnswerIsCorrect(Quiz quiz, List<int> listofIntAnswers)
		{
			bool wasTheAnswerCorrect = false;
			

			for (int i = 0; i < listofIntAnswers.Count; i++)
			{
				int answerByIndex = listofIntAnswers[i];
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

			return wasTheAnswerCorrect;
		}

	}
}