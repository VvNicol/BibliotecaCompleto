using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBilioteca.Dtos
{
    internal class LibroDtos
    {
        long idLibro;
        long idBiblioteca;
        long idCliente;
        string tituloLibro = "aaaaa";
        string subtituloLibro = "aaaaa";
        string autorLibro = "aaaaa";
        int isbnLibro = 11111;
        int numeroEdicionLibro = 11111;
        string editorialLibro = "aaaaa";
        int stockLibro = 11111;
        int stockPrestado = 11111;

        override

        public string ToString()
        {
            string Libro = $"{idLibro};{idBiblioteca};{tituloLibro};{subtituloLibro};{autorLibro};{isbnLibro};{numeroEdicionLibro};{editorialLibro};{stockLibro};{stockPrestado}";
            return Libro;
        }
        public string ToString(string formato)
        {
            string Libro = $"id: {idLibro};Titulo: {tituloLibro}; Disponibilidad{stockLibro}/{stockPrestado}";
            return Libro;
        }
        public LibroDtos()
        {
        }

        public LibroDtos(long idLibro, long idBiblioteca, string tituloLibro, string subtituloLibro,
            string autorLibro, int isbnLibro, int numeroEdicionLibro, string editorialLibro, int stockLibro, int stockPrestado)
        {
            this.idLibro = idLibro;
            this.idBiblioteca = idBiblioteca;
            this.tituloLibro = tituloLibro;
            this.subtituloLibro = subtituloLibro;
            this.autorLibro = autorLibro;
            this.isbnLibro = isbnLibro;
            this.numeroEdicionLibro = numeroEdicionLibro;
            this.editorialLibro = editorialLibro;
            this.stockLibro = stockLibro;
            this.stockPrestado = stockPrestado;
        }

        public long IdLibro { get => idLibro; set => idLibro = value; }
        public long IdBiblioteca { get => idBiblioteca; set => idBiblioteca = value; }
        public long IdCliente { get => idCliente; set => idCliente = value; }
        public string TituloLibro { get => tituloLibro; set => tituloLibro = value; }
        public string SubtituloLibro { get => subtituloLibro; set => subtituloLibro = value; }
        public string AutorLibro { get => autorLibro; set => autorLibro = value; }
        public int IsbnLibro { get => isbnLibro; set => isbnLibro = value; }
        public int NumeroEdicionLibro { get => numeroEdicionLibro; set => numeroEdicionLibro = value; }
        public string EditorialLibro { get => editorialLibro; set => editorialLibro = value; }
        public int StockLibro { get => stockLibro; set => stockLibro = value; }
        public int StockPrestado { get => stockPrestado; set => stockPrestado = value; }
    }
}
