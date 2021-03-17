<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Test_sislogik.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Alta de Empleados.</h3>

     
 <div class="container">
 <div class="row"> Tipo: </div>  
 <div class="row">
 <asp:DropDownList ID="DropDownList1" runat="server">
     <asp:ListItem>Cajero</asp:ListItem>
     <asp:ListItem>Repositor</asp:ListItem>
     <asp:ListItem>Supervisor</asp:ListItem>
     </asp:DropDownList>
</div> 
<div class="row"> Sección: </div><div class="row">
<asp:TextBox ID="TxtSeccion" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Requerido" ControlToValidate="TxtSeccion" ForeColor="#CC0000" ValidationGroup="Form"></asp:RequiredFieldValidator>
 &nbsp;<asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="TxtSeccion" ErrorMessage="*Use solo caracteres numericos" ForeColor="#CC0000" Operator="DataTypeCheck" Type="Integer" ValidationGroup="Form"></asp:CompareValidator>
 </div> 
 <div class="row"> Nombres: </div> <div class="row">
 <asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Requerido" ControlToValidate="TxtNombres" ForeColor="#CC0000" ValidationGroup="Form"></asp:RequiredFieldValidator>
 &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtNombres" ErrorMessage="*Use solo caractares alfabéticos" ForeColor="#CC0000" ValidationExpression="^[A-Za-z\s]*$" ValidationGroup="Form"></asp:RegularExpressionValidator>
</div> 
<div class="row"> Apellidos: </div> <div class="row">
 <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Requerido" ControlToValidate="TxtApellidos" ForeColor="#CC0000" ValidationGroup="Form"></asp:RequiredFieldValidator>
 &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtApellidos" ErrorMessage="*Use solo caractares alfabéticos" ForeColor="#CC0000" ValidationExpression="^[A-Za-z\s]*$" ValidationGroup="Form"></asp:RegularExpressionValidator>
</div> 
     <div class="row"> Horas: </div> <div class="row">
 <asp:TextBox ID="TxtHoras" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Requerido" ControlToValidate="TxtHoras" ForeColor="#CC0000" ValidationGroup="Form"></asp:RequiredFieldValidator>
 &nbsp;<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="TxtHoras" ErrorMessage="*Use solo caracteres numericos" ForeColor="#CC0000" Operator="DataTypeCheck" Type="Double" ValidationGroup="Form"></asp:CompareValidator>
</div> 
<div class="row"> Importe: </div> <div class="row">
 <asp:TextBox ID="TxtImporte" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Requerido" ControlToValidate="TxtImporte" ForeColor="#CC0000" ValidationGroup="Form"></asp:RequiredFieldValidator>
 &nbsp;<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TxtImporte" ErrorMessage="*Use solo caracteres numericos" ForeColor="#CC0000" Operator="DataTypeCheck" Type="Currency" ValidationGroup="Form"></asp:CompareValidator>
</div> 
 <div class="row"> <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" ValidationGroup="Form" /> </div>
   
     <div class="row"> </div> <div class="row">
 
     <asp:Label ID="LblMsg" runat="server" ForeColor="#CC0000"></asp:Label>
 
</div> 

 </div>

    
</asp:Content>
