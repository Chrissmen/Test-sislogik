<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test_sislogik._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Reporteador de Empleados SISLOGIK TEST 1.</p>
    </div>
     <div class="col-md-4">
            <p>
                Tipo de Empleado&nbsp;
            </p>
            <asp:DropDownList ID="DdlTipoEmpleado" runat="server"></asp:DropDownList>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />
        </div>
    <div class="row">
       
        <div class="col-md-4">
            
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="99%" DataKeyNames="nidEmpleado" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="nidEmpleado" Visible="False" />
                    <asp:BoundField DataField="cTipo" HeaderText="Tipo Empleado" />
                    <asp:BoundField DataField="nSeccion" HeaderText="Sección" />
                    <asp:BoundField DataField="cNombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="cApellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="nHoras" HeaderText="Horas" />
                    <asp:BoundField DataField="mImporte" DataFormatString="{0:c}" HeaderText="Importe" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Esta seguro que desea borrar al empleado?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="nidEmpleado" DataNavigateUrlFormatString="About.aspx?nidEmpleado={0}" HeaderText="Editar" ShowHeader="False" Text="Editar" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        
    </div>

    <div class="col-md-4">
            <h5>
                <asp:Label ID="Lbletiquetaprom" runat="server" Text="Importe Promedio Agrupado"></asp:Label>
            &nbsp;:
                <asp:Label ID="LblImporteProm" runat="server" Text="$"></asp:Label>
            </h5>
            <h5>Importe Promedio General :
                <asp:Label ID="LblImportePromGral" runat="server" Text="$"></asp:Label>
            </h5>
        </div>

</asp:Content>
