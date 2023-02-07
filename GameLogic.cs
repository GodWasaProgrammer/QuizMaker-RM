using System.Xml.Serialization;

namespace QuizMaker_RM
{
	public static class GameLogic
	{
		public const string PATH = "../../../QuizSheet.xml";
		static XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
		public static int currentScore = 0;
		public const int ADDPOINTS = 1;
		public const int MAXANSWERS = 5;
		public const int MINANSWERS = 2;

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
		
		public static bool CheckIfAnswerIsCorrect(Quiz quiz)
		{
			bool wasTheAnswerCorrect = false;
			List<int> answersByIndex = UI.ParseAnswer();

			for (int i = 0; i < answersByIndex.Count; i++)
			{
				int answerByIndex = answersByIndex[i];
				answerByIndex--;

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