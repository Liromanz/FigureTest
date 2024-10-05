using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLib.Interfaces
{
    public interface ITriangle : IFigure
    {
        bool IsRightTriangle { get; }
    }
}
