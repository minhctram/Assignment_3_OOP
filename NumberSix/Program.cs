namespace NumberSix
{

    // =========================
    // INTERFACES
    // =========================

    public interface IPersonService
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        List<string> Addresses { get; }

        int CalculateAge();
        decimal CalculateSalary();
        void AddAddress(string address);
        List<string> GetAddresses();
    }

    public interface IStudentService : IPersonService
    {
        List<Course> Courses { get; }
        void EnrollCourse(Course course, char grade);
        double CalculateGPA();
    }

    public interface IInstructorService : IPersonService
    {
        Department Department { get; set; }
        DateTime JoinDate { get; set; }
        decimal ExperienceBonus { get; set; }
        int CalculateYearsOfExperience();
    }

    public interface ICourseService
    {
        string CourseName { get; set; }
        List<Student> EnrolledStudents { get; }

        void EnrollStudent(Student student, char grade);
    }

    public interface IDepartmentService
    {
        string DepartmentName { get; set; }
        Instructor Head { get; set; }
        decimal Budget { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        List<Course> Courses { get; }

        void AddCourse(Course course);
    }
    
    public abstract class Person : IPersonService
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        private decimal salary;
        public List<string> Addresses { get; private set; } = new List<string>();

        public decimal Salary
        {
            get => salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                salary = value;
            }
        }

        public int CalculateAge()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public abstract decimal CalculateSalary();

        public void AddAddress(string address)
        {
            Addresses.Add(address);
        }

        public List<string> GetAddresses() => Addresses;
    }
    
    public class Student : Person, IStudentService
    {
        public List<Course> Courses { get; private set; } = new List<Course>();
        private Dictionary<Course, char> Grades { get; set; } = new Dictionary<Course, char>();

        public void EnrollCourse(Course course, char grade)
        {
            Courses.Add(course);
            Grades[course] = grade;
            course.EnrollStudent(this, grade);
        }

        public double CalculateGPA()
        {
            if (Grades.Count == 0) return 0.0;

            double totalPoints = 0;
            foreach (var grade in Grades.Values)
            {
                totalPoints += grade switch
                {
                    'A' => 4.0,
                    'B' => 3.0,
                    'C' => 2.0,
                    'D' => 1.0,
                    _ => 0.0
                };
            }

            return totalPoints / Grades.Count;
        }

        public override decimal CalculateSalary()
        {
            return 0;
        }
    }
    
    public class Instructor : Person, IInstructorService
    {
        public Department Department { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal ExperienceBonus { get; set; }

        public int CalculateYearsOfExperience()
        {
            var today = DateTime.Today;
            int years = today.Year - JoinDate.Year;
            if (JoinDate.Date > today.AddYears(-years)) years--;
            return years;
        }

        public override decimal CalculateSalary()
        {
            int years = CalculateYearsOfExperience();
            return Salary + (ExperienceBonus * years);
        }
    }
    
    public class Course : ICourseService
    {
        public string CourseName { get; set; }
        public List<Student> EnrolledStudents { get; private set; } = new List<Student>();
        private Dictionary<Student, char> StudentGrades { get; set; } = new Dictionary<Student, char>();

        public void EnrollStudent(Student student, char grade)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
                StudentGrades[student] = grade;
            }
        }
    }
    
    public class Department : IDepartmentService
    {
        public string DepartmentName { get; set; }
        public Instructor Head { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Course> Courses { get; private set; } = new List<Course>();

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
    }

    class Program
    {
        static void Main()
        {
            Instructor profJohn = new Instructor
            {
                Name = "John Smith",
                DateOfBirth = new DateTime(1980, 5, 14),
                Salary = 60000,
                JoinDate = new DateTime(2010, 9, 1),
                ExperienceBonus = 1000
            };
            profJohn.AddAddress("123 Elm St, Hartford, CT");
            
            Department csDept = new Department
            {
                DepartmentName = "Computer Science",
                Head = profJohn,
                Budget = 500000,
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2026, 1, 1)
            };
            profJohn.Department = csDept;
            
            Course csharp = new Course { CourseName = "C# Programming" };
            Course sql = new Course { CourseName = "SQL Fundamentals" };
            csDept.AddCourse(csharp);
            csDept.AddCourse(sql);
            
            Student alice = new Student
            {
                Name = "Alice Brown",
                DateOfBirth = new DateTime(2002, 3, 10)
            };
            alice.EnrollCourse(csharp, 'A');
            alice.EnrollCourse(sql, 'B');
            Console.WriteLine($"Instructor: {profJohn.Name}, Age: {profJohn.CalculateAge()}");
            Console.WriteLine($"Years of Experience: {profJohn.CalculateYearsOfExperience()}");
            Console.WriteLine($"Total Salary: {profJohn.CalculateSalary():C}");
            Console.WriteLine($"Addresses: {string.Join(", ", profJohn.GetAddresses())}");
            Console.WriteLine($"\nStudent: {alice.Name}, Age: {alice.CalculateAge()}");
            Console.WriteLine($"GPA: {alice.CalculateGPA():F2}");
            Console.WriteLine($"Enrolled Courses: {string.Join(", ", alice.Courses.Select(c => c.CourseName))}");
        }
    }
}
