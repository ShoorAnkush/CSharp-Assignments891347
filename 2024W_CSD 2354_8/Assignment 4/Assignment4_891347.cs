using System;

public class Circle
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public bool IsPointInside(double x, double y)
    {
        double distanceFromCenter = Math.Sqrt(x * x + y * y);
        return distanceFromCenter <= radius;
    }
}

public class CircleManager
{
    public static Circle[] CreateCircles(int totalCircles)
    {
        Circle[] circles = new Circle[totalCircles];
        for (int i = 0; i < totalCircles; i++)
        {
            Console.WriteLine($"Enter radius for Circle {i + 1}: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            circles[i] = new Circle(radius);
        }
        return circles;
    }

    public static void PrintCircleInfo(Circle[] circles)
    {
        foreach (Circle circle in circles)
        {
            Console.WriteLine($"Circle with radius {circle.CalculateArea():F2} and perimeter {circle.CalculatePerimeter():F2}");
        }
    }

    public static Tuple<double, double> GetPointFromUser()
    {
        Console.WriteLine("Enter x coordinate of the point: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter y coordinate of the point: ");
        double y = Convert.ToDouble(Console.ReadLine());

        return Tuple.Create(x, y);
    }

    public static void PointCheck(Circle[] circles, double x, double y)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            bool inside = circles[i].IsPointInside(x, y);
            Console.WriteLine($"Point is{(inside ? "" : " not")} inside Circle {i + 1}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of circles: ");
        int totalCircles = Convert.ToInt32(Console.ReadLine());

        Circle[] circles = CircleManager.CreateCircles(totalCircles);

        Console.WriteLine("Circle information:");
        CircleManager.PrintCircleInfo(circles);

        Tuple<double, double> point = CircleManager.GetPointFromUser();

        CircleManager.PointCheck(circles, point.Item1, point.Item2);
    }
}
