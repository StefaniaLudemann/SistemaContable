using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Edificio
    {

        //inicializa
        private CD_Conexion Conexion;
        private Edificio edificio;
        private List<Edificio> listaEdificio;


        //Método Mostrar

        public List<Edificio> ListaEdificios()
        {
            // Instancia
            Conexion = new CD_Conexion();
            listaEdificio = new List<Edificio>();

            try
            {
                Conexion.SetConsutarProcedure("SpMostrar_edificio"); // Cambio de nombre de procedimiento almacenado

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    // Creación de objeto Edificio
                    edificio = new Edificio();

                    // Asignación de valores desde el lector a la propiedad del objeto Edificio
                    edificio.Id = (int)Conexion.Lector["Id"]; // Cambio de propiedad Id_categoria a Id_edificio
                    edificio.Nombre = (string)Conexion.Lector["Nombre"];
                    edificio.Direccion = (string)Conexion.Lector["Direccion"];


                    // Añadir el objeto Edificio a la lista
                    listaEdificio.Add(edificio);
                }

                return listaEdificio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }
        // Método Insertar

        public void InsertarEdificio(Edificio Nuevo)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpInsertar_edificio");

                Conexion.SetearParametro("@Nombre", Nuevo.Nombre);
                Conexion.SetearParametro("@Direccion", Nuevo.Direccion);

                Conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }
        // Método Editar

        public void EditarEdificio(Edificio edificio)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEditar_edificio");

                Conexion.SetearParametro("@Id", edificio.Id); // Cambio de Id_categoria a Id
                Conexion.SetearParametro("@Nombre", edificio.Nombre);
                Conexion.SetearParametro("@Direccion", edificio.Direccion);


                Conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }
        // Método Eliminar

        public void EliminarEdificio(int Id)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEliminar_edificio");

                Conexion.SetearParametro("@Id", Id); 

                Conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }
        // Método Buscar

        public List<Edificio> EdificioBuscar(string buscar)
        {
            Conexion = new CD_Conexion();
            listaEdificio = new List<Edificio>();

            try
            {
                Conexion.SetConsutarProcedure("SpBuscar_edificio");

                Conexion.SetearParametro("@txt_buscar", buscar);

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    edificio = new Edificio();

                    edificio.Id = (int)Conexion.Lector["Id"]; 
                    edificio.Nombre = (string)Conexion.Lector["Nombre"];
                    edificio.Direccion = (string)Conexion.Lector["Direccion"];


                    listaEdificio.Add(edificio);
                }

                return listaEdificio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }

        public bool ValidarEdificio(string Nombre)
        {
            Conexion = new CD_Conexion();
            try
            {
                // Consulta para verificar si existe un Edificio con el nombre dado
                Conexion.SetConsutar("SELECT COUNT(*) FROM Edificios WHERE Nombre = @Nombre");
                Conexion.SetearParametro("@Nombre", Nombre);

                Conexion.EjecutarLectura();

                // Verificar si hay alguna fila devuelta por la consulta
                if (Conexion.Lector.HasRows)
                {
                    // Leer el valor del primer campo (que es el resultado del conteo)
                    Conexion.Lector.Read();
                    int count = Convert.ToInt32(Conexion.Lector[0]);
                    return count > 0; // Si el conteo es mayor que 0, el Edificio existe
                }
                else
                {
                    // Si no hay filas, no hay resultados, el Edificio no existe
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }

    }
}
