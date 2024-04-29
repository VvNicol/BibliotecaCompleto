using GestionBilioteca.Dtos;
using GestionBilioteca.Servicios;

namespace GestionBilioteca.Controlador
{
    internal class OperativaImplementacion : OperativaInterface
    {
        public void AltaBiblioteca()
        {
            try
            {
                long idBiblioteca = Utilidades.Utils.calcularId();
                Console.WriteLine("Ingrese el nombre de la biblioteca");
                string nombreBiblioteca = Console.ReadLine();
                Console.WriteLine("Ingrese direccion");
                string direccionBiblioteca = Console.ReadLine();

                BibliotecaDto biblioteca = new BibliotecaDto(idBiblioteca, nombreBiblioteca, direccionBiblioteca);
                Program.listaBibliotecas.Add(biblioteca);

                Utilidades.Utils.GuardarIdDictionary();
            }
            catch (Exception) { throw; }
        }

        public void AltaCliente()
        {
            try
            {
                Utilidades.Utils.mostrarBibliotecas();
                long idCliente = Utilidades.Utils.calcularIdCliente();
                Console.WriteLine("Ingrese id de la biblioteca para crear un usuario");
                long idBibliotecaRegistroCliente = Convert.ToInt64(Console.ReadLine());
                bool bibliotecaEncontrada = false;

                
                foreach (BibliotecaDto buscarID in Program.listaBibliotecas)
                {
                    if (buscarID.Id.Equals(idBibliotecaRegistroCliente))
                    {
                        bibliotecaEncontrada = true;
                        Console.WriteLine("Ingrese nombre completo: ");
                        string nombreCompleCliente = Console.ReadLine();
                        Console.WriteLine("Ingrese fcha de nacimiento (yyyy/mm/dd)");
                        DateTime fchaNaciCliente = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Ingrese los numeros del DNI (8 digitos)");
                        int dniClienteRegistro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la letra del DNI (ej: z)");
                        char letraCliente = Convert.ToChar(Console.ReadLine().ToUpper());
                        var dniCl = verificarDni(dniClienteRegistro, letraCliente);
                        bool dniDuplicado = verificarDuplicado(dniClienteRegistro);

                        Console.WriteLine("Ingrese un correo");
                        string correoCliente = Console.ReadLine();

                        ClienteDtos cli = new ClienteDtos(idCliente, idBibliotecaRegistroCliente,
                            nombreCompleCliente, fchaNaciCliente, dniClienteRegistro, letraCliente, correoCliente);
                        Program.listaClientes.Add(cli);

                        Console.WriteLine("Su usuario se ha creado con exito");

                        break;
                    }
                }
                if (!bibliotecaEncontrada)
                {
                    Console.WriteLine("La biblioteca no existe");
                }
                Utilidades.Utils.GuardarIdDictionary();
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dniClienteRegistro"></param>
        /// <returns></returns>
        private bool verificarDuplicado(int dniClienteRegistro)
        {
            try
            {
                foreach (ClienteDtos cliente in Program.listaClientes)
                {
                    if (cliente.DniCompletoCliente.Equals(dniClienteRegistro))
                    {
                        Console.WriteLine("Se ha encontrado duplicados, vuelva a crear un cliente");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception) { throw; }
        }
        
        public void AltaLibro()
        {
            try
            {

                Utilidades.Utils.mostrarBibliotecas();
                long idLibro = Utilidades.Utils.calcularIdLibro();
                Console.WriteLine("Ingrese id de la biblioteca para crear un Libro");
                long idBibliotecaRegistroLibro = Convert.ToInt64(Console.ReadLine());
                bool bibliotecaEncontrada = false;
                foreach (BibliotecaDto biblioteca in Program.listaBibliotecas)
                {
                    if (biblioteca.Id.Equals(idBibliotecaRegistroLibro))
                    {
                        bibliotecaEncontrada = true;
                        Console.WriteLine("Ingrese el titulo de la obra: ");
                        string tituloLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el subtilo de la obra: ");
                        string subtituloLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el autor de la obra: ");
                        string autorLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el ISDN del libro: ");
                        int isbnLibro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el numero de edicion: ");
                        int numEdiciconLibro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la editorial: ");
                        string editorialLibro = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de stock");
                        int numStock = Convert.ToInt32(Console.ReadLine());

                        int numStockDisponible = numStock;

                        LibroDtos stockLibros = new LibroDtos(idLibro, idBibliotecaRegistroLibro, tituloLibro,
                            subtituloLibro, autorLibro, isbnLibro, numEdiciconLibro, editorialLibro, numStock, numStockDisponible);
                        Program.listaLibro.Add(stockLibros);
                        Console.WriteLine("El libro se ha creado correctamente");
                        Utilidades.Utils.GuardarIdDictionary();
                        break;

                    }
                }
                if (!bibliotecaEncontrada)
                {
                    Console.WriteLine("La biblioteca no existe/encontrado");
                }
                
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dniCliente"></param>
        /// <param name="letraCliente"></param>
        /// <returns></returns>
        private int verificarDni(int dniCliente, char letraCliente)
        {
            try
            {
                int dniVerificar = -1;

                int[] resto = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
                char[] letras = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

                int divisor = 23;
                int operacion = dniCliente % divisor;

                int posicionResto = resto[operacion];

                if (letraCliente == letras[posicionResto])
                {

                    Console.WriteLine("DNI válido");
                    dniVerificar = dniCliente; // Asigna el DNI verificado a la variable de retorno
                }
                else
                {
                    Console.WriteLine("La letra ingresada no coincide con la letra calculada.");
                }
                return dniVerificar;
            }
            catch (Exception) { throw; }
        }

        public void AltaPrestamos()
        {
            try
            {
                Utilidades.Utils.mostrarBibliotecas();

                Console.WriteLine("Ingrese el id de la biblioteca");
                Console.WriteLine("--------------------------------");
                int idBib = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("--------------------------------");

                Utilidades.Utils.mostrarClientes();
                Console.WriteLine("Ingrese su DNI completo");
                Console.WriteLine("--------------------------------");

                string dniCompleto = Console.ReadLine();
                Utilidades.Utils.mostrarLibros();
                Console.WriteLine("--------------------------------");

                Console.WriteLine("Ingrese el id del libro");
                Console.WriteLine("--------------------------------");

                int idLibro = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("¿Cuantos libros quiere prestados?");
                Console.WriteLine("--------------------------------");

                int numLibrosPrestados = Convert.ToInt32(Console.ReadLine());
                bool clienteEncontrado = false;
                bool libroEncontrado = false;
                bool stockDisponible = false;

                if (Program.listaClientes.Count > 0)
                {
                    foreach (ClienteDtos cli in Program.listaClientes)
                    {

                        if (cli.IdBibliotecaCliente.Equals(idBib) && cli.DniCompletoCliente.Equals(dniCompleto))
                        {
                            clienteEncontrado = true;
                            break;
                        }
                    }
                    if (!clienteEncontrado)
                    {
                        Console.WriteLine("El cliente no pertenece a la biblioteca");
                    }
                    else
                    {
                        foreach (LibroDtos lib in Program.listaLibro)
                        {

                            if (lib.IdLibro.Equals(idLibro) && lib.IdBiblioteca.Equals(idBib))
                            {
                                libroEncontrado = true;

                                if (lib.StockLibro >= numLibrosPrestados)
                                {
                                    stockDisponible = true;

                                    lib.StockPrestado -= numLibrosPrestados;

                                    int idBibliotecaPrestamo = idBib;
                                    string dniClientePrestamo = dniCompleto;
                                    int idLibroPrestamo = idLibro;
                                    int numPrestadoCliente = numLibrosPrestados;
                                    DateTime fechaInstante = DateTime.Now;
                                    string estado = "en proceso";
                                    DateTime fechaEntregaEsperada = fechaInstante.AddDays(8);
                                    

                                    PrestamoDtos prestamoDtos = new PrestamoDtos(idLibroPrestamo, dniClientePrestamo, idLibro, fechaInstante, numPrestadoCliente, fechaEntregaEsperada, estado) ;
                                    Program.listaPrestamo.Add(prestamoDtos);

                                    Console.WriteLine("Prestamo con exito");
                                    Utilidades.Utils.GuardarIdDictionary();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("No hay libros disponibles");
                                }
                            }
                        }
                    }
                    if (!libroEncontrado)
                    {
                        Console.WriteLine("El libro no se encuentra en la biblioteca");
                    }
                    if (!stockDisponible)
                    {
                        Console.WriteLine("No hay stocks disponibles");

                    }
                }
                
            }
            catch (Exception) { throw; }
        }

        public void DevolucionLibro()
        {
            try
            {
                Console.WriteLine("Ingrese su DNI");
                string dniDevolucion = Console.ReadLine();

                Console.WriteLine("Ingrese el id del libro devuelto:");
                int idLibroDevolucion = Convert.ToInt32(Console.ReadLine());
                DateTime fechaDevolucion = DateTime.Now;               

                foreach (PrestamoDtos prestamo in Program.listaPrestamo)
                {
                    if (prestamo.IdLibro.Equals(idLibroDevolucion) && prestamo.EstadoPrestamo == "en proceso" && prestamo.IdCliente.Equals(dniDevolucion))
                    {
                        if (fechaDevolucion <= prestamo.FchaEntregaEsperada)
                        {
                            prestamo.EstadoPrestamo = "entregado";
                        }
                        else
                        {
                            prestamo.EstadoPrestamo = "entregado con retraso";

                            SuspenderCliente(prestamo.IdCliente);
                        }

                        Console.WriteLine("Libro devuelto con éxito.");

                        PrestamoDtos devolucionLibro = new PrestamoDtos(fechaDevolucion);
                        Program.listaPrestamo.Add(devolucionLibro);

                        return;
                    }
                }

                Console.WriteLine("No se encontró ningún préstamo en proceso para el libro especificado.");

            }
            catch (Exception) { throw; }
        }

        private void SuspenderCliente(string idCliente)
        {
            foreach (ClienteDtos cli in Program.listaClientes)
            {
                if (cli.DniCompletoCliente == idCliente)
                {
                    cli.EstadoSuspencion = true;
                    cli.FchaInicioSuspensión = DateTime.Now;
                    cli.FechaFinSuspensión = cli.FechaFinSuspensión.AddDays(7);
                    Console.WriteLine($"Cliente {cli.NombreCliente} suspendido por 7 días debido a la devolución con retraso.");
                    return;
                }
            }
        }
    }

}