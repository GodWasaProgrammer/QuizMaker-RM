using System.Xml.Serialization;

namespace QuizMaker_RM
{
    internal class Program
    {
        static void Main()
        {

            var Quiz = new List<Quiz>();

            Quiz newQuiz = new();

            Console.WriteLine("Enter Your Quiz-Question:");
            newQuiz.quizQuestion = Console.ReadLine();

            Console.WriteLine("Enter Your First Answer");
            newQuiz.optionAnswer1 = Console.ReadLine();

            Console.WriteLine("Enter Your Second Answer:");
            newQuiz.optionAnswer2 = Console.ReadLine();

            Console.WriteLine("Enter Your Third Answer:");
            newQuiz.optionAnswer3 = Console.ReadLine();

            Console.WriteLine("Enter Your Correct Answer:");
            newQuiz.correctAnswer = Console.ReadLine();

            Quiz.Add(newQuiz);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            var path = "C:\\Users\\Björn\\source\\repos\\GodWasaProgrammer\\QuizMaker-RM/QuizSheet.xml";

            using (FileStream file = File.OpenRead(path))
            {
                serializer.Serialize(file, Quiz);
            }

            using (FileStream file = File.OpenRead(path))
            {
                Quiz = serializer.Deserialize(file) as List<Quiz>;
            }
            
            foreach (var item in Quiz)
            {
                Console.WriteLine(item);
            }
        }
    }
}