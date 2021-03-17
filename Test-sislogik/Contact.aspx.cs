using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.IO;
using Test_sislogik.clases;


namespace Test_sislogik
{
    public partial class Contact : Page
    {

        Test_sislogik.clases.funciones funcionessys = new clases.funciones();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DECLARACIÓN DE VARIABLES
            
            string strFileName;
            string strFolder;
            strFolder = Server.MapPath("~/Archivos/");
            //OBTENEMOS NOMBRE DE ARCHIVO
            strFileName = FileUpload1.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);

            //OBTENEMOS EXTENCIÓN DEL TIPO DE ARCHIVO
            FileInfo fi = new FileInfo(strFileName);
            string ext = fi.Extension;

            //VALIDAMOS TIPO DE ARCHIVO Y PROCESAMOS LOS DATOS DE INSERCIÓN MASIVA
            if (ext == ".xml")
            {
                Alta_Empleados_XML(strFolder, strFileName);

            }
            else if (ext == ".xls")
            {
                Alta_Empleados_Excel(strFolder, strFileName);

            }


        }

        public void Alta_Empleados_Excel(string strFolder, string strFileName)

        {

            //DECLARAMOS VARIABLES IO PARA SUBIR NUESTRO ARCHIVO
            string strFilePath;

            if (FileUpload1.FileName != "")
            {
                // VALIDAMOS QUE LA CARPETA EXISTA
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // SUBIR Y GUARDAR ARCHIVO EN SERVIDOR
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    lblUploadResult.Text = strFileName + "El archivo ya existe en el servidor";
                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(strFilePath);
                    lblUploadResult.Text = strFileName + " El archivo ha sido guardado en el servidor";
                    lblResult.Text = funcionessys.SP_COPIAR_XLSDB(strFilePath.Trim());


                }
            }
            else
            {
                lblUploadResult.Text = "Selecciona un archivo válido para cargar empleados";
            }
            // MOSTRAR CONFIRMACIÓN DE PROCESO
            frmConfirmation.Visible = true;


        }

        public void Alta_Empleados_XML(string strFolder, string strFileName)
        {
            //DECLARAMOS VARIABLES IO PARA SUBIR NUESTRO ARCHIVO
            string strFilePath;

            if (FileUpload1.FileName != "")
            {
                // VALIDAMOS QUE LA CARPETA EXISTA
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // SUBIR Y GUARDAR ARCHIVO EN SERVIDOR
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    lblUploadResult.Text = strFileName + "El archivo ya existe en el servidor";
                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(strFilePath);
                    string xml = File.ReadAllText(strFilePath);
                    lblUploadResult.Text = strFileName + " El archivo ha sido guardado en el servidor";
                    
                    
                    //INVOCAR WEBSERVICE SendEmpData
                    WS_SendEmpData.WebService1SoapClient wsSendEmpData = new WS_SendEmpData.WebService1SoapClient();
                    lblResult.Text = wsSendEmpData.SendEmpData(xml.Trim());


                }
            }
            else
            {
                lblUploadResult.Text = "Selecciona un archivo válido para cargar empleados";
            }
            // MOSTRAR CONFIRMACIÓN DE PROCESO
            frmConfirmation.Visible = true;

        }
    }
}