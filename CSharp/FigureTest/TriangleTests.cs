using FigureLib.DefaultFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureTest
{
    internal class TriangleTests
    {
        [TestCase(5,4,8, 8.1815, 0.0001)]  //обычный треугольник
        [TestCase(3,4,5, 6, 0)] // прямоугольный треугольник
        [TestCase(5,5,8, 12, 0)]   //равнобедренный треугольник
        [TestCase(3,3,3, 3.8971, 0.0001)]   // равносторонний треугольник
        public void Area_ValidSides_ReturnsCorrectArea(double sideA, double sideB, double hypotenuse, double expected, double round)
        {
            var triangle = new Triangle(sideA, sideB, hypotenuse);
            double area = triangle.Area;

            Assert.That(area, Is.EqualTo(expected).Within(round));
        }

        [TestCase(5, 4, 8, false)]  //обычный треугольник
        [TestCase(3, 4, 5, true)] // прямоугольный треугольник
        [TestCase(5, 5, 8, false)]   //равнобедренный треугольник
        [TestCase(3, 3, 3, false)]   // равносторонний треугольник
        public void Area_ValidSides_IsRightTriangle(double sideA, double sideB, double hypotenuse, bool expected)
        {
            var triangle = new Triangle(sideA, sideB, hypotenuse);
            
            Assert.That(triangle.IsRightTriangle, Is.EqualTo(expected)); 
        }

        [Test]
        public void Area_TooBigSides_ThrowsOverflowException()
        {
            var triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);

            Assert.Throws<OverflowException>(() => { var area = triangle.Area; });
        }

        [TestCase(1, 2, 3)] // такого треугольника не может быть
        [TestCase(1, 0, 5)] // одна сторона равна 0
        [TestCase(-1, 4, 3)] // другая из сторон отрицательная
        [TestCase(1, 1, -1)] // и третья сторона резко отрицательная
        [TestCase(0, 0, 0)] // все стороны равны 0
        [TestCase(-1, -2, -3)] // все стороны отрицательные
        public void Constructor_InvalidSides_ThrowsArgumentException(double sideA, double sideB, double hypotenuse)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, hypotenuse));
        }

    }
}
