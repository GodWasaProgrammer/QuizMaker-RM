using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public class Program
    {
        public static int currentScore = 0;
        public const int AddPoints = 1;

        static void Main()
        {
            var quizList = new List<Quiz>();

            // our serializer to read/write material to our QuizSheet
            XmlSerializer serializer = new(typeof(List<Quiz>));

            var path = "../../../QuizSheet.xml";

            // repopulates our quizlist from quizsheet.xml on program start
            quizList = GameLogic.ReadFromXML(path, serializer, quizList);

            // Welcome message
            UI.WelcomeMessage();

            UI.Menu(quizList);

            GameLogic.WriteToXML(path, serializer, quizList);

        }

    }

}