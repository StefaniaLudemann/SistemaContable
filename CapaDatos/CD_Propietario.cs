using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Propietario
    {
        private CD_Conexion Conexion;
        private Propietario propietario;
        private List<Propietario> listaPropietario;

        // Método para listar propietarios
        public List<Propietario> ListaPropietarios()
        {
            Conexion = new CD_Conexion();
            listaPropietario = new List<Propietario>();

            try
            {
                Conexion.SetConsutarProcedure("SpMostrar_propietarios");

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    propietario = new Propietario
                    {
                        Id = (int)Conexion.Lector["Id"],
                        Nombre = (string)Conexion.Lector["Nombre"],
                        Apellido = (string)Conexion.Lector["Apellido"],
                        NUmeroDocumento = (string)Conexion.Lector["NumeroDocumento"],
                        Email = (string)Conexion.Lector["Email"],
                        Telefono = (string)Conexion.Lector["Telefono"],
                        Foto = Conexion.Lector["Foto"] != DBNull.Value ? (string)Conexion.Lector["Foto"] : null
                    };

                    listaPropietario.Add(propietario);
                }

                return listaPropietario;
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

        // Método para insertar un propietario
        public void InsertarPropietario(Propietario nuevo)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpInsertar_propietario");
                Conexion.SetearParametro("@Nombre", nuevo.Nombre);
                Conexion.SetearParametro("@Apellido", nuevo.Apellido);
                Conexion.SetearParametro("@NumeroDocumento", nuevo.NUmeroDocumento);
                Conexion.SetearParametro("@Email", nuevo.Email);
                Conexion.SetearParametro("@Telefono", nuevo.Telefono);
                Conexion.SetearParametro("@Foto", nuevo.Foto);

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

        // Método para editar un propietario
        public void EditarPropietario(Propietario propietario)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEditar_propietario");
                Conexion.SetearParametro("@Id", propietario.Id);
                Conexion.SetearParametro("@Nombre", propietario.Nombre);
                Conexion.SetearParametro("@Apellido", propietario.Apellido);
                Conexion.SetearParametro("@NumeroDocumento", propietario.NUmeroDocumento);
                Conexion.SetearParametro("@Email", propietario.Email);
                Conexion.SetearParametro("@Telefono", propietario.Telefono);
                Conexion.SetearParametro("@Foto", propietario.Foto);

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

        // Método para eliminar un propietario
        public void EliminarPropietario(int id)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEliminar_propietario");
                Conexion.SetearParametro("@Id", id);

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

        // Método para buscar propietarios
        public List<Propietario> PropietarioBuscar(string buscar)
        {
            Conexion = new CD_Conexion();
            listaPropietario = new List<Propietario>();

            try
            {
                Conexion.SetConsutarProcedure("SpBuscar_propietario");
                Conexion.SetearParametro("@txt_buscar", buscar);

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    propietario = new Propietario
                    {
                        Id = (int)Conexion.Lector["Id"],
                        Nombre = (string)Conexion.Lector["Nombre"],
                        Apellido = (string)Conexion.Lector["Apellido"],
                        NUmeroDocumento = (string)Conexion.Lector["NumeroDocumento"],
                        Email = (string)Conexion.Lector["Email"],
                        Telefono = (string)Conexion.Lector["Telefono"],
                        Foto = Conexion.Lector["Foto"] != DBNull.Value ? (string)Conexion.Lector["Foto"] : null
                    };

                    listaPropietario.Add(propietario);
                }

                return listaPropietario;
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

        public bool ValidarPropietario(string numeroDocumento)
        {
            try
            {
                Conexion.SetConsutarProcedure("SpValidarPropietarioPorDocumento");
                Conexion.SetearParametro("@NumeroDocumento", numeroDocumento);
                Conexion.EjecutarLectura();

                // Si se encuentra un propietario, se devuelve true (ya existe)
                if (Conexion.Lector.Read())
                {
                    return true;
                }

                return false; // No existe un propietario con ese documento
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el propietario por documento.", ex);
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }

    }
}
