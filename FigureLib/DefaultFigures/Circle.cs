using FigureLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib.DefaultFigures
{
    public readonly record struct Circle : IFigure
    {
        public double Radius { get; }

        public double Area
        {
            get
            {
                if (Radius > Math.Sqrt(double.MaxValue / Math.PI))
                    throw new OverflowException("Радиус слишком велик, чтобы вычислить площадь круга без переполнения.");
                else
                    return Math.PI * Radius * Radius;
            }
        }

        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Радиус не может быть отрицательным", nameof(radius));
            
            Radius = radius;
        }

    }
}
