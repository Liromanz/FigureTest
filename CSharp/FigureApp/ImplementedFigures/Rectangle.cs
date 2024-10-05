using FigureLib.Interfaces;

namespace FigureTest.ImplementedFigures
{
    internal readonly record struct Rectangle : IFigure
    {
        public double XSides { get; }
        public double YSides { get; }

        public double Area => XSides * YSides;

        public Rectangle(double xSides, double ySides)
        {
            if (xSides <= 0)
                throw new ArgumentException("Стороны не могут быть отрицательными", nameof(xSides));
            if (ySides <= 0)
                throw new ArgumentException("Стороны не могут быть отрицательными", nameof(ySides));
            XSides = xSides;
            YSides = ySides;
        }
    }
}
