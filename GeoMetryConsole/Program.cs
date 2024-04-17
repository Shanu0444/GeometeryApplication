using System;
using System.Collections.Generic;
using GeometeryLiberary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;


public class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var featureManagement = new Dictionary<string, string> {
            { "FeatureManagement:Square", "true"},
            { "FeatureManagement:Rectangle", "true"},
            { "FeatureManagement:Triangle", "true"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder().AddInMemoryCollection(featureManagement).Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
        if (await featureManager.IsEnabledAsync("Square"))
        {
            Console.WriteLine("Square feature is enabled.");
            // Provide access to Square
            Console.WriteLine("Enter the side length of the square:");
            double sideLength = double.Parse(Console.ReadLine());
            var square = new Square(sideLength);
            Console.WriteLine("Square Area: " + square.CalculateArea());
            Console.WriteLine("Square Perimeter: " + square.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Square feature is disabled.");
        }
         if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            Console.WriteLine("Rectangle feature is enabled.");
            Console.WriteLine("Enter the length of the rectangle:");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the width of the rectangle:");
            double width = double.Parse(Console.ReadLine());
            var rectangle = new Rectangle(length, width);
            Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
            Console.WriteLine("Rectangle Perimeter: " + rectangle.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Rectangle feature is disabled.");
        }

        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            Console.WriteLine("Triangle feature is enabled.");
            Console.WriteLine("Enter the length of side 1 of the triangle:");
            double side1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of side 2 of the triangle:");
            double side2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of side 3 of the triangle:");
            double side3 = double.Parse(Console.ReadLine());
            var triangle = new Triangle(side1, side2, side3);
            Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
            Console.WriteLine("Triangle Perimeter: " + triangle.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Triangle feature is disabled.");
        }
    }
}
