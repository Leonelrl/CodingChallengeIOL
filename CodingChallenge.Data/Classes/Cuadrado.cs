using CodingChallenge.Data.Classes.Interfaces;


namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    {
        private decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }
        public decimal CalcularArea()
        {
             return _lado * _lado;
            
        }
        public decimal CalcularPerimetro()
        {
            return _lado * 4;
           
        }
    }
}
