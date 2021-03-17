using System;
using System.Collections.Generic;
using LinqToExcel;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Test_sislogik.WS_LoggerService;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Remotion.Logging;

namespace Test_sislogik.clases
{
    public class funciones
    {
        //INSTANCIA DE CONEXIÓN A DATOS
        
        public SqlConnection cnnSql = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString1"].ConnectionString);

        public DataSet DevuelveDataSetDesdeSelect(string prtSql)
        {
            //CLASE QUE GENERA UN DATASET DESDE UNA CONSULTA SQL
            
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand DB_cmd = new SqlCommand();
            
            cnnSql.Open();
            da = new SqlDataAdapter(prtSql, cnnSql);
            da.Fill(ds, "details");
            cnnSql.Close();
            return ds;

        }

        public string REGRESACAMPO(string STRsql)
        {
            //CLASE QUE DEVUELVE UNA ÚNICA VARIABLE DESDE UNA CONSULTA SQL
            
            
            SqlCommand mycommand = new SqlCommand(STRsql, cnnSql);
            string strCampo = null;
            cnnSql.Open();

            strCampo = mycommand.ExecuteScalar().ToString();


            cnnSql.Close();
            cnnSql.Dispose();
            return strCampo;

        }

        //SECCIÓN WEBSERVICE
        public string WS_logger(string message, int level, string metadata)
        {
            //DELCARAR VARIABLES
            string email = "christian_meneses@e-lifemexico.com";
            string msg = null;

            //INSTANCIAR WS
            WS_LoggerService.LoggerServiceClient ws = new WS_LoggerService.LoggerServiceClient();
            ws.ClientCredentials.UserName.UserName="christian_meneses@e-lifemexico.com";
            ws.ClientCredentials.UserName.Password = "christian_meneses@e-lifemexico.com";


            

            //ENVIO DE VARIABLES A WS
            try
            {
                 ws.Open();
                 ws.Log(email, message,0,metadata);
                 ws.Close();
               
                msg += "ws log consumido correctamente";
            }
            catch (Exception exc)
            {
                msg += exc.Message;
            }

            //REGRESAMOS RESPUESTA
            return msg;

           
        }
        public string WS_loggerhistorial(System.Web.UI.WebControls.GridView grillaa)
        {
            //DELCARAR VARIABLES
            string email = "christian_meneses@e-lifemexico.com";
            string msg = null;

            //INSTANCIAR WS
            WS_LoggerService.LoggerServiceClient ws = new WS_LoggerService.LoggerServiceClient();
            ws.ClientCredentials.UserName.UserName = "christian_meneses@e-lifemexico.com";
            ws.ClientCredentials.UserName.Password = "christian_meneses@e-lifemexico.com";




            //ENVIO DE VARIABLES A WS Y OBTENEMOS DATASET PARA BINDEARLO EN GRIDVIEW
            try
            {
                ws.Open();
                grillaa.DataSource = ws.Historial(email);
                grillaa.DataBind();
                ws.Close();
                
                msg += "ws log consumido correctamente";
            }
            catch (Exception exc)
            {
                msg += exc.Message;
            }

            //REGRESAMOS RESPUESTA
            return msg;


        }

        public string ws_LoggerJson(string message, int nlevel, string metadata)
        {
            string msg = "";
            var url = $"http://silogger.azurewebsites.net/json/Log";
            var request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"christian_meneses@e-lifemexico.com\":\"testmsg\":\"1\":\"testmetadat\"}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) 
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
                msg = "ws correcto";
            }
            catch (WebException ex)
            {
                // Handle error
                msg = "error de ws: " + ex.Message.ToString();
            }
            return msg;
        }



        //SECCIÓN BINDEO CONTROLES
        public void BindddlTipoEmpleado(System.Web.UI.WebControls.DropDownList prtCombo)
        {
            // CLASE QUE BINDEA DROPDOWNLIST TIPO DE EMPLEADO

            DataSet dtStatus = default(DataSet);
           
            string vlSql = null;

            vlSql = "select distinct cTipo from Tbl_Empleados order by cTipo";

            dtStatus = DevuelveDataSetDesdeSelect(vlSql);
            prtCombo.DataSource = dtStatus.Tables[0].DefaultView;
            prtCombo.DataValueField = "cTipo";
            prtCombo.DataTextField = "cTipo";
            prtCombo.DataBind();
            prtCombo.Items.Insert(0, "Todos");
            prtCombo.SelectedIndex = 0;


        }

        public void bindearGridViewReporte(string FiltroTipoEmpleado, System.Web.UI.WebControls.GridView grilla)
        {
            string consultaBusqueda = null;

            if (FiltroTipoEmpleado == "Todos")
            {
                consultaBusqueda = "select nidEmpleado, cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte from Tbl_Empleados WHERE nidStatus = 1";
            }
            else
            {
                consultaBusqueda = "select nidEmpleado, cTipo, nSeccion, cNombres, cApellidos, nHoras, mImporte from Tbl_Empleados WHERE nidStatus = 1 AND cTipo ='" + FiltroTipoEmpleado + "'";
            }

            
            DataSet dtStatus = default(DataSet);
            dtStatus = DevuelveDataSetDesdeSelect(consultaBusqueda);
            int n = dtStatus.Tables[0].Rows.Count;
            if (n == 0)
            {
                //PopInsertar.Show();
                //Button5.Visible = true;
                grilla.DataSource = null;
            }
            else
            {
                grilla.DataSource = null;
                grilla.DataSource = dtStatus.Tables[0].DefaultView;
                grilla.DataSourceID = null;
                grilla.DataBind();


                //ENVIO DE DATA AL WS LOGGER SERVICE
                string respuesta_ws = WS_logger("Consulta de info empleados", 0, "Módulo: Reporteador, filtrado de información");

            }
        }


        //SECCION CÁLCULOS REPORTE
        public void CalculoGral(System.Web.UI.WebControls.Label lbl1,string tipoempleado )
        {
            //CALCULA PROMEDIO COSTO GENERAL 
           
                Double promediogeneral = Convert.ToDouble(REGRESACAMPO("select ISNULL((sum(mImporte)/sum(nhoras)),0) as promedio from Tbl_Empleados WHERE  nidStatus = 1"));
                lbl1.Text = String.Format("{0:C}", promediogeneral);
            
           
        
        
        }
        public void CalculoAgrupado(System.Web.UI.WebControls.Label lbl2, string tipoempleado)
        {
            
           
            //CALCULA PROMEDIO COSTO POR CATEGORIA 
           
                Double promedioagrupado = Convert.ToDouble(REGRESACAMPO("select ISNULL((sum(mImporte)/sum(nhoras)),0) as promedio from Tbl_Empleados where nidStatus = 1 AND cTipo = '" + tipoempleado.Trim() + "'"));
                lbl2.Text = String.Format("{0:C}", promedioagrupado);

            


        }


        //SECCIÓN STORED PROCEDURES
        public void Sp_Borrado_Logico_Empleado(int nidUsuario)
        {
            // STORED PROCEDURE BORRADO LÓGICO DE EMPLEADOS
            
           
                using (SqlCommand cmd = new SqlCommand("SP_Borrado_Logico_Empleados", cnnSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nidEmpleado", SqlDbType.Int).Value = nidUsuario;
                    cmd.Parameters.Add("@nidStatus", SqlDbType.Int).Value = 0;
                // La variable nidStatus deberá tener un catálogo con las siguientes definiciones
                // en este caso este test no compromete generar catálogos con definiciones
                // 1 = activo
                // 0 = inactivo


                try
                {
                    cnnSql.Open();
                    cmd.ExecuteNonQuery();
                    cnnSql.Close();

                    ////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Borrado de Empleados", 0, "Módulo: Reporteador, Borrado Lógico correcto");

                }
                catch (Exception ex)
                {
                    //ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Borrado de Empleados", 2, "Módulo: Reporteador" + ex.Message.ToString());
                }
                
            
                //return bValidar;
            }
            


        }

        public void Sp_Alta_Empleado(string cTipo, int nSeccion, string cNombres, string cApellidos, decimal nHoras, double mImporte, int nidStatus)
        {
            // STORED PROCEDURE ALTA DE EMPLEADOS

           
                using (SqlCommand cmd = new SqlCommand("SP_Alta_EmpleadosFunc", cnnSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cTipo", SqlDbType.Char).Value = cTipo;
                    cmd.Parameters.Add("@nSeccion", SqlDbType.Int).Value = nSeccion;
                    cmd.Parameters.Add("@cNombres", SqlDbType.Char).Value = cNombres;
                    cmd.Parameters.Add("@cApellidos", SqlDbType.Char).Value = cApellidos;
                    cmd.Parameters.Add("@nHoras", SqlDbType.Decimal).Value = nHoras;
                    cmd.Parameters.Add("@mImporte", SqlDbType.Money).Value = mImporte;
                    cmd.Parameters.Add("@nidStatus", SqlDbType.Int).Value = nidStatus;
                    // La variable nidStatus deberá tener un catálogo con las siguientes definiciones
                    // en este caso este test no compromete generar catálogos con definiciones
                    // 1 = activo
                    // 0 = inactivo


                    try
                    {
                        cnnSql.Open();
                        cmd.ExecuteNonQuery();
                        cnnSql.Close();

                    ////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados", 0, "Módulo: Alta empleado, Alta correcta");

                }
                    catch (Exception ex)
                    {
                    ////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados", 2, "Módulo: Alta empleado, Error: " + ex.Message.ToString());

                }
                    
                }
            


        }
        public void Sp_Edicion_Empleado(int nidEmpleado, string cTipo, int nSeccion, string cNombres, string cApellidos, decimal nHoras, double mImporte, int nidStatus)
        {
            // STORED PROCEDURE ALTA DE EMPLEADOS

            
                using (SqlCommand cmd = new SqlCommand("SP_Edicion_Empleados", cnnSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nidEmpleado", SqlDbType.Int).Value = nidEmpleado;
                    cmd.Parameters.Add("@cTipo", SqlDbType.Char).Value = cTipo;
                    cmd.Parameters.Add("@nSeccion", SqlDbType.Int).Value = nSeccion;
                    cmd.Parameters.Add("@cNombres", SqlDbType.Char).Value = cNombres;
                    cmd.Parameters.Add("@cApellidos", SqlDbType.Char).Value = cApellidos;
                    cmd.Parameters.Add("@nHoras", SqlDbType.Decimal).Value = nHoras;
                    cmd.Parameters.Add("@mImporte", SqlDbType.Money).Value = mImporte;
                    cmd.Parameters.Add("@nidStatus", SqlDbType.Int).Value = nidStatus;
                    // La variable nidStatus deberá tener un catálogo con las siguientes definiciones
                    // en este caso este test no compromete generar catálogos con definiciones
                    // 1 = activo
                    // 0 = inactivo


                    try
                    {
                        cnnSql.Open();
                        cmd.ExecuteNonQuery();
                        cnnSql.Close();

                    //ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Edición de Empleados", 0, "Módulo: Edición Formulario Empleados Correcto");

                }
                    catch (Exception ex)
                    {

                    //ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Edición de Empleados", 0, "Módulo: Edición Formulario Empleados Error: " + ex.Message.ToString());
                }

                }
            


        }

        public string SP_COPIAR_XLSDB(string strFilePath)
        {
            // ASIGNAMOS EL NOMBRE DE LA HOJA EXCEL Y LEEMOS DATOS
            // POR EL TIPO DE ARCHIVO A LEER XLS SE CAMBIA EL DATABASEENGINE
            string msg = "";
            string sheetName = "Sheet1";
            var excelFile = new ExcelQueryFactory(strFilePath);
            //excelFile.DatabaseEngine = LinqToExcel.Domain.DatabaseEngine.Ace;


            // MAPEAR COLUMNAS EXCEL:
            excelFile.AddMapping("tipo", "tipo");
            excelFile.AddMapping("seccion", "seccion");
            excelFile.AddMapping("nombres", "nombres");
            excelFile.AddMapping("apellidos", "apellidos");
            excelFile.AddMapping("horas", "horas");
            excelFile.AddMapping("importe", "importe");


            
                var listaEmpleadosdata = from a in excelFile.Worksheet<ListaEmpleados>(sheetName) select a;
           
            
            if (listaEmpleadosdata.Count() != 0)
            {
                try
                {
                    foreach (var a in listaEmpleadosdata)
                    {
                        string EmpleadoInfo = "tipo: {0}; seccion: {1}; nombres: {2}; apellidos: {3}; horas: {4}; importe: {5};";
                        Console.WriteLine(string.Format(EmpleadoInfo, a.tipo, a.seccion, a.nombres, a.apellidos, a.horas, a.importe));

                        
                        Sp_Alta_Empleado(a.tipo.Trim(), a.seccion, a.nombres.Trim(), a.apellidos.Trim(), Convert.ToInt32(a.horas), Convert.ToDouble(a.importe), 1);
                       
                    }
                    msg += listaEmpleadosdata.Count() + " Empleados Guardados Correctamente";
                    //////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados EXCEL", 0, "Módulo: Alta empleado EXCEL, Alta correcta");
                }

                catch (Exception exc)
                {
                    msg += "Error al guardar los datos, verifique archivo XLS : " + exc.Message;
                    //////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados EXCEL", 2, "Módulo: Alta empleado EXCEL, Errror: " + exc.Message.ToString());
                }
                
            }

             return msg;
         }

        public string Sp_Alta_Empleados_XML(string xmldata)
        {
            // STORED PROCEDURE ALTA EMPLEADOS DESDE ARCHIVO XML
            string msg = "";
            xmldata = xmldata.Replace("UTF-8", "UTF-16");

            using (SqlCommand cmd = new SqlCommand("SP_Alta_Empleados_XML", cnnSql))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@xml", SqlDbType.Xml).Value = xmldata.Trim();
                


                try
                {
                    cnnSql.Open();
                    cmd.ExecuteNonQuery();
                    cnnSql.Close();
                    ////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados XML", 0, "Módulo: Alta empleado XML, Alta correcta");
                    msg = "Alta Masiva de Empleados aplicada correctamente!";
                }
                catch (Exception ex)
                {
                    msg = "Ocurrió un error: " + ex.Message.ToString();
                    ////ENVIO DE DATA AL WS LOGGER SERVICE
                    string respuesta_ws = WS_logger("Alta de Empleados XML", 2, "Módulo: Alta empleado XML, Error: " + ex.Message.ToString());

                }
                
            }

            return msg;

        }


        //SECCIÓN CLASES DE DATOS
        public class ListaEmpleados
        {

            public string tipo { get; set; }
            public int seccion { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public int horas { get; set; }
            public double importe { get; set; }

        }

        public class Log
        {
            public List<ListaEmpleados> listaEmpleados { get; set; }
        }

        public class LoggerServiceModel
        {

            public string __type { get; set; }
            public string Date { get; set; }
            public string Email { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
            public string Metadata { get; set; }

        }
    }

    


}