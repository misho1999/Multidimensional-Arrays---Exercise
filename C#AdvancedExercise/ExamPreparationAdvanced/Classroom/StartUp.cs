namespace ClassroomProject
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Student student = new Student("M","N","Algebra");
            Student student1 = new Student("S","F","U");
            Student student2 = new Student("B","S","Algebra");
            Student student3 = new Student("A","F","G");

            Console.WriteLine(student);

            Classroom classroom = new Classroom(3);
            string registred = classroom.RegisterStudent(student);
            string registred2 = classroom.RegisterStudent(student1);
            string registred3 = classroom.RegisterStudent(student2);
            string registred4 = classroom.RegisterStudent(student3);
            Console.WriteLine(registred);
            Console.WriteLine(registred2);
            Console.WriteLine(registred3);
            Console.WriteLine(registred4);
            //string remove = classroom.DismissStudent("M", "N");
            //Console.WriteLine(remove);
            string remove1 = classroom.DismissStudent("asd","adsa");
            Console.WriteLine(remove1);
            string subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);
            string subjectInfo1 = classroom.GetSubjectInfo("Algebhjhjra");
            Console.WriteLine(subjectInfo1);
            int count = classroom.GetStudentsCount();
            Console.WriteLine(count);
            Console.WriteLine(classroom.Count);
            Console.WriteLine(classroom.GetStudent("M", "N"));
        }
    }
}