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

        public static List<int> PickFiveQuestions(List<Quiz> quizList)
        {
            Random OurRandom = new();
            List<int> ourrandomquestions = new();

            // decides how many questions we should be picking
            int counter = 5;

            // make a list of 5 ints to decide which questions we will ask, this represents the indexposition of that question.
            do
            {
                counter--;
                ourrandomquestions.Add(OurRandom.Next(quizList.Count));
            }
            while (counter > 0);

            return ourrandomquestions;
        }

        public static void CheckIfAnswerIsCorrect(List<Quiz> quizList, int currentquestion)
        {
            int answerByIndex = UI.ParseAnswer();

            if (quizList[currentquestion].Answers[answerByIndex].Contains('*'))
            {
                UI.ThatIsCorrectPrint();
                currentScore += ADDPOINTS;
            }
            else
            {
                UI.ThatisNotCorrectPrint();
            }

        }

        public static void CheckIfParseSuccess(int answerByIndex, bool didItParse)
        {
            if (answerByIndex > 2)
            {
                UI.CanOnlyPickBetweenOneAndThreePrint();
            }

            if (didItParse == false)
            {
                UI.NotAbleToParsePrint();
            }

        }
    }
}