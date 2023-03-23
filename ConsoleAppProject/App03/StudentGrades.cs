using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public const int LowerGrade = 0;
        public const int LowerGradeD = 40;
        public const int LowerGradeC = 50;
        public const int lowerGardeB = 60;
        public const int LowerGradeA = 70;
        public const int HighestMark = 100;
        public double LowestMark;
        private int mark;

        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public object StudentClass { get; private set; }

        public void Run()
        {
            DisplayMenu();
            //InputMarks();
        }
        public StudentGrades()
        {
            Students = new string[]
            {
                "Luke", "Euan", "Munir", "Qasim", "JoySon",
                "Keegan","Muhammad","Hamza","mike","justin",

            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Input Marks");
            Console.WriteLine("2. Output Marks");
            Console.WriteLine("3. OutputStats Mark");
            Console.WriteLine("4. Output Grade Profile");
            Console.WriteLine("5. Quit");

            int selection = 0;
            bool isValidSelection = false;

            while (!isValidSelection)
            {
                Console.Write("Enter your selection: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out selection))
                {
                    if (selection >= 1 && selection <= 5)
                    {
                        isValidSelection = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a number between 1 and 5.");
                    }
                }
            }

            switch (selection)
            {
                case 1:
                    InputMarks();
                    break;
                case 2:
                    OutputMarks();
                    break;
                case 3:
                    CalculateStats();
                    OutputStats();
                    break;
                case 4:
                    OutputGradeProfile();
                    break;
                case 5:
                    //Quit
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
            }
        }

        public void InputMarks()
        {
            ConsoleHelper.OutputHeading("Please Enter Mark for Each Student");


            for (int i = 0; i < Students.Length; i++)
                
            {
                bool validInput = false;
                int mark = 0;
                while (!validInput)
                {
                    Console.Write($"Enter mark for {Students[i]};");
                    string input = Console.ReadLine();

                    if(!int.TryParse(input, out mark))
                    {
                        Console.WriteLine("as");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                
                Marks[i] = mark;
            }
            Console.WriteLine();
            ConsoleHelper.OutputHeading("Students Marks System");
            
            DisplayMenu();
        }

          public void UpdateGradeProfile(int mark)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// list all the studentsstudent and Display their
        /// name and current mark 
        /// </summary>

        public void OutputMarks()
            {
                ConsoleHelper.OutputHeading("The each Student Marks");

                for (int i = 0; i < Students.Length; i++)
                {
                    int mark = Marks[i];
                    Grades grades = ConvertToGrade(mark);
                    Console.WriteLine($"Student Name: {Students[i]} \tStudent Mark: {mark}\t" +
                        $"Student Grade: {grades}\tStudent Class: {StudentClass}\t");
                }
                Console.WriteLine();
                ConsoleHelper.OutputHeading("\t\t Student Marks System");
                DisplayMenu();
            }

        

        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < LowerGradeD)
            {
                StudentClass = "Refered";
                return Grades. F;
            }

            else if (mark >= LowerGradeD && mark < LowerGradeC)
            {
                StudentClass = "Lower Grade";
                return Grades.D;
            }
            else if (mark >= LowerGradeC && mark < lowerGardeB)
            {
                StudentClass = "Pass";
                return Grades. C;
            }
            else if (mark >= lowerGardeB && mark < LowerGradeA)
            {
                StudentClass = "Upper Second";
                return Grades. B;
            }
            else if (mark >= LowerGradeA && mark <= HighestMark)
            {
                StudentClass = "First Class";
                return Grades. A;
            }
            return Grades. F;
  
        }

        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach (int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
                total += mark;
            }

            Mean = total / Marks.Length;
            OutputStats();
            DisplayMenu();
        }


        public void OutputStats()
        {

            double overallMean = Mean;
            Console.WriteLine($"Mean: {overallMean.ToString("F")}");

            int minimumMark = Minimum;
            Console.WriteLine($"Minimum mark: {minimumMark}");

            int maximumMark = Maximum;
            Console.WriteLine($" Maximum mark: {maximumMark}");
        }


        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }
            foreach(int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

            //OutputGradeProfile();
            DisplayMenu();
        }

        public void OutputGradeProfile()
        {
            int[] gradeCounts = new int[5];
            int highestMark = 0;
            int lowestMark = 100;
            // Calculate grade counts, highest mark, and lowest mark
            foreach (int mark in Marks)
            {
                if (mark >= LowerGradeA)
                {
                    gradeCounts[4]++;
                    if (mark > highestMark) highestMark = mark;
                    if (mark < lowestMark) lowestMark = mark;
                }
                else if (mark >= lowerGardeB)
                {
                    gradeCounts[3]++;
                    if (mark < lowestMark) lowestMark = mark;
                }
                else if (mark >= LowerGradeC)
                {
                    gradeCounts[2]++;
                    if (mark < lowestMark) lowestMark = mark;
                }
                else if (mark >= LowerGradeD)
                {
                    gradeCounts[1]++;
                    if (mark < lowestMark) lowestMark = mark;
                }
                else
                {
                    gradeCounts[0]++;
                    if (mark < lowestMark) lowestMark = mark;
                }
            }

           
            
                int total = gradeCounts.Sum();
                Console.WriteLine($"A Grade: {gradeCounts[4]} {(double)gradeCounts[4] / total:P}");
                Console.WriteLine($"B Grade: {gradeCounts[3]} {(double)gradeCounts[3] / total:P}");
                Console.WriteLine($"C Grade: {gradeCounts[2]} {(double)gradeCounts[2] / total:P}");
                Console.WriteLine($"D Grade: {gradeCounts[1]} {(double)gradeCounts[1] / total:P}");
                Console.WriteLine($"F Grade: {gradeCounts[0]} {(double)gradeCounts[0] / total:P}");
            
            DisplayMenu();
        }
       

    }

}
