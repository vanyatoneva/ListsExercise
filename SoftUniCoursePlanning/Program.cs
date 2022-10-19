using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coursePlan = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string[] command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "course start")
            {
                string lessonTitle = command[1];
                if (command[0] == "Add")
                {
                    AddLesson(lessonTitle, coursePlan);
                }
                else if (command[0] == "Insert")
                {
                    InsertLesson(lessonTitle, int.Parse(command[2]), coursePlan);
                }
                else if (command[0] == "Remove")
                {
                    RemoveLesson(lessonTitle, coursePlan);
                }
                else if (command[0] == "Swap")
                {
                    SwapLessons(command[1], command[2], coursePlan);
                }
                else if (command[0] == "Exercise")
                {
                    AddExercise(lessonTitle, coursePlan);
                }
                command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach(string lesson in coursePlan)
            {
                Console.WriteLine($"{coursePlan.IndexOf(lesson) + 1}.{lesson}");
            }
        }
        static void AddLesson(string lesson, List<string> coursePlan)
        {
            if (!coursePlan.Contains(lesson))
            {
                coursePlan.Add(lesson);
            }
        }
        static void InsertLesson(string lesson, int index, List<string> coursePlan)
        {
            if (!coursePlan.Contains(lesson))
            {
                coursePlan.Insert(index, lesson);
            }
        }
        static void RemoveLesson(string lesson, List<string> coursePlan)
        {
            if (coursePlan.Contains(lesson))
            {
                if(coursePlan.Contains(lesson + "-Exercise"))
                {
                    coursePlan.Remove(lesson + "-Exercise");
                }
                coursePlan.Remove(lesson);
            }
        }
        static void SwapLessons(string lesson1, string lesson2, List<string> coursePlan)
        {
            if (coursePlan.Contains(lesson2) && coursePlan.Contains(lesson1))
            {
                int index1 = coursePlan.IndexOf(lesson1);
                int index2 = coursePlan.IndexOf(lesson2);
                coursePlan.RemoveAt(index1);
                if (index1 == coursePlan.Count)
                {
                    coursePlan.Add(lesson2);
                }
                else
                {
                    coursePlan.Insert(index1, lesson2);
                }
                coursePlan.RemoveAt(index2);
                if (index2 == coursePlan.Count)
                {
                    coursePlan.Add(lesson1);
                }
                else
                {
                    coursePlan.Insert(index2, lesson1);
                }
                string ex1 = lesson1 + "-Exercise";
                string ex2 = lesson2 + "-Exercise";
                if (coursePlan.Contains(ex1))
                {
                    coursePlan.Remove(ex1);
                    if(index2 == coursePlan.Count)
                    {
                        coursePlan.Add(ex1);
                    }
                    else
                    {
                        coursePlan.Insert(index2 + 1, ex1);
                    }
                }
                if (coursePlan.Contains(ex2))
                {
                    coursePlan.Remove(ex2);
                    if (index1 == coursePlan.Count)
                    {
                        coursePlan.Add(ex2);
                    }
                    else
                    {
                        coursePlan.Insert(index1 + 1, ex2);
                    }
                }
            }
        }
        static void AddExercise(string lesson, List<string> coursePlan)
        {
            if (!coursePlan.Contains(lesson + "-Exercise"))
            {
                if (coursePlan.Contains(lesson))
                {
                    int index = coursePlan.IndexOf(lesson);
                    if (index == coursePlan.Count - 1)
                    {
                        coursePlan.Add(lesson + "-Exercise");
                    }
                    else
                    {
                        coursePlan.Insert(index + 1, lesson + "-Exercise");
                    }
                }
                else
                {
                    coursePlan.Add(lesson);
                    coursePlan.Add(lesson + "-Exercise");
                }
            }
        }

    }
}
