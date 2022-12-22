using CodingChallenge.Data.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Portugues : IIdioma
    {
        public string Imprimir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>Lista vazia de formas!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>Relatório de formas</h1>");

                List<TotalForma> totalFormas = new List<TotalForma>();
                foreach (Formas suit in (Formas[])Enum.GetValues(typeof(Formas)))
                {
                    TotalForma nuevaForma = new TotalForma(suit.ToString());
                    totalFormas.Add(nuevaForma);
                }
                foreach (IFormaGeometrica forma in formas)
                {
                    var totalForma = totalFormas.Find(x => x.tipo == forma.GetType().Name);
                    totalForma.totalFormas += 1;
                    totalForma.totalPerimetro += forma.CalcularPerimetro();
                    totalForma.totalArea += forma.CalcularArea();
                }
                decimal valorAreaTotal = 0m;
                decimal valorPerimetroTotal = 0m;
                int cantidadFormas = 0;

                foreach (TotalForma totalForma in totalFormas)
                {
                    cantidadFormas += totalForma.totalFormas;
                    valorAreaTotal += totalForma.totalArea;
                    valorPerimetroTotal += totalForma.totalPerimetro;
                    sb.Append(ObtenerLinea(totalForma.totalFormas, totalForma.totalArea, totalForma.totalPerimetro, totalForma.tipo));
                }
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(cantidadFormas + " formas ");
                sb.Append("Perímetro " + (valorPerimetroTotal).ToString("#.##") + " ");
                sb.Append("Área " + (valorAreaTotal).ToString("#.##"));
            }

            return sb.ToString();
        }
        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | Área {area:#.##} | Perímetro {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
        private static string TraducirForma(string tipo, int cantidad)
        {
            switch (tipo)
            {
                case "Cuadrado":
                    return cantidad == 1 ? "Quadrado" : "Quadrados";
                case "Circulo":
                    return cantidad == 1 ? "Círculo" : "Círculos";
                case "TrianguloEquilatero":
                    return cantidad == 1 ? "Triângulo" : "Triângulos";
                case "Rectangulo":
                    return cantidad == 1 ? "Retângulo" : "Retângulos";
            }
            return string.Empty;
        }
    }
}
