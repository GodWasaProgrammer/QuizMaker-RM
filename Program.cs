using System.Xml;
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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

            // our pathing, i want it to be relative to our build folder, but i cant figure it out
            var path = "../../../QuizSheet.xml";

            // repopulates our quizlist from quizsheet.xml on program start
            quizList = GameLogic.ReadFromXML(path, serializer, quizList);

            // Welcome message
            UI.WelcomeMessage();

            Console.WriteLine("Do you wanna add another quiz question? if so type y");
            if(Console.ReadLine() == "y")
            {
                do
                {
                    UI.AddNewQuiz(quizList);
                    Console.WriteLine("You wanna add another?");
                }

                while (Console.ReadLine() == "y");
            }
            

            GameLogic.WriteToXML(path, serializer, quizList);

            UI.DoYouWishToPlay(quizList);

        }
    }
}