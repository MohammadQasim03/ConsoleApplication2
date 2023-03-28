using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// </summary>
    public static class Program
    {
        private static DistanceConverter converter = new DistanceConverter();

        private static BMICalulator = new BMI();

        private static StudentGrades grades = new StudentGrades();

        private static NetwrokApp App04= new NetwrokApp();

        public static BMI BMI
        {
            get => default;
        }

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleHelper.OutputHeading("BNI C0453 2022!");

            string[] choices = {"Distance Converter", "BMI Calcultor", "Student Marks",
            "Social Network"};

            int choiceNo = ConsoleHelper.SelectChoice(choices);

            if (choiceNo == 1)
            {
                converter.ConvertDistance();
            }
            else if (choiceNo == 2)
            {
                Calulator.CalculateIndex();
            }
            else if (choiceNo == 3)
            {
                App04.DisplayMenu();
            }
            else if (choiceNo == 4)
            {
                else Console.WriteLine("Invalid choice!");
            }
        }
    }
}
