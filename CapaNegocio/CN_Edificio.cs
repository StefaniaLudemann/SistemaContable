using CapaDatos;
using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Edificio
    {
        // Método para listar los Edificios

        private CD_Edificio _CD_Edificio;

        // Método para listar los Edificios en la DataGridView
        public List<Edificio> ListaEdificios()
        {
            _CD_Edificio = new CD_Edificio();

            return _CD_Edificio.ListaEdificios();
        }
        // Método para validar la existencia de un Edificio

        public bool ValidarEdificio(string Nombre)
        {
            _CD_Edificio = new CD_Edificio();

            return _CD_Edificio.ValidarEdificio(Nombre);
        }
        // Método para insertar un Edificio en la base de datos

        public void InsertarEdificio(Edificio Nuevo)
        {
            _CD_Edificio = new CD_Edificio();

            _CD_Edificio.InsertarEdificio(Nuevo);
        }
        // Método para editar un Edificio en la base de datos

        public void EditarEdificio(Edificio edificio)
        {
            _CD_Edificio = new CD_Edificio();

            _CD_Edificio.EditarEdificio(edificio);
        }
        // Método para eliminar un Edificio de la base de datos

        public void EliminarEdificio(int Id)
        {
            _CD_Edificio = new CD_Edificio();

            _CD_Edificio.EliminarEdificio(Id);
        }
        // Método para buscar un Edificio por su nombre en la base de datos

        public List<Edificio> EdificioBuscar(string buscar)
        {
            _CD_Edificio = new CD_Edificio();

            return _CD_Edificio.EdificioBuscar(buscar);
        }

    }
}
