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
        [Test]
        public void Area_ValidSides_ReturnsCorrectArea() //обычный треугольник
        {
            var triangle = new Triangle(5, 4, 8);
            double area = triangle.Area;

            Assert.IsFalse(triangle.IsRightTriangle);
            Assert.That(area, Is.EqualTo(8.1815).Within(0.0001));
        }

        [Test]
        public void Area_ValidRightSides_ReturnsCorrectArea() // прямоугольный треугольник
        {
            var triangle = new Triangle(3, 4, 5);
            double area = triangle.Area;

            Assert.IsTrue(triangle.IsRightTriangle); 
            Assert.That(area, Is.EqualTo(6));
        }

        [Test]
        public void Area_ValidEqualSides_ReturnsCorrectArea() //равнобедренный треугольник
        {
            var triangle = new Triangle(5, 5, 8);
            double area = triangle.Area;

            Assert.IsFalse(triangle.IsRightTriangle); 
            Assert.That(area, Is.EqualTo(12));
        }

        [Test]
        public void Area_ValidAllEqualSides_ReturnsCorrectArea() // равносторонний треугольник
        {
            var triangle = new Triangle(3, 3, 3);
            double area = triangle.Area;

            Assert.IsFalse(triangle.IsRightTriangle); 
            Assert.That(area, Is.EqualTo(3.8971).Within(0.0001));
        }

        [Test]
        public void Constructor_InvalidSides_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3)); // такого треугольника не может быть
            Assert.Throws<ArgumentException>(() => new Triangle(1, 0, 5)); // одна сторона равна 0
            Assert.Throws<ArgumentException>(() => new Triangle(-1, 4, 5)); // другая из сторон отрицательная
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, -1)); // и третья сторона резко отрицательная
        }

        [Test]
        public void Area_ZeroSides_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0)); // все стороны равны 0
        }


        [Test]
        public void Area_NegativeSides_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1, -2, -3)); // все стороны отрицательные
        }
    }
}
