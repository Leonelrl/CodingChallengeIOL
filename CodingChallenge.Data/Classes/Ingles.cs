using CodingChallenge.Data.Classes.Interfaces;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Ingles: IIdioma
    {       
        public string Imprimir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>Shapes report</h1>");

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
                sb.Append(cantidadFormas + " shapes ");
                sb.Append("Perimeter " + (valorPerimetroTotal).ToString("#.##") + " ");
                sb.Append("Area " + (valorAreaTotal).ToString("#.##"));
            }

            return sb.ToString();
        }
        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
        private static string TraducirForma(string tipo, int cantidad)
        {
            switch (tipo)
            {
                case "Cuadrado":
                    return cantidad == 1 ? "Square" : "Squares";
                case "Circulo":
                    return cantidad == 1 ? "Circle" : "Circles";
                case "TrianguloEquilatero":
                    return cantidad == 1 ? "Triangle" : "Triangles";
                case "Rectangulo":
                    return cantidad == 1 ? "Rectangle" : "Rectangles";
            }
            return string.Empty;
        }
    }
}