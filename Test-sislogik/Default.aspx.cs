using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.NetworkInformation;
using System.Globalization;
using Test_sislogik.clases;

namespace Test_sislogik
{
    public partial class _Default : Page
    {
        Test_sislogik.clases.funciones funcionessys = new clases.funciones();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //BINDEAR DROPDOWNLIST DESDE CLASE TIPO DE EMPLADO
                funcionessys.BindddlTipoEmpleado(DdlTipoEmpleado);

                //BINDEAR GRIDVIEW1
                funcionessys.bindearGridViewReporte(DdlTipoEmpleado.SelectedValue, GridView1);



                //CÁLCULO DE PROMEDIO GENERAL

                 funcionessys.CalculoGral(LblImportePromGral, DdlTipoEmpleado.SelectedValue);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            //BINDEAR GRIDVIEW CON FILTRO DE TIPO EMPLEADO
            funcionessys.bindearGridViewReporte(DdlTipoEmpleado.SelectedValue, GridView1);


            //CÁLCULO DE PROMEDIO AGRUPADO
            if (DdlTipoEmpleado.SelectedIndex != 0)
            {
                Lbletiquetaprom.Visible = true;
                funcionessys.CalculoAgrupado(LblImporteProm, DdlTipoEmpleado.SelectedValue);
            }
            else 
            {
                Lbletiquetaprom.Visible = false;
                LblImporteProm.Visible = false;
            }

            
            
            

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        {
            
            // BORRADO LÓGICO DE EMPLEADO
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("nidEmpleado");


            // OBTENER DESDE GRIDVIEW1 EL ID DEL EMPLEADO Y LO ENVIAMOS A CLASE DE BORRADO USANDO SP
            int nidEmpleado = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            funcionessys.Sp_Borrado_Logico_Empleado(nidEmpleado);


            //BINDEO DE GRID PARA VISUALIZAR LOS CAMBIOS DESPUÉS DEL BORRADO
            funcionessys.bindearGridViewReporte(DdlTipoEmpleado.SelectedValue, GridView1);
        }

       
    }
}