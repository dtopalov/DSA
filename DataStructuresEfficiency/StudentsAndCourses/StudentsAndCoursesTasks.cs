namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class StudentsAndCoursesTasks
    {
        static void Main()
        {
            var sortedByCourse = SortStudents("../../students.txt");
            PrintDictionary(sortedByCourse);
        }

        private static SortedDictionary<string, List<string>> SortStudents(string source)
        {
            var studentsByCourse = new SortedDictionary<string, List<string>>();
            using (var streamReader = new StreamReader(source))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    string[] lineParts = line.Split('|');
                    var course = lineParts[2].Trim();
                    var firstName = lineParts[0].Trim();
                    var lastName = lineParts[1].Trim();
                    var name = firstName + ' ' + lastName;
                    if (studentsByCourse.ContainsKey(course))
                    {
                        studentsByCourse[course].Add(name);
                    }
                    else
                    {
                        studentsByCourse.Add(course, new List<string> { name });
                    }
                }
            }

            return studentsByCourse;
        }

        private static void PrintDictionary(SortedDictionary<string, List<string>> dictionary)
        {
            foreach (var key in dictionary)
            {
                key.Value.Sort();
                Console.WriteLine($"{key.Key}: {string.Join(", ", key.Value)}");
            }
        }
    }
}