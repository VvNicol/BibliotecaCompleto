using GestionBilioteca.Controlador;
using GestionBilioteca.Dtos;

namespace GestionBilioteca.Servicios
{
    internal class MenuImplementacion : MenuInterface
    {       
        public int MenuBiblioteca()
        {
            try
            {
                 Console.WriteLine("-----------");
                 Console.WriteLine("Menu principal gestion de bibliotecas");
                 Console.WriteLine("0.Cerrar menu");
                 Console.WriteLine("1.Alta biblioteca");
                 Console.WriteLine("2.Alta cliente");
                 Console.WriteLine("3.Alta libro");
                 Console.WriteLine("4.Alta prestamo de libro");
                 Console.WriteLine("-----------");

                 int opcionEscogida = Convert.ToInt32(Console.ReadLine());
                 return opcionEscogida;

            }catch (Exception)
            {
                throw;
            }
            
        }

        public void menuPrestamo()
        {
            OperativaInterface oi = new OperativaImplementacion();
            int opcion;
            bool esCerrado = false;

            try
            {
                do
                {
                    opcion = MenuLibro();
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Volver");
                            esCerrado = true;
                            break;
                        case 1:
                            oi.AltaPrestamos();
                            break;
                        case 2:
                            oi.DevolucionLibro();
                            break;
                        default:
                            Console.WriteLine("La opcion no existe");
                            break;
                    }

                } while (!esCerrado);
            }
            catch (Exception e){throw;}
        }

        /// <summary>
        ///  vista menu prestamo de libro
        /// </summary>
        /// <returns>int</returns>
        private int MenuLibro()
        {
            try
            {
                Console.WriteLine("-----------");
                Console.WriteLine("Menu Prestamo");
                Console.WriteLine("0.Volver");
                Console.WriteLine("1.Sacar prestamo");
                Console.WriteLine("2.Devolver libro");
                Console.WriteLine("-----------");

                int opcionEscogida = Convert.ToInt32(Console.ReadLine());
                return opcionEscogida;

            } catch (Exception e) { throw; }
        }
    }
}