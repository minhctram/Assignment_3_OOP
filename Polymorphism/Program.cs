namespace Polymorphism
{
    // Base class
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        // Virtual method for polymorphism
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Person: {Name}");
        }

        // Virtual method for calculating salary/stipend
        public virtual double CalculatePayment()
        {
            return 0; // Default, could be overridden
        }
    }

    // Derived class: Student
    class Student : Person
    {
        public double Stipend { get; set; }

        public Student(string name, double stipend) : base(name)
        {
            Stipend = stipend;
        }

        // Override virtual methods
        public override void DisplayInfo()
        {
            Console.WriteLine($"Student: {Name}, Stipend: ${Stipend}");
        }

        public override double CalculatePayment()
        {
            // Students might have a stipend instead of salary
            return Stipend;
        }
    }

    // Derived class: Instructor
    class Instructor : Person
    {
        public double Salary { get; set; }

        public Instructor(string name, double salary) : base(name)
        {
            Salary = salary;
        }

        // Override virtual methods
        public override void DisplayInfo()
        {
            Console.WriteLine($"Instructor: {Name}, Salary: ${Salary}");
        }

        public override double CalculatePayment()
        {
            // Instructors have a salary
            return Salary;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Polymorphism: Person reference can point to any derived class
            Person[] people = new Person[]
            {
                new Student("Alice", 1500),
                new Instructor("Mr. Smith", 50000)
            };

            foreach (var person in people)
            {
                person.DisplayInfo();             // Calls overridden method depending on object
                Console.WriteLine("Payment: $" + person.CalculatePayment());
                Console.WriteLine();
            }
        }
    }
}