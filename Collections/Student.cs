using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.Collections
{
    public class Student:IComparable<Student>
    {
        public int Sid { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }

        public int CompareTo(Student other)
        {
            if (this.Sid > other.Sid)
                return 1;
            else if (this.Sid < other.Sid)
                return -1;
            else
                return 0;

        }
    }

    class CompareStudents : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Marks > y.Marks)
                return 1;
            else if (x.Marks < y.Marks)
                return -1;
            else
                return 0;
        }
    }
    class TestStudent
    {
        public static int CompareNames(Student s1,Student s2)
        {
            return s1.Name.CompareTo(s2.Name);
        }
        static void Main(string[] args)
        {
            Student s1 = new Student { Sid = 103, Name = "Ajay", Class = 10, Marks = 575.00f };
            Student s2 = new Student { Sid = 106, Name = "Stuart", Class = 10, Marks = 535.00f };
            Student s3 = new Student { Sid = 104, Name = "Williams", Class = 10, Marks = 592.00f };
            Student s4 = new Student { Sid = 102, Name = "Venkat", Class = 10, Marks = 453.00f };
            Student s5 = new Student { Sid = 101, Name = "David", Class = 10, Marks = 512.00f };
            Student s6 = new Student { Sid = 105, Name = "John", Class = 10, Marks = 498.00f };
            List<Student> Students = new List<Student>() { s1, s2, s3, s4, s5, s6 };
            //CompareStudents obj = new CompareStudents();
            //students.Sort(obj);
            //students.Sort();
            //students.Sort(1, 5, obj);
            //Comparison<Student> obj = new Comparison<Student>(CompareNames);
            Students.Sort(CompareNames);
            foreach(Student student in Students)
                Console.WriteLine(student.Sid+" "+student.Name+" "+student.Class+" "+student.Marks);

        }
    }
}
