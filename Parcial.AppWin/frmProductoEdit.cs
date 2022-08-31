using Pacial.Domine;
using Parcial.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial.AppWin
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();

        }

        private void cargarDatos()
        {
            //Listar lo categoria
            cboCategoria.DataSource = CategoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            this.producto.Nombre = txtNombre.Text;
            this.producto.Marca = txtMarca.Text;
            this.producto.Precio = int.Parse(txtPrecio.Text);
            this.producto.Stock = int.Parse(txtStock.Text);

        }


    }
}
