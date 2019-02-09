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
      

        private Repositorio<Cuenta> BLL = new Repositorio<Cuenta>();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {

            Cuenta cuenta = new Cuenta();

            Cuenta cuentas = LlenaClase();
            bool paso = false;

            if (string.IsNullOrWhiteSpace(CuentaIdTextBox.Text))
            {
                BLL.Guardar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado!!')", true);
                paso = true;
            }
            else
            {
                BLL.Modificar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado!!')", true);
                paso = true;
            }

            if (paso == false)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No Guardado!!')", true);

            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            Cuenta cuentas = repositorio.Buscar(int.Parse(CuentaIdTextBox.Text));

            if (cuentas != null)
            {
                repositorio.Eliminar(cuentas.CuentaId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Eliminado!!')", true);
                Limpiar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo Eiminar!!')", true);
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
            var cuentas = new Cuenta();

           
            cuentas.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = 0;

            return cuentas;
        }

        private void LlenaCampos(Cuenta cuentas)
        {
            CuentaIdTextBox.Text = cuentas.CuentaId.ToString();
            FechaTextBox.Text = cuentas.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = cuentas.Nombre.ToString();
            BalanceTextBox.Text = cuentas.Balance.ToString();
        }


        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Cuenta Buscar = null;
            if (!string.IsNullOrWhiteSpace(CuentaIdTextBox.Text))
            {
                Buscar = BLL.Buscar(int.Parse(CuentaIdTextBox.Text));
            }
            if (Buscar != null)
            {
                LlenaCampos(Buscar);
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No Encontrado')", true);
                Limpiar();
            }
        }
    }
}

        