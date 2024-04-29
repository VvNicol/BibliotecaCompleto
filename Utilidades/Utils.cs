using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Utilidades
{
    internal class Utils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long calcularId()
        {
            try
            {
                long idCalcular;
                int tamanioLista = Program.listaBibliotecas.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaBibliotecas.Count() + 1;
                } else
                {
                    idCalcular = 1;
                }
                return idCalcular;
            } catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long calcularIdCliente()
        {
            try {
                long idCalcular;
                int tamanioLista = Program.listaClientes.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaClientes.Count() + 1;
                }
                else
                {
                    idCalcular = 1;
                }
                return idCalcular;
            } catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long calcularIdLibro()
        {
            try
            {
                long idCalcular;
                int tamanioLista = Program.listaLibro.Count();

                if (tamanioLista > 0)
                {
                    idCalcular = Program.listaLibro.Count() + 1;
                }
                else
                {
                    idCalcular = 1;
                }
                return idCalcular;

            } catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void mostrarBibliotecas()
        {
            try {
                Console.WriteLine("Bibliotecas: ");
                Console.WriteLine("------------");

                foreach (var bibli in Program.idBiblioDictionary)
                {
                    Console.WriteLine($"Key: {bibli.Key}, Value: {bibli.Value}");
                }

            } catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void mostrarClientes()
        {
            try {
                Console.WriteLine("Clientes: ");
                Console.WriteLine("------------");

                foreach (var cli in Program.dniClienteDictionary)
                {
                    Console.WriteLine($"{cli.Key},{cli.Value}");
                }
            } catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void mostrarLibros()
        {
            try
            {
                Console.WriteLine("Libros");
                Console.WriteLine("------------");
                foreach (LibroDtos lib in Program.listaLibro)
                {
                    Console.WriteLine(lib.ToString("formato"));
                }

            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GuardarIdDictionary()
        {
            foreach (BibliotecaDto biblioteca in Program.listaBibliotecas)
            {
                if (!Program.idBiblioDictionary.ContainsKey(biblioteca.Id))
                {
                    Program.idBiblioDictionary.Add(biblioteca.Id, biblioteca);
                }
            }
            foreach (ClienteDtos cliente in Program.listaClientes)
            {
                if (!Program.dniClienteDictionary.ContainsKey(cliente.DniCompletoCliente))
                {
                    Program.dniClienteDictionary.Add(cliente.DniCompletoCliente, cliente);
                }
            }
            foreach (LibroDtos libro in Program.listaLibro)
            {
                if (!Program.idLibroDictionary.ContainsKey(libro.IdLibro))
                {
                    Program.idLibroDictionary.Add(libro.IdLibro, libro);
                }
            }
            foreach (PrestamoDtos prestamo in Program.listaPrestamo)
            {
                if (!Program.idPrestamoDictionary.ContainsKey(prestamo.IdPrestamo))
                {
                    Program.idPrestamoDictionary.Add(prestamo.IdPrestamo, prestamo);

                }
            }


        }

       
    }
}
