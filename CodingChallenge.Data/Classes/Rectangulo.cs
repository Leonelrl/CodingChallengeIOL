using CodingChallenge.Data.Classes.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        private decimal _largo;
        private decimal _altura;

        public Rectangulo(decimal largo, decimal altura)
        {
            _largo = largo;
            _altura = altura;
        }
        public decimal CalcularArea()
        {
            return _largo * _altura;

        }
        public decimal CalcularPerimetro()
        {
            return 2 * _largo + 2 * _altura;

        }
    }
}
