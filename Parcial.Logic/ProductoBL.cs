using Pacial.Domine;
using Parcial.Data;
using System.Collections.Generic;

namespace Parcial.Logic
{
    public static class ProductoBL
    {
        public static List<Producto> Listar()
        {
            var productoData = new ProductoData();
            return productoData.Listar();
        }

        public static Producto BuscarPorId(int id)
        {
            var productoData = new ProductoData();
            return productoData.BuscarPorId(id);
        }

        public static bool Insertar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Insertar(producto);
        }

        public static bool Actualizar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Actualizar(producto);
        }

        public static bool Eliminar(int nombre)
        {
            var productoData = new ProductoData();
            return productoData.Eliminar(nombre);
        }

    }
}
