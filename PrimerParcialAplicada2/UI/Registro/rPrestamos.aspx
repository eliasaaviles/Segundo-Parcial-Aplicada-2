<%@ Page Language="C#"  MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="PrimerParcialAplicada2.UI.Registro.rPrestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label for="TextBoxCuentaID">ID</label>
    <div class="form-row">
        <div class="form-group col-md-1">
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxPrestamoID" runat="server" placeholder="0" ></asp:TextBox>
           
        </div>
        <div class="btn-group-col-md-1">
            <asp:Button class="btn btn-primary" ValidationGroup="search" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxFecha">Fecha</label>
            <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha"></asp:TextBox>
        </div>

        <div class="form-group col-md-7 col-md-offset-3">
            <label for="CuentasDropDownList">Cuenta</label>
            <asp:DropDownList ID="CuentasDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxCapital">Capital</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCapital" runat="server" placeholder="Capital"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxInteresAnual">Interes Anual</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxInteresAnual" runat="server" placeholder="Interes Anual"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxTiempoMeses">Tiempo en Meses</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxTiempoMeses" runat="server" placeholder="Tiempo en Meses"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <asp:Button class="btn btn-success" ValidationGroup="calc" ID="ButtonCalcular" runat="server" Text="Calcular" OnClick="ButtonCalcular_Click" />
        </div>
    </div>
    <div class="row justify-content-lg-start mt-3">
        <div class="col-lg-11">
            <asp:GridView ID="CuotasGridView" runat="server" AllowPaging="true" PageSize="12" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="numCuota" HeaderText="#Cuota" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
                    <asp:BoundField DataField="Interes" HeaderText="Interes" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="form-group col-md-7 col-md-offset-3">
         <label for="TextBoxCapitalTotal">Capital Total</label>
        <asp:TextBox ReadOnly="True" class="form-control" ID="TextBoxCapitalTotal" runat="server" Visible="False"></asp:TextBox>
    </div>

    <div class="form-group col-md-7 col-md-offset-3">
         <label for="TextBoxInteresTotal">Interes Total</label>
        <asp:TextBox ReadOnly="true" class="form-control" ID="TextBoxInteresTotal" runat="server" Visible="False"></asp:TextBox>
    </div>

    <div class="btn-block">
        <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" Visible="false" OnClick="ButtonNuevo_Click" />
        <asp:Button class="btn btn-success" ValidationGroup="save" ID="ButtonGuardar" runat="server" Text="Guardar" Visible="false" OnClick="ButtonGuardar_Click" />
        <asp:Button class="btn btn-danger" ID="ButtonEliminar" runat="server" Text="Eliminar" Visible="false" OnClick="ButtonEliminar_Click" />
        
    </div>
</asp:Content>
