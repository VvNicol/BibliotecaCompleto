using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Dtos
{
    internal class PrestamoDtos
    {
        int idPrestamo =  11111;
        string dniCliente = "aaaaa";
        int idLibro = 111111;
        int numPrestado = 11111;
        string estadoPrestamo = "aaaaa";

        DateTime fchaPrestamo = DateTime.Today;
        DateTime fchaEntrega = new DateTime(9999, 12, 31);
        DateTime fchaEntregaEsperada = new DateTime(9999, 12, 31);

        override
        public string ToString()
        {
            string formato = $"id prestamo: {idPrestamo}; id cliente: {dniCliente}; id libro: {idLibro}; fecha prestamo: {fchaEntrega}; fecha entrega: {fchaEntrega}";
            return formato ;
        }

        public PrestamoDtos()
        {
        }

        public PrestamoDtos(DateTime fchaEntrega)
        {
            this.fchaEntrega = fchaEntrega;
        }

        public PrestamoDtos(int idPrestamo, string dniCliente, int idLibro, DateTime fchaPrestamo, int numPrestado, DateTime fchaEntregaEsperada, string estadoPrestamo)
        {
            this.idPrestamo = idPrestamo;
            this.dniCliente = dniCliente;
            this.idLibro = idLibro;
            this.fchaPrestamo = fchaPrestamo;
            this.numPrestado = numPrestado;
            this.fchaEntregaEsperada = fchaEntregaEsperada;
            this.estadoPrestamo = estadoPrestamo;
        }



        public int IdPrestamo { get => idPrestamo; set => idPrestamo = value; }
        public string IdCliente { get => dniCliente; set => dniCliente = value; }
        public int IdLibro { get => idLibro; set => idLibro = value; }
        public DateTime FchaPrestamo { get => fchaPrestamo; set => fchaPrestamo = value; }
        public DateTime FchaEntrega { get => fchaEntrega; set => fchaEntrega = value; }
        public int NumPrestado { get => numPrestado; set => numPrestado = value; }
        public string EstadoPrestamo { get => estadoPrestamo; set => estadoPrestamo = value; }
        public DateTime FchaEntregaEsperada { get => fchaEntregaEsperada; set => fchaEntregaEsperada = value; }
    }
}
