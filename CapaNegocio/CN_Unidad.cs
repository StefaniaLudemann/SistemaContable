using CapaDatos;
using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Unidad
    {
        private CD_Unidad _CD_Unidad;

        // Método para listar las Unidades
        public List<Unidad> ListaUnidades()
        {
            _CD_Unidad = new CD_Unidad();

            return _CD_Unidad.ListaUnidades();
        }

        // Método para validar la existencia de una Unidad
        public bool ValidarUnidad(int NumUnidad)
        {
            _CD_Unidad = new CD_Unidad();

            return _CD_Unidad.ValidarUnidad(NumUnidad);
        }

        // Método para insertar una Unidad en la base de datos
        public void InsertarUnidad(Unidad nuevaUnidad)
        {
            _CD_Unidad = new CD_Unidad();

            _CD_Unidad.InsertarUnidad(nuevaUnidad);
        }

        // Método para editar una Unidad en la base de datos
        public void EditarUnidad(Unidad unidad)
        {
            _CD_Unidad = new CD_Unidad();

            _CD_Unidad.EditarUnidad(unidad);
        }

        // Método para eliminar una Unidad de la base de datos
        public void EliminarUnidad(int Id)
        {
            _CD_Unidad = new CD_Unidad();

            _CD_Unidad.EliminarUnidad(Id);
        }

        // Método para buscar una Unidad por número de unidad o propietario
        public List<Unidad> UnidadBuscar(string buscar)
        {
            _CD_Unidad = new CD_Unidad();

            return _CD_Unidad.UnidadBuscar(buscar);
        }
    }
}
