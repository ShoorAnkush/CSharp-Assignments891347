using System;
namespace AgeCalculator
{
class Program
{
        static void Main(string[] args)
        {
          //Exercise 1-1
            Console.WriteLine("provide your age: ");
            int age = int.Parse(Console.ReadLine());
            //calculate current year
            int currentYear = DateTime.Now.Year;
            //calculate year of birth
            int birthYear = currentYear - age;
            Console.WriteLine($"Your year of birth is: {birthYear}");


          //Exercise 1-2
            Console.WriteLine("Enter a (int)");  
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b (int)");  
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter c (int)");  
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter x (double)");  
            double x = double.Parse(Console.ReadLine());

            double exp1 = ((a + b) / 2.0) * Math.Pow( x, 3);
            double exp2 = Math.Pow(a + b, 2) * Math.Pow(x, 2);
            double exp3 = a + b + c;
            double result = exp1 + exp2 + exp3;
            Console.WriteLine($"The value of polynomial is: {result}");


          //Exercise 1-3
          Console.WriteLine("Enter x: ");
          int x1 = int.Parse(Console.ReadLine());

          Console.WriteLine("Enter y: ");
          int y1 = int.Parse(Console.ReadLine());

          Console.WriteLine($"Before swapping: x:{x1}; y:{y1};");

          int z1 = x1;
          x1 = y1;
          y1 = z1;

          Console.WriteLine($"After swapping: x:{x1}; y:{y1};");


          //Exercise 1-4
          Console.WriteLine("How much did you receive money ($)?");
          int moneyAmount = int.Parse(Console.ReadLine());

          double bookAndSupplies = moneyAmount * 0.75;
          double amountLeft = moneyAmount - bookAndSupplies;
          double equalDivide = amountLeft / 3;
          double coffee = (int)equalDivide / 2;
          double flashDrive = (int)equalDivide / 4;
          double subwayTicket = (int)equalDivide / 3;
          double forRoses = moneyAmount - bookAndSupplies - (coffee * 2) - (flashDrive * 4) - (subwayTicket * 3);

          Console.WriteLine($"Book and Supplies: {bookAndSupplies}");
          Console.WriteLine($"You can then buy: {coffee} coffees");
          Console.WriteLine($"{flashDrive} Flash Computer Numbers");
          Console.WriteLine($"{subwayTicket} subway Tickets"); 
          Console.WriteLine($"and you will have {forRoses} dollars for the white roses.");
        }
    }
}
          
