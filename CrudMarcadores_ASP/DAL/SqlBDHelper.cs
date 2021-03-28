using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class SqlBDHelper
    {
        DataTable Tabla;
        MySqlConnection strConexion = new MySqlConnection("server=127.0.0.1;database=marcadores;Uid=root;port=3306;password=;");
        MySqlCommand cmd = new MySqlCommand();
        public bool EjecutarComandoSQL(MySqlCommand strSQLComando)
        {
            //INSERTAR, MODIFICAR, BORRAR
            bool Respuesta = true;
            cmd = strSQLComando;
            cmd.Connection = strConexion;
            strConexion.Open();
            Respuesta = cmd.ExecuteNonQuery() > 0;
            strConexion.Close();
            return Respuesta;



        }
        

        public DataTable EjecutarSentenciaSQL(MySqlCommand strSQLComando)
        {
            //SELECCIONAR DATOS DE LA BASE DE DATOS
            //SELECT
            cmd = strSQLComando;
           
            cmd.Connection = strConexion;
            strConexion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();
            return Tabla;

        }
    }
}
