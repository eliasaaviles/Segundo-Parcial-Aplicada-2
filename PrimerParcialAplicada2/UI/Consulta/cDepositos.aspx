<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cDepositos.aspx.cs" Inherits="PrimerParcialAplicada2.UI.Consulta.cDepositos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-primary" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>DepositoId</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>CuentaId</asp:ListItem>
                <asp:ListItem>Concepto</asp:ListItem>
                <asp:ListItem>Monto</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
            <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <div class="form-row justify-content-center">
        <asp:GridView ID="DepositoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="DepositoId" HeaderText="Deposito Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="CuentaId" HeaderText="Cuenta Id" />
                <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                <asp:BoundField DataField="Monto" HeaderText="Monto" />
            </Columns>

        </asp:GridView>

    </div>


</asp:Content>
