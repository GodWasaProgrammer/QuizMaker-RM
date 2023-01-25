﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            Random OurRandom = new Random();
            List<int> ourrandomquestions = new List<int>();

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

        public static void PrintOurFiveQuestions(List<Quiz> quizList)
        {
            List<int> ourfivequestions = new List<int>();
            ourfivequestions = GameLogic.PickFiveQuestions(quizList);

            foreach (int currentquestion in ourfivequestions)
            {
                Console.WriteLine(quizList[currentquestion].ToString());
                Console.WriteLine("Pick your answer.");

                string yourAnswer = Console.ReadLine();

                if (yourAnswer == quizList[currentquestion].correctAnswer)
                {
                    Console.WriteLine("That is Correct!");
                    Program.currentScore += Program.AddPoints;
                }

                else
                {
                    Console.WriteLine("That is not correct...");
                }

                UI.PrintCurrentScore(Program.currentScore);
            }

        }

    }
}
