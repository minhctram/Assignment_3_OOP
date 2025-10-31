namespace BallProblem
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;
        
        public Color(int red, int green, int blue, int alpha)
        {
            SetRed(red);
            SetGreen(green);
            SetBlue(blue);
            SetAlpha(alpha);
        }
        public Color(int red, int green, int blue) : this(red, green, blue, 255) { }
        
        public int GetRed() => red;
        public void SetRed(int value)
        {
            red = ValidateColorValue(value);
        }

        public int GetGreen() => green;
        public void SetGreen(int value)
        {
            green = ValidateColorValue(value);
        }

        public int GetBlue() => blue;
        public void SetBlue(int value)
        {
            blue = ValidateColorValue(value);
        }

        public int GetAlpha() => alpha;
        public void SetAlpha(int value)
        {
            alpha = ValidateColorValue(value);
        }

        private int ValidateColorValue(int value)
        {
            if (value < 0 || value > 255)
                throw new ArgumentOutOfRangeException(nameof(value), "Color value must be between 0 and 255.");
            return value;
        }
        public int GetGrayscale()
        {
            return (red + green + blue) / 3;
        }

        public override string ToString()
        {
            return $"Color(R={red}, G={green}, B={blue}, A={alpha})";
        }
    }
    
    public class Ball
    {
        private int size;
        private Color color;
        private int throwCount;
        
        public Ball(int size, Color color)
        {
            this.size = size;
            this.color = color;
            this.throwCount = 0;
        }

        public void Pop()
        {
            size = 0;
            Console.WriteLine("Ball popped!");
        }

        public void Throw()
        {
            if (size > 0)
            {
                throwCount++;
                Console.WriteLine("Ball thrown!");
            }
            else
            {
                Console.WriteLine("Can't throw a popped ball!");
            }
        }

        public int GetThrowCount() => throwCount;
        
        public override string ToString()
        {
            return $"Ball(Size={size}, Color={color}, Throws={throwCount})";
        }
    }

    class Program
    {
        static void Main()
        {
            
            Color red = new Color(255, 0, 0);
            Color green = new Color(0, 255, 0, 200);
            Color blue = new Color(0, 0, 255);
            
            Ball ball1 = new Ball(10, red);
            Ball ball2 = new Ball(15, green);
            Ball ball3 = new Ball(20, blue);
            
            ball1.Throw();
            ball1.Throw();
            ball2.Throw();
            ball3.Throw();
            ball3.Throw();
            ball3.Throw();
            
            ball1.Pop();
            ball3.Pop();
            
            ball1.Throw();
            ball3.Throw();
            
            Console.WriteLine($"\nBall 1 thrown: {ball1.GetThrowCount()} times");
            Console.WriteLine($"Ball 2 thrown: {ball2.GetThrowCount()} times");
            Console.WriteLine($"Ball 3 thrown: {ball3.GetThrowCount()} times");
            
            Console.WriteLine($"\nRed grayscale: {red.GetGrayscale()}");
            Console.WriteLine($"Green grayscale: {green.GetGrayscale()}");
            Console.WriteLine($"Blue grayscale: {blue.GetGrayscale()}");
        }
    }
}