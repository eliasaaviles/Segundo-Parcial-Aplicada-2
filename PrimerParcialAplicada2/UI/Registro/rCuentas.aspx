<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rCuentas.aspx.cs" Inherits="PrimerParcialAplicada2.UI.Registro.rCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="form-row">
        <%--CuentaId--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Cuenta Id" class="text-primary" runat="server" />
            <asp:TextBox ID="CuentaIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        </div>
        <%--Fecha--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Fecha" runat="server" />
            <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>
 <%--Boton--%>
            <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarButton_Click">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
        </div>

    </div>

    <div class="form-row">
        <%--Nombre--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Nombre" runat="server" />
            <asp:TextBox ID="NombreTextBox" class="form-control input-sm" runat="server" />


        </div>

        <%--Balance--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Balance" runat="server" />
            <asp:TextBox ID="BalanceTextBox"   ReadOnly="true" class="form-control input-sm" runat="server" />
        </div>

    </div>

    <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>

    <%--Botones--%>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click"/>
                <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click"/>
                <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click"/>

            </div>
        </div>
    </div>


</asp:Content>
