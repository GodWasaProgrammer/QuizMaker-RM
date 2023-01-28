﻿using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public static class GameLogic
    {
        public static void WriteToXML(string path, XmlSerializer serializer, List<Quiz> quizList)
        {
            // writes our written quiz to our xml QuizSheet.xml
            using (FileStream file = File.OpenWrite(path))
            {
                serializer.Serialize(file, quizList);
            }

        }

        public static List<Quiz> ReadFromXML(string path, XmlSerializer serializer, List<Quiz> quizList)
        {
            using (FileStream file = File.OpenRead(path))
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
            int answerByIndex = UI.CheckIfAnswerIsInAnswers();

            if (quizList[currentquestion].Answers[answerByIndex].Contains('*'))
            {
                Console.WriteLine("That is Correct!");
                Program.currentScore += Program.AddPoints;
            }
            else
            {
                Console.WriteLine("That is not correct...");
            }

        }

    }
}