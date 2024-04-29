using GestionBilioteca.Dtos;

namespace GestionBilioteca.Servicios
{
    internal interface OperativaInterface
    {
        /// <summary>
        /// 
        /// </summary>
        void AltaBiblioteca();
        /// <summary>
        /// 
        /// </summary>
        void AltaCliente();
        /// <summary>
        /// 
        /// </summary>
        void AltaLibro();
        /// <summary>
        /// 
        /// </summary>
        void AltaPrestamos();
        /// <summary>
        /// 
        /// </summary>
        void DevolucionLibro();
    }
}