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

            var path = "../../../QuizSheet.xml";

            // repopulates our quizlist from quizsheet.xml on program start
            quizList = GameLogic.ReadFromXML(path, serializer, quizList);

            // Welcome message
            UI.WelcomeMessage();

            while (true)
            {
                Console.WriteLine("Menu:\n1.Add a New Quiz! \n2.Play A round of Quiz \n3.Print All questions \n4.Exit Software");
                switch (Console.ReadLine())
                {
                    case "1":
                        UI.AddNewQuiz(quizList);
                        break;
                    case "2":
                        UI.DoYouWishToPlay(quizList);
                        break;
                    case "3":
                        UI.PrintOurQuizList(quizList);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not an Option, try again!");
                        break;
                }
                GameLogic.WriteToXML(path, serializer, quizList);

            }

        }

    }
}