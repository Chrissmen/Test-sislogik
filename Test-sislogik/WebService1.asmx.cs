using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Test_sislogik.clases;

namespace Test_sislogik
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Test_sislogik.clases.funciones funcionessys = new clases.funciones();
        [WebMethod]
        public string SendEmpData(string xmldata)
        {

            try
            {
                funcionessys.Sp_Alta_Empleados_XML(xmldata);
                return "WS SendEmpData Ejecutado correctamente";
            }
            catch(Exception ex)
            {

                return "Error en WS SendEmpData :" + ex.Message.ToString();
            }
            
        }
    }
}
