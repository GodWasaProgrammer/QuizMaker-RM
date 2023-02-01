using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public class Program
    {

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

                if (choice == 0)
                {
                    UI.AddNewQuiz(quizList);
                }

                if (choice == 1)
                {
                    UI.DoYouWishToPlay(quizList);
                }

                if (choice == 2)
                {
                    UI.PrintOurQuizList(quizList);
                }

                if (choice == 3)
                {
                    // writes our questions into the XML
                    GameLogic.WriteToXML(quizList);
                    // exits
                    Environment.Exit(0);
                }
                

            } while (true);

        }

    }

}