using FigureLib.DefaultFigures;

namespace FigureTest
{
    internal class CircleTests
    {

        [Test]
        public void Area_ValidRadius_ReturnsCorrectArea()
        {
            var circle = new Circle(5);
            var area = circle.Area;

            Assert.That(area, Is.EqualTo(78.53981633974483).Within(0.0001));
        }

        [Test]
        public void Area_ZeroRadius_ReturnsZero()
        {
            var circle = new Circle(0);
            var area = circle.Area;

            Assert.That(area, Is.EqualTo(0));
        }


        [Test]
        public void Area_InvalidRadius_ValueIsTooBig()
        {
            var circle = new Circle(double.MaxValue);

            Assert.Throws<OverflowException>(() => { var area = circle.Area; });
        }

        [Test]
        public void Area_InvalidRadius_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }
    }
}
