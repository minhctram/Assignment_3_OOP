namespace ReverseArray
{
    class Program
    {
        static int[] GenerateNumbers(int size)
        {
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = i + 1;
            }
            return numbers;
        }

        static int[] ReverseArray(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n / 2; i++)
            {
                int temp = numbers[i];
                numbers[i] = numbers[n - 1 - i];
                numbers[n - 1 - i] = temp;
            }
            return numbers;
        }

        static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(",", numbers));
        }
        
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the array: ");
            int length = int.Parse(Console.ReadLine());
            int[] myArray = GenerateNumbers(length);
            ReverseArray(myArray);
            PrintNumbers(myArray);
        }
        
    }
}