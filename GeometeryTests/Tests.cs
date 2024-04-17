namespace GeometeryTests;

using GeometeryLiberary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ShapeTests
{
    [TestMethod]
    public void Square_Area_Test()
    {
        
        var square = new Square(8); 
        var area = square.CalculateArea();
       // Assert
        Assert.AreEqual(64, area);
        
    }

[TestMethod]
     public void Square_Perimeter_Test()
    {
        
        var square = new Square(7);
        var perimeter = square.CalculatePerimeter();
        // Assert
        Assert.AreEqual(28, perimeter);
    }

    [TestMethod]
    public void Rectangle_Area_Test()
    {
        
        var rectangle = new Rectangle(4, 6);    
        var area = rectangle.CalculateArea();
        // Assert
        Assert.AreEqual(24, area);
    
    }
    [TestMethod]
    public void Rectangle_Perimeter_Test(){
        var rectangle = new Rectangle(5, 7);
        var perimeter = rectangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(24, perimeter);
    }

    [TestMethod]
    public void Triangle_Area_Test()
    {
        
        var triangle = new Triangle(3, 4, 5);
        var area = triangle.CalculateArea();
        // Assert
        Assert.AreEqual(6, area);
    
    }

    [TestMethod]
    public void Triangle_Perimeter_Test()
    {
        
        var triangle = new Triangle(8,5,6);
        var perimeter = triangle.CalculatePerimeter();
        // Assert
        Assert.AreEqual(19, perimeter);
    }
}