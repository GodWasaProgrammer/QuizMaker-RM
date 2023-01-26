﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker_RM
{
    public class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Our Quiz Maker!");
            Console.WriteLine("This Software allows you to make your own quiz!");
        }
        public static void AddNewQuiz(List<Quiz> quizList)
        {
            Quiz newQuiz = new();

            do
            {
                Console.WriteLine("Enter Your Quiz-Question:");
                newQuiz.quizQuestion = Console.ReadLine();
            }
            while (newQuiz.quizQuestion == null);

            do
            {
                Console.WriteLine("Enter Your First Answer");
                newQuiz.optionAnswer1 = Console.ReadLine();
            }
            while (newQuiz.optionAnswer1 == null);

            do
            {
                Console.WriteLine("Enter Your Second Answer:");
                newQuiz.optionAnswer2 = Console.ReadLine();
            }
            while (newQuiz.optionAnswer2 == null);

            do
            {
                Console.WriteLine("Enter Your Third Answer:");
                newQuiz.optionAnswer3 = Console.ReadLine();
            }
            while (newQuiz.optionAnswer3 == null);

            do
            {
                Console.WriteLine("Enter Your Correct Answer:");
                newQuiz.correctAnswer = Console.ReadLine();
            }//change for !contains?
            while (newQuiz.correctAnswer != newQuiz.optionAnswer1 && newQuiz.correctAnswer != newQuiz.optionAnswer2 && newQuiz.correctAnswer != newQuiz.optionAnswer3);

            if (newQuiz.quizQuestion != string.Empty && newQuiz.optionAnswer1 != string.Empty && newQuiz.optionAnswer2 != string.Empty && newQuiz.optionAnswer3 != string.Empty && newQuiz.correctAnswer != string.Empty)
            {
                quizList.Add(newQuiz);
            }

        }

        public static void DoYouWishToPlay(List<Quiz> quizList)
        {
            Console.WriteLine("Do you wish to play our Quiz?");
            Console.WriteLine("If so, 5 randomly selected questions will be selected and presented to you");
            Console.WriteLine("Each Correct guess is worth 10 points");
            Console.WriteLine("enter y to play");

            if (Console.ReadLine() == "y")
            {
                GameLogic.PrintOurFiveQuestions(quizList);
            }
            else
            {
                Console.WriteLine("You Chose not to play!");
            }

        }

        public static void PrintOurQuizList(List<Quiz> quizList)
        {
            // Prints what quizzes we have so far
            foreach (var item in quizList)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintCurrentScore(int currentScore)
        {
            Console.WriteLine($"Your Current Score is:{currentScore}");
        }

    }
}