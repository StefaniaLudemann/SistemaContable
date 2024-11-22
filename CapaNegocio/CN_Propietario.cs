using CapaDatos;
using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Propietario
    {
        private CD_Propietario _CD_Propietario;

        // Constructor que recibe la dependencia de la capa de datos
        public CN_Propietario(CD_Propietario cdPropietario)
        {
            _CD_Propietario = cdPropietario; // Inicialización de la capa de datos mediante inyección de dependencias
        }

        // Método para obtener todos los propietarios
        public List<Propietario> ObtenerPropietarios()
        {
            try
            {
                return _CD_Propietario.ListaPropietarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los propietarios.", ex);
            }
        }

        // Método para validar la existencia de un propietario
        public bool ValidarPropietario(string numeroDocumento)
        {
            try
            {
                return _CD_Propietario.ValidarPropietario(numeroDocumento);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el propietario.", ex);
            }
        }

        // Método para agregar un propietario
        public void AgregarPropietario(Propietario nuevoPropietario)
        {
            try
            {
                if (nuevoPropietario == null)
                    throw new ArgumentNullException("El propietario no puede ser nulo.");

                // Validaciones adicionales antes de insertar el propietario
                if (string.IsNullOrEmpty(nuevoPropietario.Nombre))
                    throw new Exception("El nombre es obligatorio.");
                if (string.IsNullOrEmpty(nuevoPropietario.Apellido))
                    throw new Exception("El apellido es obligatorio.");

                _CD_Propietario.InsertarPropietario(nuevoPropietario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el propietario.", ex);
            }
        }

        // Método para editar un propietario
        public void EditarPropietario(Propietario propietario)
        {
            try
            {
                if (propietario == null)
                    throw new ArgumentNullException("El propietario a editar no puede ser nulo.");

                if (propietario.Id <= 0)
                    throw new ArgumentException("El ID del propietario es inválido.");

                _CD_Propietario.EditarPropietario(propietario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el propietario.", ex);
            }
        }

        // Método para eliminar un propietario
        public void EliminarPropietario(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("El ID del propietario debe ser mayor que cero.");

                _CD_Propietario.EliminarPropietario(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el propietario.", ex);
            }
        }

        // Método para buscar propietarios por nombre, apellido o documento
        public List<Propietario> BuscarPropietario(string buscar)
        {
            try
            {
                if (string.IsNullOrEmpty(buscar))
                    throw new ArgumentException("El término de búsqueda no puede estar vacío.");

                return _CD_Propietario.PropietarioBuscar(buscar);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los propietarios.", ex);
            }
        }
    }
}
