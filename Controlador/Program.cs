using GestionBilioteca.Dtos;
using GestionBilioteca.Servicios;
using System.Globalization;

namespace GestionBilioteca.Controlador
{
    internal class Program
    {
        public static List<BibliotecaDto> listaBibliotecas = new List<BibliotecaDto>();
        public static List<ClienteDtos> listaClientes = new List<ClienteDtos>();
        public static List<LibroDtos> listaLibro = new List<LibroDtos>();
        public static List<PrestamoDtos> listaPrestamo = new List<PrestamoDtos>();

        public static Dictionary<long, BibliotecaDto> idBiblioDictionary = new Dictionary<long, BibliotecaDto>();
        public static Dictionary<string, ClienteDtos> dniClienteDictionary = new Dictionary<string, ClienteDtos>();
        public static Dictionary<long, LibroDtos> idLibroDictionary = new Dictionary<long, LibroDtos>();
        public static Dictionary<int, PrestamoDtos> idPrestamoDictionary = new Dictionary<int, PrestamoDtos>();

        public static DateTime dateTime = DateTime.Now;
        public static string formato = $"{dateTime.ToString("dd-MM-yyyy")}";
        public static string bibliotecaFichero = $"{formato} Bliblioteca.txt";
        public static string clienteFichero = $"{formato} Cliente.txt";
        public static string libroFichero = $"{formato} Libro.txt";
        public static string prestamoFichero = $"{formato} Prestamo.txt";
        static void Main(string[] args)
        {
            MenuInterface mi = new MenuImplementacion();
            OperativaInterface oi = new OperativaImplementacion();

            int opcion;
            bool esCerrado = false;

            try
            {
                Utilidades.FicherosLeer.cargarFicheros();
                Utilidades.Utils.GuardarIdDictionary();

                do
                {
                    opcion = mi.MenuBiblioteca();
                    switch (opcion)
                    {
                        case 0:

                            Console.WriteLine("Guardar cambios? (s/n)");
                            Utilidades.FicherosLeer.GuardarFicheros();
                            esCerrado = true;

                            break;
                        case 1:
                            oi.AltaBiblioteca();
                            break;
                        case 2:
                            oi.AltaCliente();
                            break;
                        case 3:
                            oi.AltaLibro();
                            break;
                        case 4:
                            mi.menuPrestamo();
                            break;
                        default: Console.WriteLine("La opcion no existe");
                            break;

                    }

                } while (!esCerrado);
            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo leer/escribir: " + e.Message);
            }
        }       
    }
}
