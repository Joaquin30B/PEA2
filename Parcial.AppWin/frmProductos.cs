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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var producto in listado)
            {
                dgvListado.Rows.Add( producto.IdProducto,producto.Nombre, producto.Marca, producto.Precio);
            }
        }
        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new frmProductoEdit(nuevoProducto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito)
                {
                    MessageBox.Show("El producto ha sido registrado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar al producto", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idproducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var ProductoEditar = ProductoBL.BuscarPorId(idproducto);
                var frm = new frmProductoEdit(ProductoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(ProductoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido actualizado", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido actualizar","Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar el Producto " + nombreProducto + " ?",
                    "Parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(idProducto);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido eliminado.", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el producto","Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
