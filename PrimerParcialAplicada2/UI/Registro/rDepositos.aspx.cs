using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.UI.Registro
{
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombos();
                int id = UtilId.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Mensaje(TipoMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(cuenta);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            DepositosRepositorio depositosRepositorio = new DepositosRepositorio();
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            Deposito depositos = LlenaClase();  
            bool paso = false;

            if (depositos.DepositoId == 0)
                paso = depositosRepositorio.Guardar(LlenaClase());
            else
                paso = repositorio.Modificar(LlenaClase());

            if (paso)
            {
                Mensaje(TipoMensaje.Sucess, "Guardado Correctamente");
                Limpiar();
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Se Pudo Guardar");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            DepositosRepositorio repositorio = new DepositosRepositorio();
            Deposito depositos = repositorio.Buscar(UtilId.ToInt(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                repositorio.Eliminar(depositos.DepositoId);
                Mensaje(TipoMensaje.Sucess, "Eliminado Correctamente");
                Limpiar();
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Se Pudo Eliminar");
                Limpiar();
            }
        }

        private void Limpiar()
        {
            DepositoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            CuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";

        }

        void LlenarCombos()
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            CuentaDropDownList.DataSource = repositorio.GetList(c => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        private Deposito LlenaClase()
        {
            Deposito depositos = new Deposito();

            depositos.DepositoId = UtilId.ToInt(DepositoIdTextBox.Text);
            depositos.Fecha = UtilId.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = UtilId.ToInt(CuentaDropDownList.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = UtilId.ToDecimal(MontoTextBox.Text);

            return depositos;
        }

        private void LlenaCampos(Deposito depositos)
        {
            DepositoIdTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString();
            CuentaDropDownList.Text = depositos.CuentaId.ToString();
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }

        void Mensaje(TipoMensaje tipo, string mensaje)
        {
            MensajeLabel.Text = mensaje;
            if (tipo == TipoMensaje.Sucess)
                MensajeLabel.CssClass = "alert-success";
            else
                MensajeLabel.CssClass = "alert-danger";
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            Deposito depositos = repositorio.Buscar(UtilId.ToInt(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                LlenaCampos(depositos);
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Encontrado");
                Limpiar();

            }

        }
    }
}