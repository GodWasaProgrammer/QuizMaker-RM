using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public class Program
    {
        public static int currentScore = 0;
        public const int AddPoints = 10;
        static void Main()
        {
            var quizList = new List<Quiz>();

            // our serializer to read/write material to our QuizSheet
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

            // our pathing, i want it to be relative to our build folder, but i cant figure it out
            var path = @"C:\Users\vemha\Desktop\Bearworks\Bearworks\Software\QuizMaker RM\QuizSheet.xml";

            // repopulates our quizlist from quizsheet.xml on program start
            quizList = GameLogic.ReadFromXML(path, serializer, quizList);

            // Welcome message
            UI.WelcomeMessage();

            do
            {
                UI.AddNewQuiz(quizList);
                Console.WriteLine("You wanna add another?");
            }
            
            while (Console.ReadLine() == "y");

            GameLogic.WriteToXML(path, serializer, quizList);

            //UI.PrintOurQuizList(quizList);

            UI.DoYouWishToPlay(quizList);

        }
    }
}