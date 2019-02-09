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

       
        private DepositosRepositorio BLL = new DepositosRepositorio();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarCombos();

        }


        

        
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Deposito deposito= new Deposito();            
              
            bool paso = false;

            if (string.IsNullOrWhiteSpace(DepositoIdTextBox.Text))
            {
                BLL.Guardar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado!!')", true);
                paso = true;
            }
            else
            {
                BLL.Modificar(LlenaClase2());
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
            DepositosRepositorio repositorio = new DepositosRepositorio();
            Deposito depositos = repositorio.Buscar(int.Parse(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                repositorio.Eliminar(depositos.DepositoId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Eliminado!!')", true);
                Limpiar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No Eliminado')", true);
                Limpiar();
            }
        }

        private void Limpiar()
        {
            DepositoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            ListadoCuenta.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";

        }

        private void LlenarCombos()
        {
            Repositorio<Cuenta> repositorio = new Repositorio<Cuenta>();
            ListadoCuenta.DataSource = repositorio.GetList(c => true);
            ListadoCuenta.DataValueField = "CuentaId";
            ListadoCuenta.DataTextField = "Nombre";
            ListadoCuenta.DataBind();
            ListadoCuenta.Items.Insert(0, new ListItem("", ""));
        }

        private Deposito LlenaClase()
        {
            Deposito depositos = new Deposito();

            
            depositos.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = int.Parse(ListadoCuenta.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = decimal.Parse(MontoTextBox.Text);

            return depositos;
        }

        private Deposito LlenaClase2()
        {
            Deposito depositos = new Deposito();

            depositos.CuentaId = int.Parse(DepositoIdTextBox.Text);
            depositos.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = int.Parse(ListadoCuenta.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = decimal.Parse(MontoTextBox.Text);

            return depositos;
        }

        private void LlenaCampos(Deposito depositos)
        {
            DepositoIdTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString("yyyy-MM-dd");
            ListadoCuenta.Text = depositos.CuentaId.ToString();
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            Deposito depositos = repositorio.Buscar(int.Parse(DepositoIdTextBox.Text));

            if (depositos != null)
            {
                LlenaCampos(depositos);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No Encontrado')", true);
                Limpiar();

            }
        }

        protected void CuentaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}