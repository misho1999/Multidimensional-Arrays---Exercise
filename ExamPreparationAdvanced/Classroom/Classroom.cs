using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        private List<Student> students;

        //private Student student;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
            

        }
        public string RegisterStudent(Student student)
        {

            //this.Students = new List<Student>();

            if (students.Count < Capacity)
            {
                //Count++;
                //this.Students.Add(student);
                //this.student = student;
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
     
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName );
            if (student == null)
            {
                return $"Student not found";
            }
            students.Remove(student);
            
            return $"Dismissed student {firstName} {lastName}";
        }


        public string GetSubjectInfo(string subject)
        {
            int saver = 0;
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");

            foreach (var student in students)

            {
                if (student.Subject == subject)
                {
                    saver++;
                result.AppendLine($"{student.FirstName} {student.LastName}");

                }
            }
            if (saver <= 0)
            {
                result.Append($"No students enrolled for the subject");
            }
            return result.ToString();

 
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }
        public string GetStudent(string firstName, string lastName)
        {
            string output = default;
            foreach (var item in students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                     output = $"Student: First Name = {item.FirstName}, Last Name = {item.LastName}, Subject = {item.Subject}";
                    return output;
                }
            }
            return output;
        }
    }
}
