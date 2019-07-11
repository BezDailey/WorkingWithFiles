using System;
using System.IO;
using static System.Console;

/*
 * Write an application that retrieves both string data and numbers from a text file.
 * Test your solution by retrieving names of students and three scores per line from
 * a text file. Process the values by calculating the average score per student. Write
 * the name and average to a different text file. Display on the console screen what is
 * being writen to the new file. Test your application with a minimum of eight records
 * in the original file. Hint: You might consider adding delimiters between the 
 * data values in the original text file to simplify retrieving and processing the 
 * data. Include appropriate exception-handling techniques in your solution. When
 * the application closes, locate the text file and verify its contents
 * 
 * Author: Jabez Dailey
 * Date: 7/20/2019
 */

namespace Project7Chapter13
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateStudentFile();
            ReadStudentFile();
            CreateStudentAverageFile();
            ReadAverageFile();
        }

        static void CreateStudentFile()
        {
            try
            {
                StreamWriter filStudent;
                filStudent = new StreamWriter("Students.txt");
                filStudent.WriteLine("Jabez 100 100 100");
                filStudent.WriteLine("Mark 60 70 56");
                filStudent.WriteLine("Ant 66 99 86");
                filStudent.Close();
            }
            catch (DirectoryNotFoundException exc)
            {
                Error.WriteLine("Invalid directory\n" + exc.Message);
            }
            catch (System.IO.IOException exc)
            {
                Error.WriteLine(exc.Message);
            }
        }

        static void ReadStudentFile()
        {
            try
            {
                StreamReader filStudent;
                string inValue;
                if (File.Exists("Students.txt"))
                {
                    filStudent = new StreamReader("Students.txt");
                    while ((inValue = filStudent.ReadLine()) != null)
                    {
                        Console.WriteLine(inValue);
                    }
                    filStudent.Close();
                }
                else
                {
                    Console.WriteLine("File Unavailable");
                }
                
            }
            catch(DirectoryNotFoundException exc)
            {
                Error.WriteLine("Invalid directory\n" + exc.Message);
            }
            catch (System.IO.IOException exc)
            {
                Error.WriteLine(exc.Message);
            }
        }
        static void CreateStudentAverageFile()
        {
            StreamWriter filAverage;
            StreamReader filStudent;
            string inValue;
            try
            {
                filAverage = new StreamWriter("StudentsAverage.txt");
                if (File.Exists("Students.txt"))
                {
                    filStudent = new StreamReader("Students.txt");
                    while ((inValue = filStudent.ReadLine()) != null)
                    {
                        string[] data = inValue.Split(" ");
                        string studentName = data[0];
                        string score1 = data[1];
                        string score2 = data[2];
                        string score3 = data[3];
                        double studentAverage;
                        double score1Val = Convert.ToDouble(score1);
                        double score2Val = Convert.ToDouble(score2);
                        double score3Val = Convert.ToDouble(score3);
                        studentAverage = (score1Val + score2Val + score3Val) / 3;
                        filAverage.WriteLine("{0} {1}", studentName, studentAverage);
                    }
                    filStudent.Close();
                    filAverage.Close();
                }
            }
            catch (DirectoryNotFoundException exc)
            {
                Error.WriteLine("Invalid directory" + exc.Message);
            }
            catch (System.IO.IOException exc)
            {
                Error.WriteLine(exc.Message);
            }
        }
        static void ReadAverageFile()
        {
            try
            {
                StreamReader filAverage;
                string inValue;
                if (File.Exists("StudentsAverage.txt"))
                {
                    filAverage = new StreamReader("StudentsAverage.txt");
                    while ((inValue = filAverage.ReadLine()) != null)
                    {
                        Console.WriteLine(inValue);
                    }
                    filAverage.Close();
                }
                else
                {
                    Console.WriteLine("File Unavailable");
                }

            }
            catch (DirectoryNotFoundException exc)
            {
                Error.WriteLine("Invalid directory\n" + exc.Message);
            }
            catch (System.IO.IOException exc)
            {
                Error.WriteLine(exc.Message);
            }
        }

    }
}
