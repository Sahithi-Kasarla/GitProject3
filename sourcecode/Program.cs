/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sourcecode
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            LoadData();
            Console.WriteLine("*****************************");
            Console.WriteLine("\n Students Data before Sorting:");
            Console.WriteLine("*****************************");
            Display(students);
            // Sort the student list by name
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("*****************************");
            Console.WriteLine("\nStudent Data After Sorting \n");
            Console.WriteLine("*****************************");
            DisplaySortedData(students);
            Console.Write("\nEnter a student's name to search: ");
            string searchName = Console.ReadLine();
            SearchByName(searchName);
            Console.ReadKey();
        }
        static void LoadData()
        {
            try
            {
                string filePath =@"C:\Users\Dell\OneDrive\Documents\Mphasis Docs\Projects\gitproject3\Rainbow School.txt";
            if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 2)
                        {
                            string name = data[0].Trim();
                            string studentClass = data[1].Trim();
                            students.Add(new Student
                            {
                                Name = name,
                                Class = studentClass
                            });
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found: student.txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loading data from the file!!!! " +
               ex.Message);
            }
        }
        static void Display(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, \t\t\t\tClass: { student.Class}");
            }
        }
        static void DisplaySortedData(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, \t\t\t\tClass:{ student.Class}");
            }
        }
        static void SearchByName(string searchName)
        {
            bool found = false;
            foreach (var student in students)
            {
                if (student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nStudent Found: Name: {student.Name}, Class: { student.Class}");
                found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("\nStudent not found!!!");
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Data: ");
            Console.WriteLine("Name\tClass");
            string directorypath = "C:\\Users\\Dell\\OneDrive\\Documents\\Mphasis Docs\\Projects\\gitproject3";
            List<string> studentData = ReadStudentData(Path.Combine(directorypath, "studentData.txt"));
            DisplayStudentData(studentData);
            Console.WriteLine("\nStudent Data after Sorting:");
            studentData = SortStudentDataByName(studentData);
            DisplayStudentData(studentData);
            Console.Write("\nEnter a name to search: ");
            string searchName = Console.ReadLine();
            SearchStudentByName(studentData, searchName);
            Console.ReadKey();
        }
        static List<string> ReadStudentData(string filePath)
        {
            List<string> studentData = new List<string>();
            try
            {
                studentData = new List<string>(File.ReadAllLines(filePath));
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return studentData;
        }
        static void DisplayStudentData(List<string> studentData)
        {
            foreach (string data in studentData)
            {
                Console.WriteLine(data);
            }
        }
        static List<string> SortStudentDataByName(List<string> studentData)
        {
            return studentData.OrderBy(s => s.Split('\t')[0].Trim()).ToList();
        }
         static void SearchStudentByName(List<string> studentData, string searchName)
         {
             var result = studentData.Where(s => s.Split(new[] { "Class-" }, StringSplitOptions.None)[0].Trim()
             .Equals(searchName.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

             if (result.Any())
             {
                 Console.WriteLine("\nStudent Found:");
                 DisplayStudentData(result);
             }
             else
             {
                 Console.WriteLine($"\nNo students found with the name {searchName}");
             }
         }
        
    }
}