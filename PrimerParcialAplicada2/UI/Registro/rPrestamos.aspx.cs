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
    public partial class rPrestamos : System.Web.UI.Page
    {
        public bool active { get; set; }
        List<PrestamoDetalle> detalle = new List<PrestamoDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                ListCuentas();
                ViewState.Add("Detalle", detalle);
                ViewState.Add("Active", active);
         
            }
            else
            {
                detalle = (List<PrestamoDetalle>)ViewState["Detalle"];
                active = (bool)ViewState["Active"];
            }


            TextBoxFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            detalle.Clear();
            int tiempo = int.Parse(TextBoxTiempoMeses.Text);
            decimal tasa = (Decimal.Parse(TextBoxInteresAnual.Text) / 100);
            decimal cuota = Decimal.Parse(TextBoxCapital.Text) * (tasa / 12) / (decimal)(1 - Math.Pow((double)(1 + (tasa / 12)), -tiempo));
            decimal capital = Decimal.Parse(TextBoxCapital.Text);
            decimal totalC = 0, totalI = 0;

            for (int i = 1; i <= int.Parse(TextBoxTiempoMeses.Text); ++i)
            {
                PrestamoDetalle pd = new PrestamoDetalle();
                pd.PrestamoId = int.Parse(TextBoxPrestamoID.Text);
                pd.numCuota = i;
                pd.Valor = Math.Round(cuota, 2);
                pd.Interes = decimal.Round(capital * (tasa / 12), 2);
                pd.Capital = decimal.Round(cuota - pd.Interes, 2);
                pd.Balance = decimal.Round(capital - pd.Capital, 2);
                capital = pd.Balance;

                totalC += pd.Capital;
                totalI += pd.Interes;

                detalle.Add(pd);
            }
            CuotasGridView.DataSource = detalle.ToList();
            CuotasGridView.DataBind();
            ViewState["Detalle"] = detalle;
            TextBoxCapitalTotal.Text = Decimal.Floor(totalC).ToString();
            TextBoxInteresTotal.Text = totalI.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Cuotas calculadas')", true);
            _Visible();
        }

        private void ListCuentas()
        {
            Repositorio<Cuenta> rep = new Repositorio<Cuenta>();
            CuentasDropDownList.DataSource = rep.GetList(x => true);
            CuentasDropDownList.DataValueField = "CuentaId";
            CuentasDropDownList.DataTextField = "Nombre";
            CuentasDropDownList.DataBind();
            CuentasDropDownList.Items.Insert(0, new ListItem("", ""));
        }


        private void _Visible()
        {
            TextBoxCapitalTotal.Visible = true;
            TextBoxInteresTotal.Visible = true;
            ButtonNuevo.Visible = true;
            ButtonGuardar.Visible = true;
            ButtonEliminar.Visible = true;
            ButtonImprimir.Visible = true;
        }

        private void Invisible()
        {
            TextBoxCapitalTotal.Visible = false;
            TextBoxInteresTotal.Visible = false;
            ButtonNuevo.Visible = false;
            ButtonGuardar.Visible = false;
            ButtonEliminar.Visible = false;
            ButtonImprimir.Visible = false;
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Vaciar();
        }

        private void Vaciar()
        {
            TextBoxCapital.Text = String.Empty;
            TextBoxFecha.Text = String.Empty;
            TextBoxInteresAnual.Text = String.Empty;
            TextBoxPrestamoID.Text = "0";
            TextBoxTiempoMeses.Text = String.Empty;
            TextBoxCapitalTotal.Text = String.Empty;
            TextBoxInteresTotal.Text = String.Empty;
            CuentasDropDownList.DataTextField = String.Empty;
            CuotasGridView.DataSource = null;
            CuotasGridView.DataBind();
            active = false;
            ViewState["Active"] = active;
            Invisible();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();

            if (int.Parse(TextBoxPrestamoID.Text) == 0)
            {
                if (rep.Guardar(LlenarClase()))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo Guardado')", true);
                    Vaciar();
                }
            }
            else
            {
                if (rep.Modificar(LlenarClase()))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo Modificado')", true);
                    Vaciar();
                }
            }

        }


        private Prestamo LlenarClase()
        {
            var Entidad = new Prestamo();

            Entidad.PrestamosId = int.Parse(TextBoxPrestamoID.Text);
            Entidad.Fecha = Convert.ToDateTime(TextBoxFecha.Text);
            Entidad.CuentaId = int.Parse(CuentasDropDownList.SelectedItem.Value);
            Entidad.Capital = decimal.Parse(TextBoxCapital.Text);
            Entidad.InteresAnual = decimal.Parse(TextBoxInteresAnual.Text);
            Entidad.TiempoMeses = int.Parse(TextBoxTiempoMeses.Text);
            Entidad.CapitaTotal = decimal.Parse(TextBoxCapitalTotal.Text);
            Entidad.InteresTotal = decimal.Parse(TextBoxInteresTotal.Text);
            Entidad.Total = decimal.Parse(TextBoxCapitalTotal.Text) + decimal.Parse(TextBoxInteresTotal.Text);
            Entidad.Detalle = detalle;

            return Entidad;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();
            Prestamo prestamo = rep.Buscar(int.Parse(TextBoxPrestamoID.Text));

            if (prestamo != null)
            {
                LlenarCampos(prestamo);
                active = true;
                ViewState["Active"] = active;
                _Visible();
            }
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo no Encontrado')", true);
        }

        private void LlenarCampos(Prestamo prestamos)
        {
            TextBoxPrestamoID.Text = prestamos.PrestamosId.ToString();
            TextBoxFecha.Text = prestamos.Fecha.ToString("yyyy-MM-dd");
            CuentasDropDownList.SelectedValue = prestamos.CuentaId.ToString();
            TextBoxCapital.Text = prestamos.Capital.ToString();
            TextBoxInteresAnual.Text = prestamos.InteresAnual.ToString();
            TextBoxTiempoMeses.Text = prestamos.TiempoMeses.ToString();
            TextBoxCapitalTotal.Text = prestamos.CapitaTotal.ToString();
            TextBoxInteresTotal.Text = prestamos.InteresTotal.ToString();
            CuotasGridView.DataSource = prestamos.Detalle.ToList();
            CuotasGridView.DataBind();
            ViewState["Detalle"] = prestamos.Detalle;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();
            Prestamo prestamos = rep.Buscar(int.Parse(TextBoxPrestamoID.Text));

            if (prestamos != null)
            {
                if (rep.Eliminar(int.Parse(TextBoxPrestamoID.Text)))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo eliminado')", true);
                    Vaciar();
                    Invisible();
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo eliminar el prestamo')", true);
            }
        }
    }
}