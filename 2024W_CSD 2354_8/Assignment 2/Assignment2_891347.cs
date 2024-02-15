using System;

class Interval
{
    static void Main()
    {
        Console.WriteLine("Test your program with the values -20, -10, -2, -1, 0, 1, 1.5, 2, 3 and 4. \nType 'Exit' to exit the program");
        while (true)
        {
            Console.Write("Enter a real number: ");
            string? input = Console.ReadLine(); // Use nullable string

            // Check if the user wants to exit
            if (string.Equals(input, "Exit", StringComparison.OrdinalIgnoreCase)) // Perform null check before comparing
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            if (!double.TryParse(input, out double x))
            {
                Console.WriteLine("Invalid input. Please enter a valid real number.");
                continue;
            }

            if (x >= 2 && x < 3)
            {
                Console.WriteLine("x belongs to I");
            }
            else if ((x >= 0 && x <= 1) || (x >= -10 && x < -2))
            {
                Console.WriteLine("x belongs to I");
            }
            else
            {
                Console.WriteLine("x does not belong to I");
            }
        }
    }
}
