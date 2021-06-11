using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleLinqStudent
{
    public class StudentClass
    {
        #region data

        protected enum GradeLevel
        {
            FirstYear = 1,
            SecondYear,
            ThirdYear,
            FourthYear
        }

        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }

        protected static List<Student> students = new()
        {
            new()
            {
                FirstName = "Terry",
                LastName = "Adams",
                Id = 120,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int> { 99, 82, 81, 79 }
            },
            new()
            {
                FirstName = "Fadi",
                LastName = "Fakhouri",
                Id = 116,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int> { 99, 86, 90, 94 }
            },
            new()
            {
                FirstName = "Hanying",
                LastName = "Feng",
                Id = 117,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int> { 93, 92, 80, 87 }
            },
            new()
            {
                FirstName = "Cesar",
                LastName = "Garcia",
                Id = 114,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int> { 97, 89, 85, 82 }
            },
            new()
            {
                FirstName = "Debra",
                LastName = "Garcia",
                Id = 115,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int> { 35, 72, 91, 70 }
            },
            new()
            {
                FirstName = "Hugo",
                LastName = "Garcia",
                Id = 118,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int> { 92, 90, 83, 78 }
            },
            new()
            {
                FirstName = "Sven",
                LastName = "Mortensen",
                Id = 113,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int> { 88, 94, 65, 91 }
            },
            new()
            {
                FirstName = "Claire",
                LastName = "O'Donnell",
                Id = 112,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int> { 75, 84, 91, 39 }
            },
            new()
            {
                FirstName = "Svetlana",
                LastName = "Omelchenko",
                Id = 111,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int> { 97, 92, 81, 60 }
            },
            new()
            {
                FirstName = "Lance",
                LastName = "Tucker",
                Id = 119,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int> { 68, 79, 88, 92 }
            },
            new()
            {
                FirstName = "Michael",
                LastName = "Tucker",
                Id = 122,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int> { 94, 92, 91, 91 }
            },
            new()
            {
                FirstName = "Eugene",
                LastName = "Zabokritski",
                Id = 121,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int> { 96, 85, 91, 60 }
            }
        };

        #endregion

        //Helper method, used in GroupByRange.
        protected static int GetPercentile(Student s)
        {
            var avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

            foreach (var item in highScores) Console.WriteLine($"{item.Name,-15}{item.Score}");
        }

        //按单个属性分组示例
        public void GroupBySingleProperty()
        {
            Console.WriteLine("Group by a single property in an object:");

            // Variable queryLastNames is an IEnumerable<IGrouping<string,
            // DataClass.Student>>.
            var queryLastNames =
                from student in students
                group student by student.LastName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        //按值分组示例
        public void GroupBySubstring()
        {
            Console.WriteLine("\r\nGroup by something other than a property of the object:");

            var queryFirstLetters =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in queryFirstLetters)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        //按范围示例分组
        public void GroupByRange()
        {
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

            var queryNumericRange =
                from student in students
                let percentile = GetPercentile(student)
                group new { student.FirstName, student.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }
        }

        //按比较示例分组
        public void GroupByBoolean()
        {
            var queryGroupByAverages = from student in students
                                       group new { student.FirstName, student.LastName } by student.ExamScores.Average() > 75
                into studentGroup
                                       select studentGroup;
            foreach (var studentGroup in queryGroupByAverages)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }

        //按匿名类型分组
        public void GroupByCompositeKey()
        {
            var queryHighScoreGroups =
                from student in students
                group student by new
                {
                    FirstLetter = student.LastName[0],
                    Score = student.ExamScores[0] > 85
                } into studentGroup
                orderby studentGroup.Key.FirstLetter
                select studentGroup;

            Console.WriteLine("\r\nGroup and order by a compound key:");
            foreach (var scoreGroup in queryHighScoreGroups)
            {
                string s = scoreGroup.Key.Score ? "more than" : "less than";
                Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s} 85");
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                }
            }
        }
    }

    public class TestStudentData
    {
        public static void TestLinq()
        {
            StudentClass sc = new StudentClass();
            //sc.QueryHighScores(1, 90);
            //sc.GroupBySingleProperty();
            //sc.GroupBySubstring()
            //sc.GroupByRange();
            sc.GroupByCompositeKey();
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}