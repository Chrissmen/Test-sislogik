using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_sislogik.clases;
using System.Data;
using System.Data.SqlClient;

namespace Test_sislogik
{
    public partial class About : Page
    {
        Test_sislogik.clases.funciones funcionessys = new clases.funciones();
        int nidempleado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //VALIDACIÓN DE PARAMETRO QUE DEFINE SI ES UNA ALTA DE EMPLEADO O UNA ACTUALIZACION DE DATOS 
                if (Request.QueryString["nidEmpleado"] != null)
                {
                   
                    bindearFormulario();
                    Button1.Text = "Actualizar";

                }
                else
                {
                    Button1.Text = "Guardar";
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //VALIDACION DEL COMPORTAMIENTO DEL BOTON, SI ES ALTA Ó ACTUALIZACION POR MEDIO DE UN PARAMETRO URL

            if (Request.QueryString["nidEmpleado"] != null)
            {

                nidempleado = Convert.ToInt32(Request.QueryString["nidEmpleado"]);
                funcionessys.Sp_Edicion_Empleado(nidempleado,DropDownList1.SelectedValue, Convert.ToInt32(TxtSeccion.Text.Trim()), TxtNombres.Text.Trim(), TxtApellidos.Text.Trim(), Convert.ToDecimal(TxtHoras.Text.Trim()), Convert.ToDouble(TxtImporte.Text.Trim()), 1);
                LblMsg.Text = "Se han actualizado los datos correctamente";
                Button1.Enabled = false;

                

            }
            else
            {
                funcionessys.Sp_Alta_Empleado(DropDownList1.SelectedValue, Convert.ToInt32(TxtSeccion.Text.Trim()), TxtNombres.Text.Trim(), TxtApellidos.Text.Trim(), Convert.ToDecimal(TxtHoras.Text.Trim()), Convert.ToDouble(TxtImporte.Text.Trim()), 1);
                Response.Redirect("default.aspx");

               

            }



        }

        public void bindearFormulario()
        {
            nidempleado = Convert.ToInt32(Request.QueryString["nidEmpleado"]);
            string consultaSQL = "select nidEmpleado, cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte from Tbl_Empleados WHERE nidEmpleado = " + nidempleado;
            DataSet dtEmpleados = new DataSet();
            dtEmpleados = funcionessys.DevuelveDataSetDesdeSelect(consultaSQL);

            //VALIDAMOS QUE EL DATASET CONTENGA DATOS ANTES DE BINDEAR CONTROLES
            int cuentaResumen = dtEmpleados.Tables[0].Rows.Count;

            if (cuentaResumen != 0)
            {
                DropDownList1.SelectedItem.Text = dtEmpleados.Tables[0].Rows[0][1].ToString();
                TxtSeccion.Text = dtEmpleados.Tables[0].Rows[0][2].ToString().Trim();
                TxtNombres.Text = dtEmpleados.Tables[0].Rows[0][3].ToString().Trim();
                TxtApellidos.Text = dtEmpleados.Tables[0].Rows[0][4].ToString().Trim();
                TxtHoras.Text = dtEmpleados.Tables[0].Rows[0][5].ToString();

                double importe = Convert.ToDouble(dtEmpleados.Tables[0].Rows[0][6].ToString());

                TxtImporte.Text = String.Format("{0:0.##}", importe);
                LblMsg.Text = "";
            }
            else
            {
                LblMsg.Text = "Error en carga de datos";
            
            }

            
        }
    }
}