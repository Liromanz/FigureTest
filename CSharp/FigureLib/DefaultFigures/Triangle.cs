using FigureLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib.DefaultFigures
{
    public record struct Triangle : ITriangle
    {
        public double SideA {get;}
        public double SideB {get;}
        public double Hypotenuse { get; }

        public Triangle(double sideA, double sideB, double hypotenuse)
        {
            // разные вариации вывода ошибок - без параметра
            if (sideA >= sideB + hypotenuse ||
                sideB >= sideA + hypotenuse ||
                hypotenuse >= sideA + sideB)
                throw new ArgumentException("Треугольника с такими сторонами не существует");

            //и с параметром
            if (sideA <= 0)
                throw new ArgumentException("Треугольник не может быть с отрицательными сторонами", nameof(sideA));
            if (sideB <= 0)
                throw new ArgumentException("Треугольник не может быть с отрицательными сторонами", nameof(sideB));
            if (hypotenuse <= 0)
                throw new ArgumentException("Треугольник не может быть с отрицательными сторонами", nameof(hypotenuse));

            SideA = sideA;
            SideB = sideB;
            Hypotenuse = hypotenuse;
        }

        public double Area
        {
            get
            {
                double perimeter = (SideA + SideB + Hypotenuse) / 2;
                double areaSquared = perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - Hypotenuse);

                if (double.IsInfinity(areaSquared))
                    throw new OverflowException("Переполнение при вычислении площади треугольника");
                else
                    return Math.Sqrt(areaSquared);
            }
        }

        public bool IsRightTriangle => (SideA * SideA) + (SideB * SideB) == (Hypotenuse * Hypotenuse);

    }
}
