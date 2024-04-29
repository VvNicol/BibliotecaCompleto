using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Utilidades
{
    internal class Organizar
    {
        public static void OrganizarLibrosFechas()
        {
            try
            {
                Console.WriteLine("Organizar por fechas");
                int n = Program.listaPrestamo.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (Program.listaPrestamo[j].FchaEntregaEsperada > Program.listaPrestamo[j + 1].FchaEntregaEsperada)
                        {
                            // Intercambiar los préstamos
                            PrestamoDtos temp = Program.listaPrestamo[j];
                            Program.listaPrestamo[j] = Program.listaPrestamo[j + 1];
                            Program.listaPrestamo[j + 1] = temp;
                        }
                    }
                }

                Console.WriteLine("organizar alfabeticamente");
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        // Comparar los títulos de los libros y ordenar alfabéticamente
                        if (string.Compare(Program.listaLibro[j].TituloLibro, Program.listaLibro[j + 1].TituloLibro, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            // Intercambiar los libros
                            LibroDtos temp = Program.listaLibro[j];
                            Program.listaLibro[j] = Program.listaLibro[j + 1];
                            Program.listaLibro[j + 1] = temp;
                        }
                    }
                }
                // Imprimir las fechas de entrega esperadas ordenadas
                Console.WriteLine("Fechas de entrega esperadas ordenadas:");
                foreach (var prestamo in Program.listaPrestamo)
                {
                    Console.WriteLine(prestamo.FchaEntregaEsperada.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
