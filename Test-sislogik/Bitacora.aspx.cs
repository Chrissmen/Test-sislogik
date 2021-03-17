using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_sislogik.clases;

namespace Test_sislogik
{
    public partial class Bitacora : System.Web.UI.Page
    {
        Test_sislogik.clases.funciones funcionessys = new clases.funciones();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                //BINDEAR GRIDVIEW1 DESDE WS_LOGGERSERVICE 
                funcionessys.WS_loggerhistorial(GridView1);

            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            funcionessys.WS_loggerhistorial(GridView1);
        }
    }
}