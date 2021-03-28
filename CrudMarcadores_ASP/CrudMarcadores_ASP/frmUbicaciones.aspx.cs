using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace CrudMarcadores_ASP
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicacionesBLL oUbicacionesBLL;
        UbicacionesDAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            ListarUbicaiones();
            }
        }

        //Metodo que lista los datos de la BD en una taba
        public void ListarUbicaiones()
        {
            oUbicacionesDAL = new UbicacionesDAL();
            tablaUbicaciones.DataSource = oUbicacionesDAL.Listar();
            tablaUbicaciones.DataBind();
        }

        //Metodo Agregar
        public ubicacionesBLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicacionesBLL();

            //Recolectar datos
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLatitud.Text;
            oUbicacionesBLL.Longitud = txtLongitud.Text;
            oUbicacionesBLL.Placas = txtPlacas.Text;
            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaiones();
        }

        protected void SelecionDeRegistro(object sender, GridViewCommandEventArgs e)
        {
            int Fila = int.Parse(e.CommandArgument.ToString());
            txtID.Value = tablaUbicaciones.Rows[Fila].Cells[1].Text;
            txtUbicacion.Text = tablaUbicaciones.Rows[Fila].Cells[2].Text;
            txtLatitud.Text = tablaUbicaciones.Rows[Fila].Cells[3].Text;
            txtLongitud.Text = tablaUbicaciones.Rows[Fila].Cells[4].Text;
            txtPlacas.Text = tablaUbicaciones.Rows[Fila].Cells[5].Text;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false; 
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaiones();

        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaiones();
        }

        protected void Limpiar(object sender, EventArgs e)
        {
            txtID.Value = null;
            txtUbicacion.Text = "Roma Nte., 06700 Ciudad de México, CDMX, México";
            txtLatitud.Text = "19.4199042";
            txtLongitud.Text = "-99.169275";
            txtPlacas.Text = "";
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }
    }
}