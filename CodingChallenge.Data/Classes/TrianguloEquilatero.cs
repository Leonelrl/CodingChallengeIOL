using CodingChallenge.Data.Classes.Interfaces;
using System;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }
        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
