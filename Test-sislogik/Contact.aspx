<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Test_sislogik.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Alta Masiva de Empleados</h3>
    
    <div class="col-md-4">
            <p>
                Subir Archivo
            </p>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Solo es posible subir archivos XLS ó XML" ForeColor="#CC0000" ValidationExpression="(.*\.([Xx][Ll][Ss])|.*\.([Xx][Mm][Ll])|$)" ValidationGroup="Form"></asp:RegularExpressionValidator>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="*Archivo Requerido" ForeColor="#CC0000" ValidationGroup="Form" 
                ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
            <br />
        <asp:Button ID="Button1" runat="server" Text="Subir Archivo" OnClick="Button1_Click" ValidationGroup="Form" />
        </div>
    <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
    <asp:Label id="lblUploadResult" Runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        <asp:Label ID="lblResult" Runat="server" ForeColor="#CC0000"></asp:Label>
</asp:Panel>

</asp:Content>
