using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Utilidades
{

    internal class FicherosLeer
    {
        public static void cargarFicheros()
        {
            try
            {
                if (!File.Exists(Program.bibliotecaFichero))
                {
                    File.Create(Program.bibliotecaFichero).Dispose();
                }
                if (!File.Exists(Program.clienteFichero))
                {
                    File.Create(Program.clienteFichero).Dispose();
                }
                if (!File.Exists(Program.libroFichero))
                {
                    File.Create(Program.libroFichero).Dispose();
                }
                if (!File.Exists(Program.prestamoFichero))
                {
                    File.Create(Program.prestamoFichero).Dispose();
                }

                using (StreamReader sr = new StreamReader(Program.bibliotecaFichero))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(';');

                        long idBiblioteca = long.Parse(partes[0]);
                        string nombre = partes[1];
                        string direccion = partes[2];

                        BibliotecaDto bibliotecaAgregar = new BibliotecaDto(idBiblioteca, nombre, direccion);
                        Program.listaBibliotecas.Add(bibliotecaAgregar);
                    }
                }
                using (StreamReader sc = new StreamReader(Program.clienteFichero))
                {

                    string linea;
                    while ((linea = sc.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(";");

                        ClienteDtos cli = new ClienteDtos(long.Parse(partes[0]), long.Parse(partes[1]), partes[2], partes[4], partes[5], DateTime.Parse(partes[7]), partes[10], partes[11]);
                        Program.listaClientes.Add(cli);

                    }
                }
                using (StreamReader sl = new StreamReader(Program.libroFichero))
                {
                    string linea;
                    while ((linea = sl.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(";");

                    }
                }
                using (StreamReader sp = new StreamReader(Program.prestamoFichero))
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los ficheros: " + ex.Message);
            }
        }
        public static void GuardarFicheros()
        {
            try
            {
                char sn = Convert.ToChar(Console.ReadLine().ToLower());
                if (sn == 's')
                {
                    using (StreamWriter bi = new StreamWriter(Program.bibliotecaFichero, true))
                    {
                        foreach (BibliotecaDto b in Program.listaBibliotecas)
                        {
                            bi.WriteLine(b.ToString("ficheroBiblioteca"));
                        }
                    }
                    using (StreamWriter cl = new StreamWriter(Program.clienteFichero, true))
                    {
                        foreach (ClienteDtos c in Program.listaClientes)
                        {
                            cl.WriteLine(c.ToString("clienteFichero"));
                        }
                    }
                    using (StreamWriter li = new StreamWriter(Program.libroFichero, true))
                    {
                        foreach (LibroDtos l in Program.listaLibro)
                        {
                            li.WriteLine(l.ToString());
                        }
                    }
                    using (StreamWriter pr = new StreamWriter(Program.prestamoFichero, true))
                    {
                        foreach (PrestamoDtos p in Program.listaPrestamo)
                        {
                            pr.WriteLine(p.ToString());
                        }
                    }

                    Console.WriteLine("Se ha guardado correctamente");
                }
                else
                {
                    Console.WriteLine("No se guardaron los cambios");
                }



            } catch (Exception) { throw; }
        }
        public static void SobreescribirLineaExistente()
        {
            try
            {
                string rutaArchivo = "archivo.txt";
                Console.WriteLine("Escriba numero de una linea");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Escriba el texto a reeemplazar");
                string textoNuevo = Console.ReadLine();

                string[] lineas = File.ReadAllLines(Program.bibliotecaFichero);
                if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                {
                    // Reemplazar el contenido de la línea específica
                    lineas[numeroLinea - 1] = textoNuevo;

                    // Sobrescribir el archivo con las líneas actualizadas
                    File.WriteAllLines(rutaArchivo, lineas);

                    Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
                }
                else
                {
                    Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                }

            }
            catch (Exception) { throw; }
        }
        public static void SobreescribirPosicionLineaEspecifica()
        {
            try
            {
                Console.WriteLine("Ingrese el numero de una linea");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de posicion");
                int numeroPosicion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el texto que deseas");
                string nuevoTexto = Console.ReadLine();

                string[] leerLineas = File.ReadAllLines(Program.bibliotecaFichero);

                if (numeroLinea >= 1 && numeroLinea <= leerLineas.Length)
                {

                    string linea = leerLineas[numeroLinea - 1];

                    if (numeroPosicion >= 0 && numeroPosicion <= linea.Length)
                    {
                        string nuevaLinea = linea.Insert(numeroPosicion, nuevoTexto);
                        // Reemplazar la línea original con la línea modificada
                        leerLineas[numeroLinea - 1] = nuevaLinea;

                        // Sobrescribir el archivo con las líneas actualizadas
                        File.WriteAllLines(Program.bibliotecaFichero, leerLineas);

                        Console.WriteLine("El texto se ha escrito correctamente en la posición especificada de la línea.");
                    }
                }
                else
                {
                    Console.WriteLine("Fuera de rango");
                }

            }
            catch (Exception) { throw; }
        }
        public static void InsertarLinea()
        {
            try
            {
                Console.WriteLine("Ingrese el numero de la linea");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de la posicion");
                int numeroPosicion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el texto a agregar");
                string nuevoTexto = Console.ReadLine();

                string[] leerLineas = File.ReadAllLines(Program.bibliotecaFichero);
                if (numeroLinea >= 1 && numeroLinea < leerLineas.Length)
                {
                    string posicionLinea = leerLineas[numeroLinea - 1];
                    if (numeroPosicion >= 0 && numeroPosicion < posicionLinea.Length)
                    {
                        string nuevaLinea = posicionLinea.Insert(numeroPosicion, nuevoTexto);
                        leerLineas[numeroLinea - 1] = nuevaLinea;

                        Console.WriteLine("¿Desea guardar los cambios? s/n");
                        char sn = Convert.ToChar(Console.ReadLine());
                        if (sn == 's')
                        {
                            File.WriteAllLines(Program.bibliotecaFichero, leerLineas);
                            Console.WriteLine("El texto se ha escrito correctamente");
                        }
                        else
                        {
                            Console.WriteLine("El texto no se ha escrito correctamente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fuera de rango");
                    }
                }
               
            } catch (Exception) { throw; }
         }

        public static void modificarLinea()
        {
            Console.WriteLine("Ingrese el numero de la linea");
            int numeroLinea = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo texto");
            string nuevoTexto = Console.ReadLine();

            string[] leerLineas = File.ReadAllLines(Program.bibliotecaFichero);
            if (numeroLinea >= 1 && numeroLinea < leerLineas.Length)
            {
                leerLineas[numeroLinea - 1] = nuevoTexto;
                Console.WriteLine("¿Desea guardar los cambios?s/n");
                char sn = Convert.ToChar(Console.ReadLine());
                if (sn == 's')
                {
                    File.WriteAllLines(Program.bibliotecaFichero, leerLineas);
                    Console.WriteLine("El texto se ha escrito correctamente");
                }
                else
                {
                    Console.WriteLine("El texto no se ha escrito correctamente");
                }
            }
            else
            {
                Console.WriteLine("Fuera de rango");
            }
        }
    }
}
