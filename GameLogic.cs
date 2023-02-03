using System.Security.Cryptography.X509Certificates;
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
            List<int> answersByIndex = GameLogic.ParseAnswer();

            for (int i = 0; i < answersByIndex.Count; i++)
            {

                int answerByIndex = answersByIndex[i];
                answerByIndex--;

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

        public static void CheckIfQuestionStringIsEmpty(Quiz newQuiz)
        {
            if (newQuiz.quizQuestion == string.Empty)
            {
                UI.PrintStringEmpty();
            }
        }

        public static List<int> ParseAnswer()
        {
            List<int> answersByIndex = new();

            UI.PickAnswerByIndexPrint();

            string multichoiceAnswer = Console.ReadLine();
            string[] stringArray;
            stringArray = multichoiceAnswer.Split(",");

            foreach (string answerIndex in stringArray)
            {
                answersByIndex.Add(int.Parse(answerIndex));

            }

            return answersByIndex;
        }

        public static void AddAsterisksToAnswers(Quiz newQuiz, List<int> splitInts)
        {
            for (int i = 0; i < splitInts.Count; i++)
            {
                var IndexOfANswer = splitInts[i];
                IndexOfANswer--;
                newQuiz.Answers[IndexOfANswer] += "*";
            }
        }

        public static void InputWrapper(Quiz newQuiz, int amountOfAnswers)
        {
            // registers our inputs
            UI.HandleAndAddAnswers(newQuiz, amountOfAnswers);

            int correctAnswerByIndex = 0;
            List<int> splitInts = new();
            do
            {
                UI.PrintAnswers(newQuiz);

                bool isParsable = false;
                do
                {
                    string[] answerArray = UI.SplitAnswers();
                    isParsable = WriteSplitIntsToAnswers(splitInts, isParsable, answerArray);
                }
                while (isParsable == false);

                AddAsterisksToAnswers(newQuiz, splitInts);

            }
            while (!newQuiz.Answers[correctAnswerByIndex].Contains('*'));
        }

        public static bool WriteSplitIntsToAnswers(List<int> splitInts, bool isParsable, string[] answerArray)
        {
            int splittedStringToIntToList;
            foreach (string answer in answerArray)
            {
                isParsable = int.TryParse(answer, out splittedStringToIntToList);

                if (isParsable)
                {
                    splitInts.Add(splittedStringToIntToList);
                }
                else
                {
                    UI.InputWasntParsable();
                }

            }

            return isParsable;
        }
    }
}