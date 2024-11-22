using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Unidad
    {
        //inicializa
        private CD_Conexion Conexion;
        private Unidad unidad;
        private List<Unidad> listaUnidad;
        // Método para listar todos los edificios
        public List<Unidad> ListaUnidades()
        {
            // Instancia de conexión y lista
            Conexion = new CD_Conexion();
            List<Unidad> listaUnidad = new List<Unidad>();

            try
            {
                Conexion.SetConsutarProcedure("SpMostrar_Unidad"); // Procedimiento almacenado para listar unidades

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    // Creación de objeto Unidad
                    Unidad unidad = new Unidad
                    {
                        Id = (int)Conexion.Lector["Id"], // ID de la unidad
                        Propietario = new Propietario
                        {
                            Id = (int)Conexion.Lector["PropietarioId"],
                            Nombre = Conexion.Lector["PropietarioNombre"] is DBNull ? null : (string)Conexion.Lector["PropietarioNombre"],
                            Apellido = Conexion.Lector["PropietarioApellido"] is DBNull ? null : (string)Conexion.Lector["PropietarioApellido"]
                        },
                        NumUnidad = (int)Conexion.Lector["NumUnidad"], // Número de la unidad
                        Piso = (int)Conexion.Lector["Piso"], // Número del piso
                        Porcentaje = (decimal)Conexion.Lector["Porcentaje"], // Porcentaje de contribución
                        GastosMensuales = (decimal)Conexion.Lector["GastosMensuales"], // Gastos mensuales de la unidad
                        Edificio = new Edificio
                        {
                            Id = (int)Conexion.Lector["EdificioId"],
                            Nombre = Conexion.Lector["EdificioNombre"] is DBNull ? null : (string)Conexion.Lector["EdificioNombre"]
                        }
                    };

                    // Añadir el objeto Unidad a la lista
                    listaUnidad.Add(unidad);
                }

                return listaUnidad;
            }
            catch (Exception ex)
            {
                throw ex; // Manejo de excepciones
            }
            finally
            {
                Conexion.CerrarConection(); // Cerrar conexión
            }
        }

        // Método para insertar una nueva Unidad
        public void InsertarUnidad(Unidad unidad)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpInsertar_Unidad");

                
                Conexion.SetearParametro("@NumUnidad", unidad.NumUnidad);
                Conexion.SetearParametro("@Piso", unidad.Piso);
                Conexion.SetearParametro("@Porcentaje", unidad.Porcentaje);
                Conexion.SetearParametro("@GastosMensuales", unidad.GastosMensuales);
                Conexion.SetearParametro("@EdificioId", unidad.Edificio.Id);
                Conexion.SetearParametro("@PropietarioId", unidad.Propietario.Id);


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

        // Método para editar una Unidad existente
        public void EditarUnidad(Unidad unidad)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEditar_Unidad");

                Conexion.SetearParametro("@Id", unidad.Id);
                Conexion.SetearParametro("@NumUnidad", unidad.NumUnidad);
                Conexion.SetearParametro("@Piso", unidad.Piso);
                Conexion.SetearParametro("@Porcentaje", unidad.Porcentaje);
                Conexion.SetearParametro("@GastosMensuales", unidad.GastosMensuales);
                Conexion.SetearParametro("@EdificioId", unidad.Edificio.Id);
                Conexion.SetearParametro("@PropietarioId", unidad.Propietario.Id);

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

        // Método para eliminar una Unidad por su Id
        public void EliminarUnidad(int id)
        {
            Conexion = new CD_Conexion();

            try
            {
                Conexion.SetConsutarProcedure("SpEliminar_Unidad");

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

        public bool ValidarUnidad(int NumUnidad)
        {
            Conexion = new CD_Conexion();
            try
            {
                // Consulta para verificar si existe un Edificio con el nombre dado
                Conexion.SetConsutar("SELECT COUNT(*) FROM Unidad WHERE Nombre = @NumUnidad");
                Conexion.SetearParametro("@NumUnidad", NumUnidad);

                Conexion.EjecutarLectura();

                // Leer el resultado del conteo
                Conexion.Lector.Read();
                int count = Convert.ToInt32(Conexion.Lector[0]);

                return count > 0; // Retorna true si el conteo es mayor a 0
            }
            catch (Exception ex)
            {
                // Agregar contexto adicional al error
                throw new Exception("Error al validar el nombre del edificio.", ex);
            }
            finally
            {
                Conexion.CerrarConection();
            }
        }
        public List<Unidad> UnidadBuscar(string buscar)
        {
            Conexion = new CD_Conexion();
            listaUnidad = new List<Unidad>();

            try
            {
                Conexion.SetConsutarProcedure("SpBuscar_unidad");

                Conexion.SetearParametro("@txt_buscar", buscar);

                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    unidad = new Unidad();

                    // Asignación de valores desde el lector
                    unidad.Id = (int)Conexion.Lector["Id"];
                    unidad.NumUnidad = (int)Conexion.Lector["NumUnidad"];
                    unidad.Piso = (int)Conexion.Lector["Piso"];
                    unidad.Porcentaje = (decimal)Conexion.Lector["Porcentaje"];
                    unidad.GastosMensuales = (decimal)Conexion.Lector["GastosMensuales"];

                    // Manejo de relaciones
                    unidad.Edificio = new Edificio
                    {
                        Id = (int)Conexion.Lector["IdEdificio"],
                        Nombre = (string)Conexion.Lector["NombreEdificio"]
                    };

                    unidad.Propietario = new Propietario
                    {
                        Id = (int)Conexion.Lector["IdPropietario"],
                        Nombre = (string)Conexion.Lector["NombrePropietario"],
                        Apellido = (string)Conexion.Lector["ApellidoPropietario"]
                    };

                    // Agregar la unidad a la lista
                    listaUnidad.Add(unidad);
                }

                return listaUnidad;
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
