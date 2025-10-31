namespace Inheritance
{
    // Base class
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void DisplayName()
        {
            Console.WriteLine("Person Name: " + Name);
        }
    }

    // Derived class Student
    class Student : Person
    {
        public int StudentID { get; set; }

        public Student(string name, int studentID) : base(name)
        {
            StudentID = studentID;
        }

        public void DisplayStudentInfo()
        {
            // Reuse DisplayName() from Person
            DisplayName();
            Console.WriteLine("Student ID: " + StudentID);
        }
    }

    // Derived class Instructor
    class Instructor : Person
    {
        public string Subject { get; set; }

        public Instructor(string name, string subject) : base(name)
        {
            Subject = subject;
        }

        public void DisplayInstructorInfo()
        {
            // Reuse DisplayName() from Person
            DisplayName();
            Console.WriteLine("Subject: " + Subject);
        }
    }

    // Program
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Alice", 101);
            Instructor instructor = new Instructor("Mr. Smith", "Math");

            student.DisplayStudentInfo();      // Uses inherited DisplayName()
            instructor.DisplayInstructorInfo();// Uses inherited DisplayName()
        }
    }

}