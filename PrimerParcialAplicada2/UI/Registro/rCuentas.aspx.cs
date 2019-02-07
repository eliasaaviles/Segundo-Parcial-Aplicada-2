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
    public partial class rCuentas : System.Web.UI.Page
    {
        public object Utild { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = UtilId.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
                    var cuenta = repositorio.Buscar(id);

                    if (cuenta == null)
                        Mensaje(TipoMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(cuenta);
                }
            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            Cuenta cuentas = LlenaClase();  
            bool paso = false;

            if (cuentas.CuentaId == 0)
                paso = repositorio.Guardar(LlenaClase());
            else
                paso = repositorio.Modificar(LlenaClase());

            if (paso)
            {
                Mensaje(TipoMensaje.Sucess, "Guardado");
                Limpiar();
            }
            else
            {
                Mensaje(TipoMensaje.Error, "No Guardado");
                Limpiar();
            }


            
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            Cuenta cuentas = repositorio.Buscar(UtilId.ToInt(CuentaIdTextBox.Text));

            if (cuentas != null)
            {
                repositorio.Eliminar(cuentas.CuentaId);
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
            CuentaIdTextBox.Text = "";
            FechaTextBox.Text = "";
            NombreTextBox.Text = "";
            BalanceTextBox.Text = "";
        }

        private Cuenta LlenaClase()
        {
            Cuenta cuentas = new Cuenta();

            cuentas.CuentaId = UtilId.ToInt(CuentaIdTextBox.Text);
            cuentas.Fecha = UtilId.ToDateTime(FechaTextBox.Text).Date;
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = UtilId.ToDecimal(BalanceTextBox.Text);

            return cuentas;
        }

        private void LlenaCampos(Cuenta cuentas)
        {
            CuentaIdTextBox.Text = cuentas.CuentaId.ToString();
            FechaTextBox.Text = cuentas.Fecha.ToString();
            NombreTextBox.Text = cuentas.Nombre.ToString();
            BalanceTextBox.Text = cuentas.Balance.ToString();
        }

        void Mensaje(TipoMensaje tipo, string mensaje)
        {
            MensajeLabel.Text = mensaje;
            if (tipo == TipoMensaje.Sucess)
                MensajeLabel.CssClass = "alert-success";
            else
                MensajeLabel.CssClass = "alert-danger";
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            Cuenta cuentas = repositorio.Buscar(UtilId.ToInt(CuentaIdTextBox.Text));

            if (cuentas != null)
            {
                LlenaCampos(cuentas);
            }
            else
            {
                Limpiar();
                Mensaje(TipoMensaje.Error, "No Encontrado");

            }



        }
    }
}