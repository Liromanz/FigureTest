using FigureLib.DefaultFigures;
using FigureLib.Interfaces;
using FigureTest.ImplementedFigures;

//Дефолтные фигуры
Circle circle = new Circle(5);
Triangle triangle = new Triangle(3, 4, 5);

//Добавленные фигуры в приложении
Rectangle rectangle = new Rectangle(4, 6);

ShowArea(circle);
ShowArea(triangle);
ShowArea(rectangle);


void ShowArea(IFigure figure)
{
    Console.WriteLine(figure.Area);
}
