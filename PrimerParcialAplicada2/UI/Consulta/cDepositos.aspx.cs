using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.UI.Consulta
{
    public partial class cDepositos : System.Web.UI.Page
    {
        Expression<Func<Deposito, bool>> filtro = d => true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            int id = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = d => true;
                    break;

                case 1://CuentaId
                    id = int.Parse(CriterioTextBox.Text);
                    filtro = (d => d.DepositoId == id);
                    break;

                case 2://Fecha
                    filtro = (d => d.Fecha.Equals(CriterioTextBox.Text));
                    break;

                case 3://CuentaId
                    id = int.Parse(CriterioTextBox.Text);
                    filtro = (d => d.CuentaId == id);
                    break;

                case 4://Concepto
                    filtro = (d => d.Concepto.Contains(CriterioTextBox.Text));
                    break;

                case 5://Monto
                    decimal monto = decimal.Parse(CriterioTextBox.Text);
                    filtro = (d => d.Monto == monto);
                    break;

            }

            DepositoGridView.DataSource = repositorio.GetList(filtro);
            DepositoGridView.DataBind();
        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DepositoGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}