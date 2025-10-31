namespace Concepts
{

    // 1. Abstraction: Define an abstract class for shapes
    abstract class Shape
    {
        // Abstract method: every shape must implement how to calculate area
        public abstract double CalculateArea();
    }

    // 2. Encapsulation: Private fields with public properties
    class Circle : Shape
    {
        private double radius;  // Encapsulated field

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                    Console.WriteLine("Radius cannot be negative.");
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        // Polymorphism: Overriding abstract method
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    // 3. Inheritance: Rectangle inherits from Shape
    class Rectangle : Shape
    {
        public double Width { get; set; }   // Encapsulated property
        public double Height { get; set; }  // Encapsulated property

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Polymorphism: Overriding abstract method
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Abstraction + Polymorphism: Use Shape type to hold derived objects
            Shape myCircle = new Circle(5);
            Shape myRectangle = new Rectangle(4, 6);

            Console.WriteLine($"Circle Area: {myCircle.CalculateArea()}");
            Console.WriteLine($"Rectangle Area: {myRectangle.CalculateArea()}");

            // Demonstrating Encapsulation
            Circle circle = new Circle(10);
            Console.WriteLine($"Circle Radius: {circle.Radius}");
            circle.Radius = -5; // Will show validation message
        }
    }

}