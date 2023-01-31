using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public class Program
    {
        public static int currentScore = 0;
        public const int AddPoints = 1;

        public static void Main()
        {
            List<Quiz> quizList = new List<Quiz>();

            // our serializer to read/write material to our QuizSheet
            XmlSerializer serializer = new(typeof(List<Quiz>));

            // repopulates our quizlist from quizsheet.xml on program start
            quizList = GameLogic.ReadFromXML(quizList);

            // Welcome message
            UI.WelcomeMessage();

            do
            {
                // Menu Options
                UI.MenuPrint();

                // takes our input,parses it, returns a correct value
                int choice = UI.TakeInput();

                // puts that choice into MenuSelect
                GameLogic.MenuSelect(choice, quizList);

            } while (true);

        }

    }

}