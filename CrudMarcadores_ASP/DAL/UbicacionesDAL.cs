using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UbicacionesDAL
    {
        SqlBDHelper oConexion;

        //Iniciar la conexion con la base de datos
        public UbicacionesDAL()
        {
            oConexion = new SqlBDHelper();
        }
        public bool Agregar(ubicacionesBLL OubicacionesBLL)
        {
            MySqlCommand cmdComando = new MySqlCommand();
            cmdComando.CommandText = "INSERT INTO direcciones (Ubicacion,Latitud,Longitud,Placas) VALUES(@Ubicacion,@Latitud,@Longitud,@Placas) ";
            cmdComando.Parameters.AddWithValue("@Ubicacion", OubicacionesBLL.Ubicacion);
            cmdComando.Parameters.AddWithValue("@Latitud", OubicacionesBLL.Latitud);
            cmdComando.Parameters.AddWithValue("@Longitud", OubicacionesBLL.Longitud);
            cmdComando.Parameters.AddWithValue("@Placas", OubicacionesBLL.Placas);


            return oConexion.EjecutarComandoSQL(cmdComando);
            
        }
        public bool Eliminar( ubicacionesBLL ubicacionesBLL) {
           
            MySqlCommand cmdComand = new MySqlCommand();
            cmdComand.CommandText = "DELETE FROM direcciones WHERE ID = @ID";
            cmdComand.Parameters.AddWithValue("@ID", ubicacionesBLL.ID);
            //return 

            return oConexion.EjecutarComandoSQL(cmdComand); ;
        }
        public bool Modificar(ubicacionesBLL OubicacionesBLL) {
            MySqlCommand cmdComando = new MySqlCommand();
            cmdComando.CommandText = "UPDATE direcciones SET Ubicacion=@Ubicacion, Latitud=@Latitud, Longitud=@Longitud, Placas=@Placas WHERE ID =@ID";
            cmdComando.Parameters.AddWithValue("@Ubicacion", OubicacionesBLL.Ubicacion);
            cmdComando.Parameters.AddWithValue("@Latitud", OubicacionesBLL.Latitud);
            cmdComando.Parameters.AddWithValue("@Longitud", OubicacionesBLL.Longitud);
            cmdComando.Parameters.AddWithValue("@Placas", OubicacionesBLL.Placas);
            cmdComando.Parameters.AddWithValue("@ID", OubicacionesBLL.ID);
            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public DataTable Listar()
        {
            MySqlCommand cmdComando = new MySqlCommand();
            cmdComando.CommandText = "SELECT * FROM direcciones"; //Setencia SQL (BD)
            cmdComando.CommandType = CommandType.Text;//Tipo de comndo

            DataTable TablaResultado = oConexion.EjecutarSentenciaSQL(cmdComando);
            return TablaResultado;
        }
    }
}
