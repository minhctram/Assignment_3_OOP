namespace Encapsulation
{
    // 1. Abstraction: Base abstract class
    abstract class Person
    {
        private string name;  // Encapsulated field

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    Console.WriteLine("Name cannot be empty.");
            }
        }

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
        private int studentID;  // Encapsulated field

        public int StudentID
        {
            get { return studentID; }
            set
            {
                if (value > 0)
                    studentID = value;
                else
                    Console.WriteLine("Student ID must be positive.");
            }
        }

        private double gpa; // Example of another private detail
        public double GPA
        {
            get { return gpa; }
            set
            {
                if (value >= 0 && value <= 4.0)
                    gpa = value;
                else
                    Console.WriteLine("GPA must be between 0 and 4.0.");
            }
        }

        public Student(string name, int studentID, double gpa) : base(name)
        {
            StudentID = studentID;
            GPA = gpa;
        }

        public override void DisplayRole()
        {
            Console.WriteLine($"Student Name: {Name}, ID: {StudentID}, GPA: {GPA} - Attending classes.");
        }
    }

    // 3. Instructor class inherits Person
    class Instructor : Person
    {
        private string subject; // Encapsulated field

        public string Subject
        {
            get { return subject; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    subject = value;
                else
                    Console.WriteLine("Subject cannot be empty.");
            }
        }

        private double salary; // Example of private detail
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    Console.WriteLine("Salary must be non-negative.");
            }
        }

        public Instructor(string name, string subject, double salary) : base(name)
        {
            Subject = subject;
            Salary = salary;
        }

        public override void DisplayRole()
        {
            Console.WriteLine($"Instructor Name: {Name}, Subject: {Subject}, Salary: ${Salary} - Teaching classes.");
        }
    }

    // 4. Program to demonstrate encapsulation + abstraction
    class Program
    {
        static void Main(string[] args)
        {
            Person student = new Student("Alice", 101, 3.8);
            Person instructor = new Instructor("Mr. Smith", "Math", 55000);

            student.DisplayRole();
            instructor.DisplayRole();

            // Demonstrating encapsulation: cannot directly access private fields
            // student.Name = ""; // Invalid, setter prevents empty name
            // instructor.Salary = -5000; // Invalid, setter prevents negative salary
        }
    }

}