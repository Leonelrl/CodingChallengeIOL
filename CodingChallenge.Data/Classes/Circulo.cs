using CodingChallenge.Data.Classes.Interfaces;
using System;


namespace CodingChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }
        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio;
        }
    }
}
