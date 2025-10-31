namespace Abstraction
{
    // 1. Abstraction: Base abstract class
    abstract class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        // Abstract method: each derived class must define its own behavior
        public abstract void DisplayRole();
    }

    // 2. Student class inherits Person
    class Student : Person
    {
        public int StudentID { get; set; }

        public Student(string name, int studentID) : base(name)
        {
            StudentID = studentID;
        }

        // Implement behavior specific to Student
        public override void DisplayRole()
        {
            Console.WriteLine($"Student Name: {Name}, ID: {StudentID} - Attending classes.");
        }
    }

    // 3. Instructor class inherits Person
    class Instructor : Person
    {
        public string Subject { get; set; }

        public Instructor(string name, string subject) : base(name)
        {
            Subject = subject;
        }

        // Implement behavior specific to Instructor
        public override void DisplayRole()
        {
            Console.WriteLine($"Instructor Name: {Name} - Teaching {Subject}.");
        }
    }

    // 4. Program to demonstrate abstraction
    class Program
    {
        static void Main(string[] args)
        {
            // Abstraction + Polymorphism: use Person type to hold different person types
            Person student = new Student("Minh Tram", 101);
            Person instructor = new Instructor("Mr. Sam", "Science");

            student.DisplayRole();
            instructor.DisplayRole();
        }
    }

}